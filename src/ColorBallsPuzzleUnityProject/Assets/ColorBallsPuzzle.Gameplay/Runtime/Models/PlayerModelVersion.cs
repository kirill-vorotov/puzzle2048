using System;
using MessagePack;

namespace ColorBallsPuzzle.Gameplay
{
    [MessagePackObject]
    public readonly struct PlayerModelVersion : IEquatable<PlayerModelVersion>
    {
        [Key(0)] public readonly short Major;
        [Key(1)] public readonly short Minor;
        [Key(2)] public readonly short Patch;

        public PlayerModelVersion(short major, short minor, short patch)
        {
            Major = major;
            Minor = minor;
            Patch = patch;
        }

        public bool Equals(PlayerModelVersion other) =>
            Major == other.Major && Minor == other.Minor && Patch == other.Patch;

        public override bool Equals(object obj) => obj is PlayerModelVersion other && Equals(other);
        
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Major.GetHashCode();
                hashCode = (hashCode * 397) ^ Minor.GetHashCode();
                hashCode = (hashCode * 397) ^ Patch.GetHashCode();
                return hashCode;
            }
        }

        public static PlayerModelVersion Parse(string version)
        {
            var strings = version.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (strings.Length < 3)
            {
                throw new ArgumentException($"Invalid version format: {version}");
            }

            if (!short.TryParse(strings[0], out var major))
            {
                throw new ArgumentException($"Invalid version format: {version}");
            }
            if (!short.TryParse(strings[1], out var minor))
            {
                throw new ArgumentException($"Invalid version format: {version}");
            }
            if (!short.TryParse(strings[2], out var patch))
            {
                throw new ArgumentException($"Invalid version format: {version}");
            }

            return new PlayerModelVersion(major, minor, patch);
        }

        public static bool operator ==(PlayerModelVersion a, PlayerModelVersion b) => a.Equals(b);
        public static bool operator !=(PlayerModelVersion a, PlayerModelVersion b) => !a.Equals(b);

        public static bool operator >(PlayerModelVersion a, PlayerModelVersion b)
        {
            if (a.Major > b.Major)
            {
                return true;
            }

            if (a.Minor > b.Minor)
            {
                return true;
            }

            return a.Patch > b.Patch;
        }

        public static bool operator <(PlayerModelVersion a, PlayerModelVersion b)
        {
            if (a.Major < b.Major)
            {
                return true;
            }

            if (a.Minor < b.Minor)
            {
                return true;
            }

            return a.Patch < b.Patch;
        }
    }
}