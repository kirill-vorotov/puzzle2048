using System.Collections.Generic;

namespace ColorBallsPuzzle.Gameplay
{
    public static class PlayerLogic
    {
        public static PlayerModel CreatePlayerModel(PlayerModelVersion version)
        {
            return new PlayerModel()
            {
                Version = version,
                CampaignState = new CampaignStateModel()
                {
                    CurrentLevelIndex = 0,
                },
            };
        }

        public static void CompleteLevel(int levelIndex, int score)
        {
            
        }
    }
}