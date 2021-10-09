using System.Collections.ObjectModel;
using MessagePack;

namespace ColorBallsPuzzle.Gameplay
{
    [MessagePackObject]
    public class CampaignDescModel
    {
        [Key("level_descs")]
        public ReadOnlyDictionary<CampaignLevelDescId, CampaignLevelDescModel> LevelDescriptions;
        [Key("levels")]
        public CampaignLevelDescId[] Levels;
    }
}