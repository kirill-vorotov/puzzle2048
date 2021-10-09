using System;

namespace ColorBallsPuzzle.Gameplay
{
    public static partial class Descriptions
    {
        public static class CampaignLevels
        {
            public static readonly CampaignLevelDescModel TutorialLevel01 = new CampaignLevelDescModel()
            {
                Id = new CampaignLevelDescId(100),
                BallInitialForwardSpeed = 1f,
                BallMaxForwardSpeed = 1f,
                BallForwardAcceleration = 0.0f,
                BallInitialBackwardSpeed = 25f,
                InitialHealth = new Health(3),
                DamagePerBall = new Health(0),
                LimitBallsSpawn = false,
                BallsAmount = 8,
                Goal = new BallLevel(3),
                Balls = new []
                {
                    new BallLevel(0),
                    new BallLevel(1),
                    new BallLevel(2),
                    new BallLevel(0),
                    new BallLevel(1),
                    new BallLevel(2),
                    new BallLevel(0),
                    new BallLevel(1),
                    new BallLevel(2),
                    new BallLevel(0),
                    new BallLevel(1),
                    new BallLevel(2),
                    new BallLevel(0),
                    new BallLevel(1),
                    new BallLevel(2),
                    new BallLevel(0),
                    new BallLevel(1),
                    new BallLevel(2),
                    new BallLevel(0),
                    new BallLevel(1),
                    new BallLevel(2),
                    new BallLevel(0),
                    new BallLevel(1),
                    new BallLevel(2),
                    new BallLevel(0),
                    new BallLevel(1),
                    new BallLevel(2),
                    new BallLevel(0),
                    new BallLevel(1),
                    new BallLevel(2),
                    new BallLevel(0),
                    new BallLevel(1),
                    new BallLevel(2),
                    new BallLevel(0),
                    new BallLevel(1),
                    new BallLevel(2),
                    new BallLevel(0),
                    new BallLevel(1),
                    new BallLevel(2),
                    new BallLevel(0),
                    new BallLevel(1),
                    new BallLevel(2),
                    new BallLevel(0),
                    new BallLevel(1),
                    new BallLevel(2),
                    new BallLevel(0),
                    new BallLevel(1),
                    new BallLevel(2),
                    new BallLevel(0),
                    new BallLevel(1),
                    new BallLevel(2),
                    new BallLevel(0),
                    new BallLevel(1),
                    new BallLevel(2),
                    new BallLevel(0),
                    new BallLevel(1),
                    new BallLevel(2),
                    new BallLevel(0),
                    new BallLevel(1),
                    new BallLevel(2),
                    new BallLevel(0),
                    new BallLevel(1),
                    new BallLevel(2),
                    new BallLevel(0),
                    new BallLevel(1),
                    new BallLevel(2),
                    new BallLevel(0),
                    new BallLevel(1),
                    new BallLevel(2),
                    new BallLevel(0),
                    new BallLevel(1),
                    new BallLevel(2),
                },
                Projectiles = new []
                {
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                    new BallLevel(0),
                },
                Visual = new CampaignLevelVisualDescModel()
                {
                    SceneAddress = "Assets/Scenes/Level_0.unity",
                },
            };
            
            public static readonly CampaignLevelDescModel TutorialLevel02 = new CampaignLevelDescModel()
            {
                Id = new CampaignLevelDescId(200),
                BallInitialForwardSpeed = 1f,
                BallMaxForwardSpeed = 1f,
                BallForwardAcceleration = 0.0f,
                BallInitialBackwardSpeed = 25f,
                InitialHealth = new Health(3),
                DamagePerBall = new Health(1),
                LimitBallsSpawn = false,
                BallsAmount = 8,
                Goal = new BallLevel(4),
                Balls = new []
                {
                    new BallLevel(0),
                    new BallLevel(1),
                    new BallLevel(0),
                    new BallLevel(2),
                    new BallLevel(0),
                    new BallLevel(1),
                    new BallLevel(0),
                    new BallLevel(2),
                    new BallLevel(0),
                    new BallLevel(1),
                    new BallLevel(0),
                    new BallLevel(2),
                    new BallLevel(0),
                    new BallLevel(1),
                    new BallLevel(0),
                    new BallLevel(2),
                    new BallLevel(0),
                    new BallLevel(1),
                    new BallLevel(0),
                    new BallLevel(2),
                    new BallLevel(0),
                    new BallLevel(1),
                    new BallLevel(0),
                    new BallLevel(2),
                    new BallLevel(0),
                    new BallLevel(1),
                    new BallLevel(0),
                    new BallLevel(2),
                    new BallLevel(0),
                    new BallLevel(1),
                    new BallLevel(0),
                    new BallLevel(2),
                    new BallLevel(0),
                    new BallLevel(1),
                    new BallLevel(0),
                    new BallLevel(2),
                    new BallLevel(0),
                    new BallLevel(1),
                    new BallLevel(0),
                    new BallLevel(2),
                    new BallLevel(0),
                    new BallLevel(1),
                    new BallLevel(0),
                    new BallLevel(2),
                },
                Visual = new CampaignLevelVisualDescModel()
                {
                    SceneAddress = "Assets/Scenes/Level_1.unity",
                },
            };
            
            public static readonly CampaignLevelDescModel Level0Difficulty5 = new CampaignLevelDescModel()
            {
                Id = new CampaignLevelDescId(300),
                BallInitialForwardSpeed = 1f,
                BallMaxForwardSpeed = 1f,
                BallForwardAcceleration = 0.0f,
                BallInitialBackwardSpeed = 25f,
                InitialHealth = new Health(3),
                DamagePerBall = new Health(1),
                LimitBallsSpawn = false,
                BallsAmount = 16,
                Goal = new BallLevel(5),
                Visual = new CampaignLevelVisualDescModel()
                {
                    SceneAddress = "Assets/Scenes/Level_0.unity",
                },
            };
            
            public static readonly CampaignLevelDescModel Level1Difficulty5 = new CampaignLevelDescModel()
            {
                Id = new CampaignLevelDescId(400),
                BallInitialForwardSpeed = 1f,
                BallMaxForwardSpeed = 1f,
                BallForwardAcceleration = 0.0f,
                BallInitialBackwardSpeed = 25f,
                InitialHealth = new Health(3),
                DamagePerBall = new Health(1),
                LimitBallsSpawn = false,
                BallsAmount = 16,
                Goal = new BallLevel(5),
                Visual = new CampaignLevelVisualDescModel()
                {
                    SceneAddress = "Assets/Scenes/Level_1.unity",
                },
            };
            
            public static readonly CampaignLevelDescModel Level2Difficulty5 = new CampaignLevelDescModel()
            {
                Id = new CampaignLevelDescId(500),
                BallInitialForwardSpeed = 1f,
                BallMaxForwardSpeed = 1f,
                BallForwardAcceleration = 0.0f,
                BallInitialBackwardSpeed = 25f,
                InitialHealth = new Health(3),
                DamagePerBall = new Health(1),
                LimitBallsSpawn = false,
                BallsAmount = 16,
                Goal = new BallLevel(5),
                Visual = new CampaignLevelVisualDescModel()
                {
                    SceneAddress = "Assets/Scenes/Level_2.unity",
                },
            };
            
            public static readonly CampaignLevelDescModel Level3Difficulty5 = new CampaignLevelDescModel()
            {
                Id = new CampaignLevelDescId(600),
                BallInitialForwardSpeed = 1f,
                BallMaxForwardSpeed = 1f,
                BallForwardAcceleration = 0.0f,
                BallInitialBackwardSpeed = 25f,
                InitialHealth = new Health(3),
                DamagePerBall = new Health(1),
                LimitBallsSpawn = false,
                BallsAmount = 16,
                Goal = new BallLevel(5),
                Visual = new CampaignLevelVisualDescModel()
                {
                    SceneAddress = "Assets/Scenes/Level_3.unity",
                },
            };
            
            public static readonly CampaignLevelDescModel Level4Difficulty5 = new CampaignLevelDescModel()
            {
                Id = new CampaignLevelDescId(700),
                BallInitialForwardSpeed = 1f,
                BallMaxForwardSpeed = 1f,
                BallForwardAcceleration = 0.0f,
                BallInitialBackwardSpeed = 25f,
                InitialHealth = new Health(3),
                DamagePerBall = new Health(1),
                LimitBallsSpawn = false,
                BallsAmount = 16,
                Goal = new BallLevel(5),
                Visual = new CampaignLevelVisualDescModel()
                {
                    SceneAddress = "Assets/Scenes/Level_4.unity",
                },
            };
            
            public static readonly CampaignLevelDescModel Level0Difficulty6 = new CampaignLevelDescModel()
            {
                Id = new CampaignLevelDescId(800),
                BallInitialForwardSpeed = 1f,
                BallMaxForwardSpeed = 1f,
                BallForwardAcceleration = 0.0f,
                BallInitialBackwardSpeed = 25f,
                InitialHealth = new Health(3),
                DamagePerBall = new Health(1),
                LimitBallsSpawn = false,
                BallsAmount = 16,
                Goal = new BallLevel(6),
                Visual = new CampaignLevelVisualDescModel()
                {
                    SceneAddress = "Assets/Scenes/Level_0.unity",
                },
            };
            
            public static readonly CampaignLevelDescModel Level1Difficulty6 = new CampaignLevelDescModel()
            {
                Id = new CampaignLevelDescId(900),
                BallInitialForwardSpeed = 1f,
                BallMaxForwardSpeed = 1f,
                BallForwardAcceleration = 0.0f,
                BallInitialBackwardSpeed = 25f,
                InitialHealth = new Health(3),
                DamagePerBall = new Health(1),
                LimitBallsSpawn = false,
                BallsAmount = 16,
                Goal = new BallLevel(6),
                Visual = new CampaignLevelVisualDescModel()
                {
                    SceneAddress = "Assets/Scenes/Level_1.unity",
                },
            };
            
            public static readonly CampaignLevelDescModel Level2Difficulty6 = new CampaignLevelDescModel()
            {
                Id = new CampaignLevelDescId(1000),
                BallInitialForwardSpeed = 1f,
                BallMaxForwardSpeed = 1f,
                BallForwardAcceleration = 0.0f,
                BallInitialBackwardSpeed = 25f,
                InitialHealth = new Health(3),
                DamagePerBall = new Health(1),
                LimitBallsSpawn = false,
                BallsAmount = 16,
                Goal = new BallLevel(6),
                Visual = new CampaignLevelVisualDescModel()
                {
                    SceneAddress = "Assets/Scenes/Level_2.unity",
                },
            };
            
            public static readonly CampaignLevelDescModel Level3Difficulty6 = new CampaignLevelDescModel()
            {
                Id = new CampaignLevelDescId(1100),
                BallInitialForwardSpeed = 1f,
                BallMaxForwardSpeed = 1f,
                BallForwardAcceleration = 0.0f,
                BallInitialBackwardSpeed = 25f,
                InitialHealth = new Health(3),
                DamagePerBall = new Health(1),
                LimitBallsSpawn = false,
                BallsAmount = 16,
                Goal = new BallLevel(6),
                Visual = new CampaignLevelVisualDescModel()
                {
                    SceneAddress = "Assets/Scenes/Level_3.unity",
                },
            };
            
            public static readonly CampaignLevelDescModel Level4Difficulty6 = new CampaignLevelDescModel()
            {
                Id = new CampaignLevelDescId(1200),
                BallInitialForwardSpeed = 1f,
                BallMaxForwardSpeed = 1f,
                BallForwardAcceleration = 0.0f,
                BallInitialBackwardSpeed = 25f,
                InitialHealth = new Health(3),
                DamagePerBall = new Health(1),
                LimitBallsSpawn = false,
                BallsAmount = 16,
                Goal = new BallLevel(6),
                Visual = new CampaignLevelVisualDescModel()
                {
                    SceneAddress = "Assets/Scenes/Level_4.unity",
                },
            };
            
            public static readonly CampaignLevelDescModel Level0Difficulty7 = new CampaignLevelDescModel()
            {
                Id = new CampaignLevelDescId(1300),
                BallInitialForwardSpeed = 1f,
                BallMaxForwardSpeed = 1f,
                BallForwardAcceleration = 0.0f,
                BallInitialBackwardSpeed = 25f,
                InitialHealth = new Health(3),
                DamagePerBall = new Health(1),
                LimitBallsSpawn = false,
                BallsAmount = 16,
                Goal = new BallLevel(7),
                Visual = new CampaignLevelVisualDescModel()
                {
                    SceneAddress = "Assets/Scenes/Level_0.unity",
                },
            };
            
            public static readonly CampaignLevelDescModel Level1Difficulty7 = new CampaignLevelDescModel()
            {
                Id = new CampaignLevelDescId(1400),
                BallInitialForwardSpeed = 1f,
                BallMaxForwardSpeed = 1f,
                BallForwardAcceleration = 0.0f,
                BallInitialBackwardSpeed = 25f,
                InitialHealth = new Health(3),
                DamagePerBall = new Health(1),
                LimitBallsSpawn = false,
                BallsAmount = 16,
                Goal = new BallLevel(7),
                Visual = new CampaignLevelVisualDescModel()
                {
                    SceneAddress = "Assets/Scenes/Level_1.unity",
                },
            };
            
            public static readonly CampaignLevelDescModel Level2Difficulty7 = new CampaignLevelDescModel()
            {
                Id = new CampaignLevelDescId(1500),
                BallInitialForwardSpeed = 1f,
                BallMaxForwardSpeed = 1f,
                BallForwardAcceleration = 0.0f,
                BallInitialBackwardSpeed = 25f,
                InitialHealth = new Health(3),
                DamagePerBall = new Health(1),
                LimitBallsSpawn = false,
                BallsAmount = 16,
                Goal = new BallLevel(7),
                Visual = new CampaignLevelVisualDescModel()
                {
                    SceneAddress = "Assets/Scenes/Level_2.unity",
                },
            };
            
            public static readonly CampaignLevelDescModel Level3Difficulty7 = new CampaignLevelDescModel()
            {
                Id = new CampaignLevelDescId(1600),
                BallInitialForwardSpeed = 1f,
                BallMaxForwardSpeed = 1f,
                BallForwardAcceleration = 0.0f,
                BallInitialBackwardSpeed = 25f,
                InitialHealth = new Health(3),
                DamagePerBall = new Health(1),
                LimitBallsSpawn = false,
                BallsAmount = 16,
                Goal = new BallLevel(7),
                Visual = new CampaignLevelVisualDescModel()
                {
                    SceneAddress = "Assets/Scenes/Level_3.unity",
                },
            };
            
            public static readonly CampaignLevelDescModel Level4Difficulty7 = new CampaignLevelDescModel()
            {
                Id = new CampaignLevelDescId(1700),
                BallInitialForwardSpeed = 1f,
                BallMaxForwardSpeed = 1f,
                BallForwardAcceleration = 0.0f,
                BallInitialBackwardSpeed = 25f,
                InitialHealth = new Health(3),
                DamagePerBall = new Health(1),
                LimitBallsSpawn = false,
                BallsAmount = 16,
                Goal = new BallLevel(7),
                Visual = new CampaignLevelVisualDescModel()
                {
                    SceneAddress = "Assets/Scenes/Level_4.unity",
                },
            };
            
            public static readonly CampaignLevelDescModel Level0Difficulty8 = new CampaignLevelDescModel()
            {
                Id = new CampaignLevelDescId(1800),
                BallInitialForwardSpeed = 1f,
                BallMaxForwardSpeed = 1f,
                BallForwardAcceleration = 0.0f,
                BallInitialBackwardSpeed = 25f,
                InitialHealth = new Health(3),
                DamagePerBall = new Health(1),
                LimitBallsSpawn = false,
                BallsAmount = 16,
                Goal = new BallLevel(8),
                Visual = new CampaignLevelVisualDescModel()
                {
                    SceneAddress = "Assets/Scenes/Level_0.unity",
                },
            };
            
            public static readonly CampaignLevelDescModel Level1Difficulty8 = new CampaignLevelDescModel()
            {
                Id = new CampaignLevelDescId(1900),
                BallInitialForwardSpeed = 1f,
                BallMaxForwardSpeed = 1f,
                BallForwardAcceleration = 0.0f,
                BallInitialBackwardSpeed = 25f,
                InitialHealth = new Health(3),
                DamagePerBall = new Health(1),
                LimitBallsSpawn = false,
                BallsAmount = 16,
                Goal = new BallLevel(8),
                Visual = new CampaignLevelVisualDescModel()
                {
                    SceneAddress = "Assets/Scenes/Level_1.unity",
                },
            };
            
            public static readonly CampaignLevelDescModel Level2Difficulty8 = new CampaignLevelDescModel()
            {
                Id = new CampaignLevelDescId(2000),
                BallInitialForwardSpeed = 1f,
                BallMaxForwardSpeed = 1f,
                BallForwardAcceleration = 0.0f,
                BallInitialBackwardSpeed = 25f,
                InitialHealth = new Health(3),
                DamagePerBall = new Health(1),
                LimitBallsSpawn = false,
                BallsAmount = 16,
                Goal = new BallLevel(8),
                Visual = new CampaignLevelVisualDescModel()
                {
                    SceneAddress = "Assets/Scenes/Level_2.unity",
                },
            };
            
            public static readonly CampaignLevelDescModel Level3Difficulty8 = new CampaignLevelDescModel()
            {
                Id = new CampaignLevelDescId(2100),
                BallInitialForwardSpeed = 1f,
                BallMaxForwardSpeed = 1f,
                BallForwardAcceleration = 0.0f,
                BallInitialBackwardSpeed = 25f,
                InitialHealth = new Health(3),
                DamagePerBall = new Health(1),
                LimitBallsSpawn = false,
                BallsAmount = 16,
                Goal = new BallLevel(8),
                Visual = new CampaignLevelVisualDescModel()
                {
                    SceneAddress = "Assets/Scenes/Level_3.unity",
                },
            };
            
            public static readonly CampaignLevelDescModel Level4Difficulty8 = new CampaignLevelDescModel()
            {
                Id = new CampaignLevelDescId(2200),
                BallInitialForwardSpeed = 1f,
                BallMaxForwardSpeed = 1f,
                BallForwardAcceleration = 0.0f,
                BallInitialBackwardSpeed = 25f,
                InitialHealth = new Health(3),
                DamagePerBall = new Health(1),
                LimitBallsSpawn = false,
                BallsAmount = 16,
                Goal = new BallLevel(8),
                Visual = new CampaignLevelVisualDescModel()
                {
                    SceneAddress = "Assets/Scenes/Level_4.unity",
                },
            };
            
            public static readonly CampaignLevelDescModel Level0Difficulty9 = new CampaignLevelDescModel()
            {
                Id = new CampaignLevelDescId(2300),
                BallInitialForwardSpeed = 1f,
                BallMaxForwardSpeed = 1f,
                BallForwardAcceleration = 0.0f,
                BallInitialBackwardSpeed = 25f,
                InitialHealth = new Health(3),
                DamagePerBall = new Health(1),
                LimitBallsSpawn = false,
                BallsAmount = 16,
                Goal = new BallLevel(9),
                Visual = new CampaignLevelVisualDescModel()
                {
                    SceneAddress = "Assets/Scenes/Level_0.unity",
                },
            };
            
            public static readonly CampaignLevelDescModel Level1Difficulty9 = new CampaignLevelDescModel()
            {
                Id = new CampaignLevelDescId(2400),
                BallInitialForwardSpeed = 1f,
                BallMaxForwardSpeed = 1f,
                BallForwardAcceleration = 0.0f,
                BallInitialBackwardSpeed = 25f,
                InitialHealth = new Health(3),
                DamagePerBall = new Health(1),
                LimitBallsSpawn = false,
                BallsAmount = 16,
                Goal = new BallLevel(9),
                Visual = new CampaignLevelVisualDescModel()
                {
                    SceneAddress = "Assets/Scenes/Level_1.unity",
                },
            };
            
            public static readonly CampaignLevelDescModel Level2Difficulty9 = new CampaignLevelDescModel()
            {
                Id = new CampaignLevelDescId(2500),
                BallInitialForwardSpeed = 1f,
                BallMaxForwardSpeed = 1f,
                BallForwardAcceleration = 0.0f,
                BallInitialBackwardSpeed = 25f,
                InitialHealth = new Health(3),
                DamagePerBall = new Health(1),
                LimitBallsSpawn = false,
                BallsAmount = 16,
                Goal = new BallLevel(9),
                Visual = new CampaignLevelVisualDescModel()
                {
                    SceneAddress = "Assets/Scenes/Level_2.unity",
                },
            };
            
            public static readonly CampaignLevelDescModel Level3Difficulty9 = new CampaignLevelDescModel()
            {
                Id = new CampaignLevelDescId(2600),
                BallInitialForwardSpeed = 1f,
                BallMaxForwardSpeed = 1f,
                BallForwardAcceleration = 0.0f,
                BallInitialBackwardSpeed = 25f,
                InitialHealth = new Health(3),
                DamagePerBall = new Health(1),
                LimitBallsSpawn = false,
                BallsAmount = 16,
                Goal = new BallLevel(9),
                Visual = new CampaignLevelVisualDescModel()
                {
                    SceneAddress = "Assets/Scenes/Level_3.unity",
                },
            };
            
            public static readonly CampaignLevelDescModel Level4Difficulty9 = new CampaignLevelDescModel()
            {
                Id = new CampaignLevelDescId(2700),
                BallInitialForwardSpeed = 1f,
                BallMaxForwardSpeed = 1f,
                BallForwardAcceleration = 0.0f,
                BallInitialBackwardSpeed = 25f,
                InitialHealth = new Health(3),
                DamagePerBall = new Health(1),
                LimitBallsSpawn = false,
                BallsAmount = 16,
                Goal = new BallLevel(9),
                Visual = new CampaignLevelVisualDescModel()
                {
                    SceneAddress = "Assets/Scenes/Level_4.unity",
                },
            };
            
            public static readonly CampaignLevelDescModel Level0Difficulty10 = new CampaignLevelDescModel()
            {
                Id = new CampaignLevelDescId(2800),
                BallInitialForwardSpeed = 1f,
                BallMaxForwardSpeed = 1f,
                BallForwardAcceleration = 0.0f,
                BallInitialBackwardSpeed = 25f,
                InitialHealth = new Health(3),
                DamagePerBall = new Health(1),
                LimitBallsSpawn = false,
                BallsAmount = 16,
                Goal = new BallLevel(10),
                Visual = new CampaignLevelVisualDescModel()
                {
                    SceneAddress = "Assets/Scenes/Level_0.unity",
                },
            };
            
            public static readonly CampaignLevelDescModel Level1Difficulty10 = new CampaignLevelDescModel()
            {
                Id = new CampaignLevelDescId(2900),
                BallInitialForwardSpeed = 1f,
                BallMaxForwardSpeed = 1f,
                BallForwardAcceleration = 0.0f,
                BallInitialBackwardSpeed = 25f,
                InitialHealth = new Health(3),
                DamagePerBall = new Health(1),
                LimitBallsSpawn = false,
                BallsAmount = 16,
                Goal = new BallLevel(10),
                Visual = new CampaignLevelVisualDescModel()
                {
                    SceneAddress = "Assets/Scenes/Level_1.unity",
                },
            };
            
            public static readonly CampaignLevelDescModel Level2Difficulty10 = new CampaignLevelDescModel()
            {
                Id = new CampaignLevelDescId(3000),
                BallInitialForwardSpeed = 1f,
                BallMaxForwardSpeed = 1f,
                BallForwardAcceleration = 0.0f,
                BallInitialBackwardSpeed = 25f,
                InitialHealth = new Health(3),
                DamagePerBall = new Health(1),
                LimitBallsSpawn = false,
                BallsAmount = 16,
                Goal = new BallLevel(10),
                Visual = new CampaignLevelVisualDescModel()
                {
                    SceneAddress = "Assets/Scenes/Level_2.unity",
                },
            };
            
            public static readonly CampaignLevelDescModel Level3Difficulty10 = new CampaignLevelDescModel()
            {
                Id = new CampaignLevelDescId(3100),
                BallInitialForwardSpeed = 1f,
                BallMaxForwardSpeed = 1f,
                BallForwardAcceleration = 0.0f,
                BallInitialBackwardSpeed = 25f,
                InitialHealth = new Health(3),
                DamagePerBall = new Health(1),
                LimitBallsSpawn = false,
                BallsAmount = 16,
                Goal = new BallLevel(10),
                Visual = new CampaignLevelVisualDescModel()
                {
                    SceneAddress = "Assets/Scenes/Level_3.unity",
                },
            };
            
            public static readonly CampaignLevelDescModel Level4Difficulty10 = new CampaignLevelDescModel()
            {
                Id = new CampaignLevelDescId(3200),
                BallInitialForwardSpeed = 1f,
                BallMaxForwardSpeed = 1f,
                BallForwardAcceleration = 0.0f,
                BallInitialBackwardSpeed = 25f,
                InitialHealth = new Health(3),
                DamagePerBall = new Health(1),
                LimitBallsSpawn = false,
                BallsAmount = 16,
                Goal = new BallLevel(10),
                Visual = new CampaignLevelVisualDescModel()
                {
                    SceneAddress = "Assets/Scenes/Level_4.unity",
                },
            };
            
            public static readonly CampaignLevelDescModel Level0Difficulty11 = new CampaignLevelDescModel()
            {
                Id = new CampaignLevelDescId(3300),
                BallInitialForwardSpeed = 1f,
                BallMaxForwardSpeed = 1f,
                BallForwardAcceleration = 0.0f,
                BallInitialBackwardSpeed = 25f,
                InitialHealth = new Health(3),
                DamagePerBall = new Health(1),
                LimitBallsSpawn = false,
                BallsAmount = 16,
                Goal = new BallLevel(11),
                Visual = new CampaignLevelVisualDescModel()
                {
                    SceneAddress = "Assets/Scenes/Level_0.unity",
                },
            };
            
            public static readonly CampaignLevelDescModel Level1Difficulty11 = new CampaignLevelDescModel()
            {
                Id = new CampaignLevelDescId(3400),
                BallInitialForwardSpeed = 1f,
                BallMaxForwardSpeed = 1f,
                BallForwardAcceleration = 0.0f,
                BallInitialBackwardSpeed = 25f,
                InitialHealth = new Health(3),
                DamagePerBall = new Health(1),
                LimitBallsSpawn = false,
                BallsAmount = 16,
                Goal = new BallLevel(11),
                Visual = new CampaignLevelVisualDescModel()
                {
                    SceneAddress = "Assets/Scenes/Level_1.unity",
                },
            };
            
            public static readonly CampaignLevelDescModel Level2Difficulty11 = new CampaignLevelDescModel()
            {
                Id = new CampaignLevelDescId(3500),
                BallInitialForwardSpeed = 1f,
                BallMaxForwardSpeed = 1f,
                BallForwardAcceleration = 0.0f,
                BallInitialBackwardSpeed = 25f,
                InitialHealth = new Health(3),
                DamagePerBall = new Health(1),
                LimitBallsSpawn = false,
                BallsAmount = 16,
                Goal = new BallLevel(11),
                Visual = new CampaignLevelVisualDescModel()
                {
                    SceneAddress = "Assets/Scenes/Level_2.unity",
                },
            };
            
            public static readonly CampaignLevelDescModel Level3Difficulty11 = new CampaignLevelDescModel()
            {
                Id = new CampaignLevelDescId(3600),
                BallInitialForwardSpeed = 1f,
                BallMaxForwardSpeed = 1f,
                BallForwardAcceleration = 0.0f,
                BallInitialBackwardSpeed = 25f,
                InitialHealth = new Health(3),
                DamagePerBall = new Health(1),
                LimitBallsSpawn = false,
                BallsAmount = 16,
                Goal = new BallLevel(11),
                Visual = new CampaignLevelVisualDescModel()
                {
                    SceneAddress = "Assets/Scenes/Level_3.unity",
                },
            };
            
            public static readonly CampaignLevelDescModel Level4Difficulty11 = new CampaignLevelDescModel()
            {
                Id = new CampaignLevelDescId(3700),
                BallInitialForwardSpeed = 1f,
                BallMaxForwardSpeed = 1f,
                BallForwardAcceleration = 0.0f,
                BallInitialBackwardSpeed = 25f,
                InitialHealth = new Health(3),
                DamagePerBall = new Health(1),
                LimitBallsSpawn = false,
                BallsAmount = 16,
                Goal = new BallLevel(11),
                Visual = new CampaignLevelVisualDescModel()
                {
                    SceneAddress = "Assets/Scenes/Level_4.unity",
                },
            };
            
            public static readonly CampaignLevelDescModel Level0Difficulty12 = new CampaignLevelDescModel()
            {
                Id = new CampaignLevelDescId(3800),
                BallInitialForwardSpeed = 1f,
                BallMaxForwardSpeed = 1f,
                BallForwardAcceleration = 0.0f,
                BallInitialBackwardSpeed = 25f,
                InitialHealth = new Health(3),
                DamagePerBall = new Health(1),
                LimitBallsSpawn = false,
                BallsAmount = 16,
                Goal = new BallLevel(12),
                Visual = new CampaignLevelVisualDescModel()
                {
                    SceneAddress = "Assets/Scenes/Level_0.unity",
                },
            };
            
            public static readonly CampaignLevelDescModel Level1Difficulty12 = new CampaignLevelDescModel()
            {
                Id = new CampaignLevelDescId(3900),
                BallInitialForwardSpeed = 1f,
                BallMaxForwardSpeed = 1f,
                BallForwardAcceleration = 0.0f,
                BallInitialBackwardSpeed = 25f,
                InitialHealth = new Health(3),
                DamagePerBall = new Health(1),
                LimitBallsSpawn = false,
                BallsAmount = 16,
                Goal = new BallLevel(12),
                Visual = new CampaignLevelVisualDescModel()
                {
                    SceneAddress = "Assets/Scenes/Level_1.unity",
                },
            };
            
            public static readonly CampaignLevelDescModel Level2Difficulty12 = new CampaignLevelDescModel()
            {
                Id = new CampaignLevelDescId(4000),
                BallInitialForwardSpeed = 1f,
                BallMaxForwardSpeed = 1f,
                BallForwardAcceleration = 0.0f,
                BallInitialBackwardSpeed = 25f,
                InitialHealth = new Health(3),
                DamagePerBall = new Health(1),
                LimitBallsSpawn = false,
                BallsAmount = 16,
                Goal = new BallLevel(12),
                Visual = new CampaignLevelVisualDescModel()
                {
                    SceneAddress = "Assets/Scenes/Level_2.unity",
                },
            };
            
            public static readonly CampaignLevelDescModel Level3Difficulty12 = new CampaignLevelDescModel()
            {
                Id = new CampaignLevelDescId(4100),
                BallInitialForwardSpeed = 1f,
                BallMaxForwardSpeed = 1f,
                BallForwardAcceleration = 0.0f,
                BallInitialBackwardSpeed = 25f,
                InitialHealth = new Health(3),
                DamagePerBall = new Health(1),
                LimitBallsSpawn = false,
                BallsAmount = 16,
                Goal = new BallLevel(12),
                Visual = new CampaignLevelVisualDescModel()
                {
                    SceneAddress = "Assets/Scenes/Level_3.unity",
                },
            };
            
            public static readonly CampaignLevelDescModel Level4Difficulty12 = new CampaignLevelDescModel()
            {
                Id = new CampaignLevelDescId(4200),
                BallInitialForwardSpeed = 1f,
                BallMaxForwardSpeed = 1f,
                BallForwardAcceleration = 0.0f,
                BallInitialBackwardSpeed = 25f,
                InitialHealth = new Health(3),
                DamagePerBall = new Health(1),
                LimitBallsSpawn = false,
                BallsAmount = 16,
                Goal = new BallLevel(12),
                Visual = new CampaignLevelVisualDescModel()
                {
                    SceneAddress = "Assets/Scenes/Level_4.unity",
                },
            };
        }
    }
}