using UnityEngine;

namespace ColorBallsPuzzle.Gameplay
{
    public readonly struct ColorBallCollision
    {
        public readonly ProjectileModel Projectile;
        public readonly int BallIndex;

        public ColorBallCollision(ProjectileModel projectile, int ballIndex)
        {
            Projectile = projectile;
            BallIndex = ballIndex;
        }
    }
}