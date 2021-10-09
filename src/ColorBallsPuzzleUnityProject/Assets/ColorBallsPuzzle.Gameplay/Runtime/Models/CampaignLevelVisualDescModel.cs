using MessagePack;

namespace ColorBallsPuzzle.Gameplay
{
    [MessagePackObject]
    public class CampaignLevelVisualDescModel
    {
        [Key("scene_address")]
        public string SceneAddress;
    }
}