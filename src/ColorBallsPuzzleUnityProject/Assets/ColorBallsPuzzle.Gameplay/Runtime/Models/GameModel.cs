using System;
using System.Collections.Generic;
using System.Linq;

namespace ColorBallsPuzzle.Gameplay
{
    public sealed class GameModel
    {
        public readonly GameSettingsModel GameSettings;
        public readonly Random Rng;
        public GameTime Time;
        public GameTime DeltaTime;
        public Health Health;
        public List<ColorBallModel> Balls;
        public Stack<ColorBallModel> BallStack;
        public int NumberOfBallsSpawned;
        public int NumberOfProjectilesSpawned;
        public GameTime LastSpawnTime;
        public MovementModel MovementModel;
        public List<ProjectileModel> Projectiles;
        public BallLevel MaxProjectileLevel;
        public BallLevel ProjectileLevel;
        public bool HasProjectile;
        public int Score;
        public GameTime LastMatchTime;
        public GameTime StartSpeedUpTime;
        public BallLevel HighestBallLevelReached;
        
        public GameModel(GameSettingsModel gameSettings, Random rng)
        {
            GameSettings = gameSettings;
            Rng = rng;
            Time = new GameTime(0f);
            Health = gameSettings.InitialHealth;
            Balls = new List<ColorBallModel>(1);
            BallStack = new Stack<ColorBallModel>();
            NumberOfBallsSpawned = 0;
            NumberOfProjectilesSpawned = 0;
            LastSpawnTime = Time;
            Projectiles = new List<ProjectileModel>(1);
            MovementModel = new MovementModel()
            {
                MovementType = MovementType.Forward,
                DamageRollbackTime = new GameTime(0),
                CurrentBallSpeedForward = gameSettings.BallSpeedForward,
            };
            StartSpeedUpTime = new GameTime(gameSettings.PathLength * 0.33f / (gameSettings.BallSpeedForward * 40f));
            HighestBallLevelReached = new BallLevel(0);
        }
    }
}