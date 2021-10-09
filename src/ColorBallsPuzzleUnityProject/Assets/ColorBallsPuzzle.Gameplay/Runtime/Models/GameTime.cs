using System;

namespace ColorBallsPuzzle.Gameplay
{
    public readonly struct GameTime : IEquatable<GameTime>
    {
        public readonly float Seconds;

        public GameTime(float seconds)
        {
            Seconds = seconds;
        }
        
        public bool Equals(GameTime other) => Seconds.Equals(other.Seconds);

        public override bool Equals(object obj) => obj is GameTime other && Equals(other);

        public override int GetHashCode() => Seconds.GetHashCode();

        public static bool operator ==(GameTime a, GameTime b) => a.Equals(b);
        public static bool operator !=(GameTime a, GameTime b) => !a.Equals(b);
        public static bool operator >(GameTime a, GameTime b) => a.Seconds > b.Seconds;
        public static bool operator >(GameTime a, float b) => a.Seconds > b;
        public static bool operator <(GameTime a, GameTime b) => a.Seconds < b.Seconds;
        public static bool operator <(GameTime a, float b) => a.Seconds < b;
        public static bool operator >=(GameTime a, GameTime b) => a.Seconds >= b.Seconds;
        public static bool operator >=(GameTime a, float b) => a.Seconds >= b;
        public static bool operator <=(GameTime a, GameTime b) => a.Seconds <= b.Seconds;
        public static bool operator <=(GameTime a, float b) => a.Seconds <= b;
        public static GameTime operator +(GameTime a, GameTime b) => new GameTime(a.Seconds + b.Seconds);
        public static GameTime operator +(GameTime a, float b) => new GameTime(a.Seconds + b);
        public static GameTime operator -(GameTime a, GameTime b) => new GameTime(a.Seconds - b.Seconds);
        public static GameTime operator -(GameTime a, float b) => new GameTime(a.Seconds - b);
        public static GameTime operator -(GameTime value) => new GameTime(-value.Seconds);
        public static GameTime operator *(GameTime a, float b) => new GameTime(a.Seconds * b);
        public static GameTime operator *(float a, GameTime b) => new GameTime(a * b.Seconds);
        public static GameTime operator /(GameTime a, float b) => new GameTime(a.Seconds / b);
    }
}