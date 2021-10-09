namespace ColorBallsPuzzle.Gameplay
{
    public class MovementModel
    {
        public MovementType MovementType;
        public GameTime DamageRollbackTime;
        public GameTime MatchRollbackTime;
        public GameTime MatchPauseTime;
        public float CurrentBallSpeedForward;
    }
}