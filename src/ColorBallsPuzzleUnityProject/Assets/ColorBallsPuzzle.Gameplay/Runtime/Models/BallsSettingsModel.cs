namespace ColorBallsPuzzle.Gameplay
{
    public class BallsSettingsModel
    {
        public readonly bool UseBallLimit;
        public readonly int BallsLimit;

        public BallsSettingsModel(bool useBallLimit, int ballsLimit)
        {
            UseBallLimit = useBallLimit;
            BallsLimit = ballsLimit;
        }
    }
}