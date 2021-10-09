using System;
using System.Collections.Generic;
using ColorBallsPuzzle.AssetManagement;
using ColorBallsPuzzle.Gameplay;
using ColorBallsPuzzle.Gameplay.Views;
using Cysharp.Threading.Tasks;
using Facebook.Unity;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace ColorBallsPuzzle.UI
{
    public class UISceneController : SceneController
    {
        [SerializeField] private ScreenBehaviour _loadingScreen;
        [SerializeField] private ScreenBehaviour _homeScreen;
        [SerializeField] private ScreenBehaviour _winScreen;
        [SerializeField] private ScreenBehaviour _loseScreen;

        private SceneAddressLoader _sceneLoader;
        private GameplaySceneController _currentGameplaySceneController;

        protected override void OnInitialize()
        {
            _loadingScreen.Initialize(GameContext, this);
            _homeScreen.Initialize(GameContext, this);
            _winScreen.Initialize(GameContext, this);
            _loseScreen.Initialize(GameContext, this);
            ShowHomeScreen().Forget();
        }

        public UniTask HideAllScreens()
        {
            return UniTask.WhenAll(
                _loadingScreen.Hide(), 
                _homeScreen.Hide(), 
                _winScreen.Hide(), 
                _loseScreen.Hide()
                );
        }

        public async UniTaskVoid ShowHomeScreen()
        {
            try
            {
                HideAllScreens().Forget();
            
                await _homeScreen.Show();
                if (FB.IsInitialized)
                {
                    FB.LogAppEvent("Game started");
                }
                Amplitude.Instance.logEvent("Game started");
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                throw;
            }
        }

        public async UniTaskVoid StartGame()
        {
            try
            {
                HideAllScreens().Forget();
                await _loadingScreen.Show();
                var startTime = Time.realtimeSinceStartup;
            
                var levelIndex =
                    GameContext.Player.CampaignState.CurrentLevelIndex >= GameContext.Descriptions.Campaign.Levels.Length
                        ? GameContext.Descriptions.Campaign.Levels.Length - 1
                        : GameContext.Player.CampaignState.CurrentLevelIndex;
                var levelDescId = GameContext.Descriptions.Campaign.Levels[levelIndex];
                var levelDesc = GameContext.Descriptions.Campaign.LevelDescriptions[levelDescId];
                if (_sceneLoader != null)
                {
                    await _sceneLoader.UnloadAsync(true);
                }
                await LoadLevelScene(levelDesc.Visual.SceneAddress);
                _currentGameplaySceneController = FindObjectOfType<GameplaySceneController>();
                _currentGameplaySceneController.Win += OnWin;
                _currentGameplaySceneController.Lose += OnLose;
            
                var endTime = Time.realtimeSinceStartup;
                var time = endTime - startTime;
                if (time < 0.5f)
                {
                    await UniTask.Delay(TimeSpan.FromSeconds(0.5f - time));
                }

                await _loadingScreen.Hide();
                await UniTask.Delay(TimeSpan.FromSeconds(1f));
                _currentGameplaySceneController.Initialize(GameContext);
                _currentGameplaySceneController.StartGame();

                var analyticsParams = new Dictionary<string, object>(1);
                analyticsParams["Level"] = GameContext.Player.CampaignState.CurrentLevelIndex;
                if (FB.IsInitialized)
                {
                    FB.LogAppEvent("Level started", parameters: analyticsParams);
                }
                Amplitude.Instance.logEvent("Level started", analyticsParams);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                throw;
            }
        }

        public async UniTaskVoid EndGame(bool win)
        {
            try
            {
                var analyticsParams = new Dictionary<string, object>(2);
                analyticsParams["Level"] = GameContext.Player.CampaignState.CurrentLevelIndex;
                analyticsParams["Success"] = win ? 1 : 0;
                if (FB.IsInitialized)
                {
                    FB.LogAppEvent("Level ended", parameters: analyticsParams);
                }
                Amplitude.Instance.logEvent("Level ended", analyticsParams);
                
                if (win)
                {
                    ++GameContext.Player.CampaignState.CurrentLevelIndex;
                }
                PlayerModelPlayerPrefsStorage.Write(GameContext.Player);
                
                await UniTask.Delay(TimeSpan.FromSeconds(2f));
                if (win)
                {
                    await _winScreen.Show();
                }
                else
                {
                    await _loseScreen.Show();
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                throw;
            }
        }

        private async UniTask LoadLevelScene(string sceneAddress)
        {
            try
            {
                _sceneLoader?.Dispose();
                _sceneLoader = new SceneAddressLoader(sceneAddress);
                await _sceneLoader.LoadAsync(LoadSceneMode.Additive);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                throw;
            }
        }
        
        private void OnWin()
        {
            try
            {
                _currentGameplaySceneController.Win -= OnWin;
                EndGame(true).Forget();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                throw;
            }
        }

        private void OnLose()
        {
            try
            {
                _currentGameplaySceneController.Lose -= OnLose;
                EndGame(false).Forget();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                throw;
            }
        }

        private void OnApplicationQuit()
        {
            if (FB.IsInitialized)
            {
                FB.LogAppEvent("Game quit");
            }
            Amplitude.Instance.logEvent("Game quit");
        }
    }
}