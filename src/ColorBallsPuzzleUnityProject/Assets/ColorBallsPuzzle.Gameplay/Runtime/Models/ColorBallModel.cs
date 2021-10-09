namespace ColorBallsPuzzle.Gameplay
{
    public class ColorBallModel
    {
        public BallLevel Level;
        public float CurrentPositionOnPath;

        public ColorBallModel(BallLevel level)
        {
            Level = level;
            CurrentPositionOnPath = 0f;
        }
        
        public ColorBallModel(BallLevel level, float currentPositionOnPath)
        {
            Level = level;
            CurrentPositionOnPath = currentPositionOnPath;
        }
    }
}