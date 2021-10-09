using MessagePack;

namespace ColorBallsPuzzle.Gameplay
{
    [MessagePackObject]
    public readonly struct CampaignLevelResultModel
    {
        [Key("0.2.5-score")]
        public readonly int Score;

        public CampaignLevelResultModel(int score)
        {
            Score = score;
        }
    }
}