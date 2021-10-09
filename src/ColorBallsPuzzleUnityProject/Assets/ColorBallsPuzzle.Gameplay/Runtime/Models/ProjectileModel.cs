using System;
using UnityEngine;

namespace ColorBallsPuzzle.Gameplay
{
    public readonly struct ProjectileModel : IEquatable<ProjectileModel>
    {
        public readonly BallLevel Level;
        public readonly Vector2 StartPosition;
        public readonly Vector2 Velocity;
        public readonly GameTime LaunchTime;

        public ProjectileModel(BallLevel level, Vector2 startPosition, Vector2 velocity, GameTime launchTime)
        {
            Level = level;
            StartPosition = startPosition;
            Velocity = velocity;
            LaunchTime = launchTime;
        }

        public bool Equals(ProjectileModel other)
        {
            return Level == other.Level && StartPosition.Equals(other.StartPosition) && Velocity.Equals(other.Velocity) && LaunchTime.Equals(other.LaunchTime);
        }

        public override bool Equals(object obj)
        {
            return obj is ProjectileModel other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Level.GetHashCode();
                hashCode = (hashCode * 397) ^ StartPosition.GetHashCode();
                hashCode = (hashCode * 397) ^ Velocity.GetHashCode();
                hashCode = (hashCode * 397) ^ LaunchTime.GetHashCode();
                return hashCode;
            }
        }
    }
}