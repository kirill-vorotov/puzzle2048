using System.Collections.Generic;
using JetBrains.Annotations;
using MessagePack;

namespace ColorBallsPuzzle.Gameplay
{
    [MessagePackObject, CanBeNull]
    public class CampaignStateModel
    {
        // [Key("0.2.5-level_results")]
        // public List<CampaignLevelResultModel> LevelResults;

        [Key("0.2.5-current_level_index")]
        public int CurrentLevelIndex;
    }
}