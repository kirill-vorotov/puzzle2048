using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Dreamteck.Splines;
using UnityEngine;
using Random = System.Random;

namespace ColorBallsPuzzle.Gameplay.Views
{
    public class GameplaySceneController : SceneController
    {
        [SerializeField] private SplineComputer _splineComputer;
        [SerializeField] private Transform _projectileSpawner;
        [SerializeField] private SerializableGameSettings _serializableGameSettings;
        [SerializeField] private BallView _ballViewPrefab;
        [SerializeField] private BallView _readyProjectileView;
        [SerializeField] private List<BallView> _ballViews = new List<BallView>();
        [SerializeField] private List<BallView> _ballViewsToRemove = new List<BallView>();
        [SerializeField] private List<BallView> _projectileViews = new List<BallView>();
        [SerializeField] private List<BallView> _projectileViewsToRemove = new List<BallView>();
        [SerializeField] private ExplosionView _explosionPrefab;
        [SerializeField] private List<ExplosionView> _explosions;
        [SerializeField] private GameplayUIView _gameplayUIView;
        [SerializeField] private ProjectileLauncherView _launcherView;
        [SerializeField] private float _currentBallSpeedForward;
        [SerializeField] private int _numberOfBallsSpawned;
        [SerializeField] private int _numberOfBallsInStack;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioSource[] _audioSources;
        [SerializeField] private AudioClip[] _popClips;
        private GameModel _gameModel;
        private bool _animation;
        private bool _running;
        private float _lastAudioTime;
        private float _endGameTime;
        private int _audioSourceIndex = 0;

        public GameModel GameModel => _gameModel;

        public event Action Win;
        public event Action Lose;

        public Vector3 ProjectileSpawnerWorldPosition => _projectileSpawner.position;
        
        public void StartGame()
        {
            var levelIndex =
                GameContext.Player.CampaignState.CurrentLevelIndex >= GameContext.Descriptions.Campaign.Levels.Length
                    ? GameContext.Descriptions.Campaign.Levels.Length - 1
                    : GameContext.Player.CampaignState.CurrentLevelIndex;
            var levelDescId = GameContext.Descriptions.Campaign.Levels[levelIndex];
            var levelDesc = GameContext.Descriptions.Campaign.LevelDescriptions[levelDescId];
            
            var projectileSpawnPosition = _projectileSpawner.position;
            var pathLength = _splineComputer.CalculateLength();
            var gameSettings = new GameSettingsModel(
                new Vector2(projectileSpawnPosition.x, projectileSpawnPosition.z),
                pathLength,
                _serializableGameSettings.BallRadius,
                levelDesc.BallInitialForwardSpeed, 
                levelDesc.BallForwardAcceleration,
                levelDesc.BallMaxForwardSpeed,
                levelDesc.BallInitialBackwardSpeed,
                new BallsSettingsModel(levelDesc.LimitBallsSpawn, levelDesc.BallsAmount),
                new GameTime(_serializableGameSettings.PauseAfterBallMatchTime),
                _serializableGameSettings.ProjectileSpeed,
                levelDesc.InitialHealth,
                levelDesc.DamagePerBall,
                _serializableGameSettings.maxNewBallLevel,
                _serializableGameSettings.ProjectileBounds,
                _serializableGameSettings.MatchRollbackTimes,
                levelDesc
                );
            
            _gameModel = new GameModel(gameSettings, new Random(345065));
            _running = true;
            _gameplayUIView.SetGoalText(_gameModel.GameSettings.LevelDescModel.Goal);
        }

        public void LauchProjectile(Vector2 direction)
        {
            if (_gameModel == null || !_running)
            {
                return;
            }
            GameLogic.LaunchProjectile(ref _gameModel, direction);
            _launcherView.HideAimAssist();
        }

        public void UpdateLaunchDirection(Vector2 direction)
        {
            if (!_running)
            {
                _launcherView.HideAimAssist();
                return;
            }
            _launcherView.ShowAimAssist(direction);
        }

        private void Awake()
        {
            _readyProjectileView.gameObject.SetActive(false);
            _launcherView.HideAimAssist();
            _gameplayUIView.HideGoalText();
        }

        private void FixedUpdate()
        {
            if (_gameModel == null)
            {
                return;
            }

            if (_running)
            {
                if (GameLogic.IsPlayerLost(ref _gameModel))
                {
                    Lose?.Invoke();
                    _endGameTime = Time.time;
                    _running = false;
                }
                else if (GameLogic.IsPlayerWon(ref _gameModel))
                {
                    Win?.Invoke();
                    _endGameTime = Time.time;
                    _running = false;
                }
            }

            if (!_running && Time.time > _endGameTime + 2f)
            {
                return;
            }
            
            GameLogic.UpdateGameTime(ref _gameModel, Time.fixedDeltaTime);
            GameLogic.UpdateBallsSpeed(ref _gameModel);
            GameLogic.UpdateProjectiles(ref _gameModel);
            var collision = GameLogic.CheckAllProjectilesCollisions(ref _gameModel, _splineComputer);
            while (collision)
            {
                collision = GameLogic.CheckAllProjectilesCollisions(ref _gameModel, _splineComputer);
            }

            var ballIndex = -1;
            var ballIndexToReplace = GameLogic.RemoveMatches(ref _gameModel);
            var match = ballIndexToReplace >= 0;
            if (match)
            {
                ballIndex = ballIndexToReplace;
            }
            while (ballIndexToReplace >= 0)
            {
                ballIndexToReplace = GameLogic.RemoveMatches(ref _gameModel);
            }

            if (match)
            {
                if (Time.fixedUnscaledTime > _lastAudioTime + 0.05f)
                {
                    var index = UnityEngine.Random.Range(0, _popClips.Length);

                    if (_audioSources[_audioSourceIndex].isPlaying)
                    {
                        ++_audioSourceIndex;
                        if (_audioSourceIndex >= _audioSources.Length)
                        {
                            _audioSourceIndex = 0;
                        }
                    }
                    _audioSources[_audioSourceIndex].Stop();
                    _audioSources[_audioSourceIndex].PlayOneShot(_popClips[index]);
                    _lastAudioTime = Time.fixedUnscaledTime;
                }

                if (ballIndex >= 0)
                {
                    var ball = GameLogic.GetBall(ref _gameModel, ballIndex);
                    var dir = GameLogic.GetBallWorldDirection(ref _gameModel, ballIndex, _splineComputer);
                    var pos = GameLogic.GetBallWorldPosition(ref _gameModel, ballIndex, _splineComputer) - dir.normalized * _gameModel.GameSettings.BallRadius;
                    var instance = Instantiate(_explosionPrefab, new Vector3(pos.x, 4f, pos.y), Quaternion.identity);
                    instance.transform.localScale = Vector3.one * (ball.Level.Value * 0.2f + 1);
                    instance.Initialize(2f);
                }
                match = false;
            }
            if (GameLogic.CanSpawnNewBall(ref _gameModel))
            {
                GameLogic.SpawnNewBall(ref _gameModel);
            }
            GameLogic.MoveBalls(ref _gameModel);
            GameLogic.SpawnProjectile(ref _gameModel);
            GameLogic.TryToRemoveFirstBalls(ref _gameModel);
            GameLogic.TryToRemoveLastBalls(ref _gameModel);
        }

        private void Update()
        {
            if (_gameModel == null)
            {
                return;
            }
            
            if (GameLogic.IsPlayerWon(ref _gameModel) || GameLogic.IsPlayerLost(ref _gameModel))
            {
                if (Time.time > _endGameTime + 2f)
                {
                    if (_ballViews.Count > 0)
                    {
                        foreach (var ballView in _ballViews)
                        {
                            Destroy(ballView.gameObject);
                        }
                        _ballViews.Clear();
                    }

                    if (_projectileViews.Count > 0)
                    {
                        foreach (var projectile in _projectileViews)
                        {
                            Destroy(projectile.gameObject);
                        }
                        _projectileViews.Clear();
                    }
                    _readyProjectileView.gameObject.SetActive(false);
                    return;
                }
            }
            
            _currentBallSpeedForward = _gameModel.MovementModel.CurrentBallSpeedForward;
            _numberOfBallsSpawned = _gameModel.NumberOfBallsSpawned;
            _numberOfBallsInStack = _gameModel.BallStack.Count;
            UpdateBallViews();
            UpdateProjectileViews();
            _gameplayUIView.UpdateScore(_gameModel.Score);
            _gameplayUIView.UpdateHealth(_gameModel.Health);
        }

        public Color GetBallColor(int level)
        {
            var index = level % _serializableGameSettings.BallColorSettings.Colors.Count;
            return _serializableGameSettings.BallColorSettings.Colors[index];
        }

        private BallView InstantiateBallView()
        {
            return Instantiate(_ballViewPrefab, transform);
        }

        private void UpdateBallViews()
        {
            for (int ballIndex = 0; ballIndex < _gameModel.Balls.Count; ++ballIndex)
            {
                if (ballIndex >= _ballViews.Count)
                {
                    _ballViews.Add(InstantiateBallView());
                }
                
                var ball = GameLogic.GetBall(ref _gameModel, ballIndex);
                var color = GetBallColor(ball.Level.Value);
                var pos = GameLogic.GetBallWorldPosition(ref _gameModel, ballIndex, _splineComputer);
                _ballViews[ballIndex].UpdateView(new Vector3(pos.x, _projectileSpawner.position.y, pos.y), ball.Level.Value, color, ball.CurrentPositionOnPath);
            }

            if (_ballViews.Count > _gameModel.Balls.Count)
            {
                for (int i = _gameModel.Balls.Count; i < _ballViews.Count; i++)
                {
                    _ballViewsToRemove.Add(_ballViews[i]);
                }
            }

            foreach (var ballView in _ballViewsToRemove)
            {
                Destroy(ballView.gameObject);
                _ballViews.Remove(ballView);
            }
            _ballViewsToRemove.Clear();
        }

        private void UpdateProjectileViews()
        {
            if (_gameModel.HasProjectile)
            {
                _readyProjectileView.gameObject.SetActive(true);
                var pos = _gameModel.GameSettings.ProjectileSpawnPosition;
                _readyProjectileView.UpdateView(new Vector3(pos.x, _projectileSpawner.position.y, pos.y), _gameModel.ProjectileLevel.Value, GetBallColor(_gameModel.ProjectileLevel.Value));
            }
            else if (_readyProjectileView.gameObject.activeSelf)
            {
                _readyProjectileView.gameObject.SetActive(false);
            }
            
            for (var projectileIndex = 0; projectileIndex < _gameModel.Projectiles.Count; ++projectileIndex)
            {
                if (projectileIndex >= _projectileViews.Count)
                {
                    _projectileViews.Add(InstantiateBallView());
                }
                
                var projectile = _gameModel.Projectiles[projectileIndex];
                var color = GetBallColor(projectile.Level.Value);
                var pos = GameLogic.GetProjectilePosition(projectile, _gameModel.Time);
                _projectileViews[projectileIndex].UpdateView(new Vector3(pos.x, _projectileSpawner.position.y, pos.y), projectile.Level.Value, color);
            }

            if (_projectileViews.Count > _gameModel.Projectiles.Count)
            {
                for (int i = _gameModel.Projectiles.Count; i < _projectileViews.Count; i++)
                {
                    _projectileViewsToRemove.Add(_projectileViews[i]);
                }
            }

            foreach (var projectileToRemove in _projectileViewsToRemove)
            {
                Destroy(projectileToRemove.gameObject);
                _projectileViews.Remove(projectileToRemove);
            }
            _projectileViewsToRemove.Clear();
        }
    }
}