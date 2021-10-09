using System;
using MessagePack;

namespace ColorBallsPuzzle.Gameplay
{
    [MessagePackObject]
    public readonly struct DescriptionsVersion : IEquatable<DescriptionsVersion>
    {
        [Key(0)]
        public readonly int Version;

        public DescriptionsVersion(int version)
        {
            Version = version;
        }

        public bool Equals(DescriptionsVersion other) => Version == other.Version;

        public override bool Equals(object obj) => obj is DescriptionsVersion other && Equals(other);

        public override int GetHashCode() => Version;

        public static bool operator ==(DescriptionsVersion a, DescriptionsVersion b) => a.Equals(b);
        public static bool operator !=(DescriptionsVersion a, DescriptionsVersion b) => !a.Equals(b);
    }
}