using System;
using MessagePack;

namespace ColorBallsPuzzle.Gameplay
{
    [MessagePackObject]
    public readonly struct Health : IEquatable<Health>
    {
        [Key(0)]
        public readonly int Value;

        public Health(int value)
        {
            Value = value;
        }

        public bool Equals(Health other) => Value == other.Value;

        public override bool Equals(object obj) => obj is Health other && Equals(other);

        public override int GetHashCode() => Value;

        public static bool operator ==(Health a, Health b) => a.Equals(b);
        public static bool operator ==(Health a, int b) => a.Value.Equals(b);
        public static bool operator !=(Health a, Health b) => !a.Equals(b);
        public static bool operator !=(Health a, int b) => !a.Value.Equals(b);
        public static bool operator >(Health a, Health b) => a.Value > b.Value;
        public static bool operator >(Health a, int b) => a.Value > b;
        public static bool operator <(Health a, Health b) => a.Value < b.Value;
        public static bool operator <(Health a, int b) => a.Value < b;
        public static bool operator >=(Health a, Health b) => a.Value >= b.Value;
        public static bool operator >=(Health a, int b) => a.Value >= b;
        public static bool operator <=(Health a, Health b) => a.Value <= b.Value;
        public static bool operator <=(Health a, int b) => a.Value <= b;
        public static Health operator +(Health a, Health b) => new Health(a.Value + b.Value);
        public static Health operator +(Health a, int b) => new Health(a.Value + b);
        public static Health operator -(Health a, Health b) => new Health(a.Value - b.Value);
        public static Health operator -(Health a, int b) => new Health(a.Value - b);
        public static Health operator -(Health value) => new Health(-value.Value);
    }
}