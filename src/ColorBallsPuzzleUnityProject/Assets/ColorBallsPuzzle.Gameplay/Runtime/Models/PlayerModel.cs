using MessagePack;

namespace ColorBallsPuzzle.Gameplay
{
    [MessagePackObject]
    public class PlayerModel
    {
        [Key("0.2.5-version")]
        public PlayerModelVersion Version;
        
        [Key("0.2.5-campaign_progress")]
        public CampaignStateModel CampaignState;
    }
}