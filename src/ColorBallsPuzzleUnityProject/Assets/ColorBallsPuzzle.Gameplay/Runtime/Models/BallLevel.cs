using System;
using MessagePack;

namespace ColorBallsPuzzle.Gameplay
{
    [MessagePackObject]
    public readonly struct BallLevel : IEquatable<BallLevel>
    {
        [Key(0)]
        public readonly int Value;

        public BallLevel(int value)
        {
            Value = value;
        }

        public bool Equals(BallLevel other) => Value == other.Value;

        public override bool Equals(object obj) => obj is BallLevel other && Equals(other);

        public override int GetHashCode() => Value;

        public static bool operator ==(BallLevel a, BallLevel b) => a.Equals(b);
        public static bool operator ==(BallLevel a, int b) => a.Value.Equals(b);
        public static bool operator !=(BallLevel a, BallLevel b) => !a.Equals(b);
        public static bool operator !=(BallLevel a, int b) => !a.Value.Equals(b);
        public static bool operator >(BallLevel a, BallLevel b) => a.Value > b.Value;
        public static bool operator >(BallLevel a, int b) => a.Value > b;
        public static bool operator <(BallLevel a, BallLevel b) => a.Value < b.Value;
        public static bool operator <(BallLevel a, int b) => a.Value < b;
        public static bool operator >=(BallLevel a, BallLevel b) => a.Value >= b.Value;
        public static bool operator >=(BallLevel a, int b) => a.Value >= b;
        public static bool operator <=(BallLevel a, BallLevel b) => a.Value <= b.Value;
        public static bool operator <=(BallLevel a, int b) => a.Value <= b;
        public static BallLevel operator +(BallLevel a, BallLevel b) => new BallLevel(a.Value + b.Value);
        public static BallLevel operator +(BallLevel a, int b) => new BallLevel(a.Value + b);
        public static BallLevel operator ++(BallLevel a) => new BallLevel(a.Value + 1);
        public static BallLevel operator -(BallLevel a, BallLevel b) => new BallLevel(a.Value - b.Value);
        public static BallLevel operator -(BallLevel a, int b) => new BallLevel(a.Value - b);
        public static BallLevel operator -(BallLevel a) => new BallLevel(-a.Value);
        public static BallLevel operator --(BallLevel a) => new BallLevel(a.Value - 1);
    }
}