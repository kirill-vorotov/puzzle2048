using System;
using MessagePack;

namespace ColorBallsPuzzle.Gameplay
{
    [MessagePackObject]
    public readonly struct CampaignLevelDescId : IEquatable<CampaignLevelDescId>
    {
        [Key(0)]
        public readonly int Value;

        public CampaignLevelDescId(int value)
        {
            Value = value;
        }

        public static CampaignLevelDescId Parse(string value)
        {
            return new CampaignLevelDescId(int.Parse(value));
        }

        public bool Equals(CampaignLevelDescId other) => Value == other.Value;

        public override bool Equals(object obj) => obj is CampaignLevelDescId other && Equals(other);

        public override int GetHashCode() => Value;
    }
}