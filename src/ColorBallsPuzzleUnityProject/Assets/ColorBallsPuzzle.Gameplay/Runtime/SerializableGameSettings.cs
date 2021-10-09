using UnityEngine;

namespace ColorBallsPuzzle.Gameplay
{
    [CreateAssetMenu]
    public class SerializableGameSettings : ScriptableObject
    {
        public float BallRadius = 0.5f;
        public float BallSpeedForward = 0.5f;
        public float BallAccelerationForward = 0.01f;
        public float BallSpeedForwardLimit = 5f;
        public float BallSpeedBackward = 4f;
        public float PauseAfterBallMatchTime = 0.5f;
        public float ProjectileSpeed = 5f;
        public Vector2 ProjectileBounds = new Vector2(14, 24);
        public int InitialiplayerHealth = 3;
        public int DamagePerBall = 1;
        public int maxNewBallLevel = 3;
        public bool UserBallLimit;
        public int BallsLimit;
        public SeralizableBallColorSettings BallColorSettings;
        public float[] MatchRollbackTimes;
    }
}