using MessagePack;

namespace ColorBallsPuzzle.Gameplay
{
    [MessagePackObject]
    public class CampaignLevelDescModel
    {
        [Key("id")]
        public CampaignLevelDescId Id;
        [Key("init_fwd_spd")]
        public float BallInitialForwardSpeed;
        [Key("max_fwd_spd")]
        public float BallMaxForwardSpeed;
        [Key("fwd_acceleration")]
        public float BallForwardAcceleration;
        [Key("init_back_spd")]
        public float BallInitialBackwardSpeed;
        [Key("init_health")]
        public Health InitialHealth;
        [Key("dmg_per_ball")]
        public Health DamagePerBall;
        [Key("limit_balls_spawn")]
        public bool LimitBallsSpawn;
        [Key("balls_amount")]
        public int BallsAmount;
        [Key("goal")]
        public BallLevel Goal;
        [Key("balls")]
        public BallLevel[] Balls;
        [Key("projectiles")]
        public BallLevel[] Projectiles;
        [Key("max_projectile_level")]
        public BallLevel MaxProjectileLevel;
        [Key("visual")]
        public CampaignLevelVisualDescModel Visual;
    }
}