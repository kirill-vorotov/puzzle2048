using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ColorBallsPuzzle.Gameplay
{
    public static class DescriptionsFactory
    {
        public static DescriptionsModel CreateDescriptions()
        {
            return new DescriptionsModel()
            {
                Version = new DescriptionsVersion(1),
                Campaign = new CampaignDescModel()
                {
                    LevelDescriptions = CreateLevelDescriptions(),
                    Levels = new []
                    {
                        Descriptions.CampaignLevels.TutorialLevel01.Id, // 1
                        Descriptions.CampaignLevels.TutorialLevel02.Id, // 2
                        Descriptions.CampaignLevels.Level2Difficulty5.Id, // 3
                        Descriptions.CampaignLevels.Level3Difficulty6.Id, // 4
                        Descriptions.CampaignLevels.Level4Difficulty7.Id, // 5
                        Descriptions.CampaignLevels.Level0Difficulty8.Id, // 6
                        Descriptions.CampaignLevels.Level1Difficulty8.Id, // 7
                        Descriptions.CampaignLevels.Level2Difficulty9.Id, // 8
                        Descriptions.CampaignLevels.Level3Difficulty9.Id, // 9
                        Descriptions.CampaignLevels.Level4Difficulty10.Id, // 10
                        Descriptions.CampaignLevels.Level0Difficulty10.Id, // 11
                        Descriptions.CampaignLevels.Level1Difficulty11.Id, // 12
                        Descriptions.CampaignLevels.Level2Difficulty11.Id, // 13
                        Descriptions.CampaignLevels.Level3Difficulty12.Id, // 14
                        Descriptions.CampaignLevels.Level4Difficulty12.Id, // 15
                        Descriptions.CampaignLevels.Level0Difficulty12.Id, // 16
                        Descriptions.CampaignLevels.Level1Difficulty12.Id, // 17
                        Descriptions.CampaignLevels.Level2Difficulty12.Id, // 18
                        Descriptions.CampaignLevels.Level3Difficulty12.Id, // 19
                        Descriptions.CampaignLevels.Level4Difficulty12.Id, // 20
                        Descriptions.CampaignLevels.Level0Difficulty12.Id, // 21
                        Descriptions.CampaignLevels.Level1Difficulty12.Id, // 22
                        Descriptions.CampaignLevels.Level2Difficulty12.Id, // 23
                        Descriptions.CampaignLevels.Level3Difficulty12.Id, // 24
                        Descriptions.CampaignLevels.Level4Difficulty12.Id, // 25
                        Descriptions.CampaignLevels.Level0Difficulty12.Id, // 26
                        Descriptions.CampaignLevels.Level1Difficulty12.Id, // 27
                        Descriptions.CampaignLevels.Level2Difficulty12.Id, // 28
                        Descriptions.CampaignLevels.Level3Difficulty12.Id, // 29
                        Descriptions.CampaignLevels.Level4Difficulty12.Id, // 30
                        Descriptions.CampaignLevels.Level0Difficulty12.Id, // 31
                        Descriptions.CampaignLevels.Level1Difficulty12.Id, // 32
                        Descriptions.CampaignLevels.Level2Difficulty12.Id, // 33
                        Descriptions.CampaignLevels.Level3Difficulty12.Id, // 34
                        Descriptions.CampaignLevels.Level4Difficulty12.Id, // 35
                        Descriptions.CampaignLevels.Level0Difficulty12.Id, // 36
                        Descriptions.CampaignLevels.Level1Difficulty12.Id, // 37
                        Descriptions.CampaignLevels.Level2Difficulty12.Id, // 38
                        Descriptions.CampaignLevels.Level3Difficulty12.Id, // 39
                        Descriptions.CampaignLevels.Level4Difficulty12.Id, // 40
                    },
                },
            };
        }

        private static ReadOnlyDictionary<CampaignLevelDescId, CampaignLevelDescModel> CreateLevelDescriptions()
        {
            var dictionary = new Dictionary<CampaignLevelDescId, CampaignLevelDescModel>();
            dictionary.Add(Descriptions.CampaignLevels.TutorialLevel01.Id, Descriptions.CampaignLevels.TutorialLevel01);
            dictionary.Add(Descriptions.CampaignLevels.TutorialLevel02.Id, Descriptions.CampaignLevels.TutorialLevel02);
            
            dictionary.Add(Descriptions.CampaignLevels.Level0Difficulty5.Id, Descriptions.CampaignLevels.Level0Difficulty5);
            dictionary.Add(Descriptions.CampaignLevels.Level1Difficulty5.Id, Descriptions.CampaignLevels.Level1Difficulty5);
            dictionary.Add(Descriptions.CampaignLevels.Level2Difficulty5.Id, Descriptions.CampaignLevels.Level2Difficulty5);
            dictionary.Add(Descriptions.CampaignLevels.Level3Difficulty5.Id, Descriptions.CampaignLevels.Level3Difficulty5);
            dictionary.Add(Descriptions.CampaignLevels.Level4Difficulty5.Id, Descriptions.CampaignLevels.Level4Difficulty5);
            
            dictionary.Add(Descriptions.CampaignLevels.Level0Difficulty6.Id, Descriptions.CampaignLevels.Level0Difficulty6);
            dictionary.Add(Descriptions.CampaignLevels.Level1Difficulty6.Id, Descriptions.CampaignLevels.Level1Difficulty6);
            dictionary.Add(Descriptions.CampaignLevels.Level2Difficulty6.Id, Descriptions.CampaignLevels.Level2Difficulty6);
            dictionary.Add(Descriptions.CampaignLevels.Level3Difficulty6.Id, Descriptions.CampaignLevels.Level3Difficulty6);
            dictionary.Add(Descriptions.CampaignLevels.Level4Difficulty6.Id, Descriptions.CampaignLevels.Level4Difficulty6);
            
            dictionary.Add(Descriptions.CampaignLevels.Level0Difficulty7.Id, Descriptions.CampaignLevels.Level0Difficulty7);
            dictionary.Add(Descriptions.CampaignLevels.Level1Difficulty7.Id, Descriptions.CampaignLevels.Level1Difficulty7);
            dictionary.Add(Descriptions.CampaignLevels.Level2Difficulty7.Id, Descriptions.CampaignLevels.Level2Difficulty7);
            dictionary.Add(Descriptions.CampaignLevels.Level3Difficulty7.Id, Descriptions.CampaignLevels.Level3Difficulty7);
            dictionary.Add(Descriptions.CampaignLevels.Level4Difficulty7.Id, Descriptions.CampaignLevels.Level4Difficulty7);
            
            dictionary.Add(Descriptions.CampaignLevels.Level0Difficulty8.Id, Descriptions.CampaignLevels.Level0Difficulty8);
            dictionary.Add(Descriptions.CampaignLevels.Level1Difficulty8.Id, Descriptions.CampaignLevels.Level1Difficulty8);
            dictionary.Add(Descriptions.CampaignLevels.Level2Difficulty8.Id, Descriptions.CampaignLevels.Level2Difficulty8);
            dictionary.Add(Descriptions.CampaignLevels.Level3Difficulty8.Id, Descriptions.CampaignLevels.Level3Difficulty8);
            dictionary.Add(Descriptions.CampaignLevels.Level4Difficulty8.Id, Descriptions.CampaignLevels.Level4Difficulty8);
            
            dictionary.Add(Descriptions.CampaignLevels.Level0Difficulty9.Id, Descriptions.CampaignLevels.Level0Difficulty9);
            dictionary.Add(Descriptions.CampaignLevels.Level1Difficulty9.Id, Descriptions.CampaignLevels.Level1Difficulty9);
            dictionary.Add(Descriptions.CampaignLevels.Level2Difficulty9.Id, Descriptions.CampaignLevels.Level2Difficulty9);
            dictionary.Add(Descriptions.CampaignLevels.Level3Difficulty9.Id, Descriptions.CampaignLevels.Level3Difficulty9);
            dictionary.Add(Descriptions.CampaignLevels.Level4Difficulty9.Id, Descriptions.CampaignLevels.Level4Difficulty9);
            
            dictionary.Add(Descriptions.CampaignLevels.Level0Difficulty10.Id, Descriptions.CampaignLevels.Level0Difficulty10);
            dictionary.Add(Descriptions.CampaignLevels.Level1Difficulty10.Id, Descriptions.CampaignLevels.Level1Difficulty10);
            dictionary.Add(Descriptions.CampaignLevels.Level2Difficulty10.Id, Descriptions.CampaignLevels.Level2Difficulty10);
            dictionary.Add(Descriptions.CampaignLevels.Level3Difficulty10.Id, Descriptions.CampaignLevels.Level3Difficulty10);
            dictionary.Add(Descriptions.CampaignLevels.Level4Difficulty10.Id, Descriptions.CampaignLevels.Level4Difficulty10);
            
            dictionary.Add(Descriptions.CampaignLevels.Level0Difficulty11.Id, Descriptions.CampaignLevels.Level0Difficulty11);
            dictionary.Add(Descriptions.CampaignLevels.Level1Difficulty11.Id, Descriptions.CampaignLevels.Level1Difficulty11);
            dictionary.Add(Descriptions.CampaignLevels.Level2Difficulty11.Id, Descriptions.CampaignLevels.Level2Difficulty11);
            dictionary.Add(Descriptions.CampaignLevels.Level3Difficulty11.Id, Descriptions.CampaignLevels.Level3Difficulty11);
            dictionary.Add(Descriptions.CampaignLevels.Level4Difficulty11.Id, Descriptions.CampaignLevels.Level4Difficulty11);
            
            dictionary.Add(Descriptions.CampaignLevels.Level0Difficulty12.Id, Descriptions.CampaignLevels.Level0Difficulty12);
            dictionary.Add(Descriptions.CampaignLevels.Level1Difficulty12.Id, Descriptions.CampaignLevels.Level1Difficulty12);
            dictionary.Add(Descriptions.CampaignLevels.Level2Difficulty12.Id, Descriptions.CampaignLevels.Level2Difficulty12);
            dictionary.Add(Descriptions.CampaignLevels.Level3Difficulty12.Id, Descriptions.CampaignLevels.Level3Difficulty12);
            dictionary.Add(Descriptions.CampaignLevels.Level4Difficulty12.Id, Descriptions.CampaignLevels.Level4Difficulty12);
            return new ReadOnlyDictionary<CampaignLevelDescId, CampaignLevelDescModel>(dictionary);
        }
    }
}