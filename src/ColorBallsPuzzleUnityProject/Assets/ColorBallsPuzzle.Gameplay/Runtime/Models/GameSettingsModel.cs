using UnityEngine;

namespace ColorBallsPuzzle.Gameplay
{
    public sealed class GameSettingsModel
    {
        public readonly Vector2 ProjectileSpawnPosition;
        public readonly float PathLength;
        public readonly float RollBackDistance;
        public readonly float[] MatchRollbackTimes;
        public readonly float BallRadius;
        public readonly float BallSpeedForward;
        public readonly float BallAccelerationForward;
        public readonly float BallSpeedForwardLimit;
        public readonly float BallSpeedBackward;
        public readonly BallsSettingsModel BallsSettingsModel;
        public readonly GameTime MovementPauseAfterBallMatchTime;
        public readonly GameTime PauseBetweenMatches;
        public readonly float ProjectileSpeed;
        public readonly Vector2 ProjectileBounds;
        public readonly Health InitialHealth;
        public readonly Health DamagePerBall;
        public readonly int MaxNewBallLevel;
        public readonly CampaignLevelDescModel LevelDescModel;

        public GameSettingsModel(Vector2 projectileSpawnPosition, float pathLength, float ballRadius, float ballSpeedForward, float ballAccelerationForward, float ballSpeedForwardLimit, float ballSpeedBackward, BallsSettingsModel ballsSettingsModel, GameTime movementPauseAfterBallMatchTime, float projectileSpeed, Health initialHealth, Health damagePerBall, int maxNewBallLevel, Vector2 projectileBounds, float[] matchRollbackTimes, CampaignLevelDescModel levelDescModel)
        {
            ProjectileSpawnPosition = projectileSpawnPosition;
            PathLength = pathLength;
            RollBackDistance = pathLength * 0.33f;
            BallRadius = ballRadius;
            BallSpeedForward = ballSpeedForward;
            BallAccelerationForward = ballAccelerationForward;
            BallSpeedForwardLimit = ballSpeedForwardLimit;
            BallSpeedBackward = ballSpeedBackward;
            MovementPauseAfterBallMatchTime = movementPauseAfterBallMatchTime;
            ProjectileSpeed = projectileSpeed;
            InitialHealth = initialHealth;
            DamagePerBall = damagePerBall;
            MaxNewBallLevel = maxNewBallLevel;
            ProjectileBounds = projectileBounds;
            MatchRollbackTimes = matchRollbackTimes;
            LevelDescModel = levelDescModel;
            BallsSettingsModel = ballsSettingsModel;
            PauseBetweenMatches = new GameTime(0.25f);
        }
    }
}