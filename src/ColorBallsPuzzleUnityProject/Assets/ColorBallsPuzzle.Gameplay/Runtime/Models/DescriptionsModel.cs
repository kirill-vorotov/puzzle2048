using MessagePack;

namespace ColorBallsPuzzle.Gameplay
{
    [MessagePackObject]
    public class DescriptionsModel
    {
        [Key("version")]
        public DescriptionsVersion Version;
        [Key("campaign")]
        public CampaignDescModel Campaign;
    }
}