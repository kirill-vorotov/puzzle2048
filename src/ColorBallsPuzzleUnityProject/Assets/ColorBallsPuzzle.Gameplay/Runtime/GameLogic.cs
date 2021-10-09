using System;
using System.Collections.Generic;
using System.Linq;
using Dreamteck.Splines;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Assertions;

namespace ColorBallsPuzzle.Gameplay
{
    public static class GameLogic
    {
        public static bool IsPlayerAlive(ref GameModel gameModel)
        {
            return gameModel.Health.Value > 0;
        }

        public static void UpdateGameTime(ref GameModel gameModel, float deltaTimeSeconds)
        {
            gameModel.Time += deltaTimeSeconds;
            gameModel.DeltaTime = new GameTime(deltaTimeSeconds);
            gameModel.MovementModel.DamageRollbackTime -= deltaTimeSeconds;
            if (gameModel.MovementModel.DamageRollbackTime < 0f)
            {
                gameModel.MovementModel.DamageRollbackTime = new GameTime(0f);
            }
            gameModel.MovementModel.MatchRollbackTime -= deltaTimeSeconds;
            if (gameModel.MovementModel.MatchRollbackTime < 0f)
            {
                gameModel.MovementModel.MatchRollbackTime = new GameTime(0f);
            }

            gameModel.MovementModel.MatchPauseTime -= deltaTimeSeconds;
            if (gameModel.MovementModel.MatchPauseTime < 0f)
            {
                gameModel.MovementModel.MatchPauseTime = new GameTime(0f);
            }
        }

        public static void UpdateBallsSpeed(ref GameModel gameModel)
        {
            gameModel.MovementModel.CurrentBallSpeedForward += gameModel.GameSettings.BallAccelerationForward * gameModel.DeltaTime.Seconds;
            if (gameModel.MovementModel.CurrentBallSpeedForward > gameModel.GameSettings.BallSpeedForwardLimit)
            {
                gameModel.MovementModel.CurrentBallSpeedForward = gameModel.GameSettings.BallSpeedForwardLimit;
            } 
        }

        public static void DealDamage(ref GameModel gameModel, Health damage)
        {
            gameModel.Health -= damage;
            if (gameModel.Health < 0)
            {
                gameModel.Health = new Health(0);
            }

            gameModel.MovementModel.MovementType = MovementType.Backward;
            var distance = gameModel.GameSettings.RollBackDistance;
            gameModel.MovementModel.DamageRollbackTime = new GameTime(distance / gameModel.GameSettings.BallSpeedBackward);
            gameModel.MovementModel.CurrentBallSpeedForward = gameModel.GameSettings.BallSpeedForward;
        }

        public static bool CanSpawnNewBall(ref GameModel gameModel)
        {
            var ballsLimitReached = gameModel.GameSettings.BallsSettingsModel.UseBallLimit &&
                                    gameModel.NumberOfBallsSpawned >=
                                    gameModel.GameSettings.BallsSettingsModel.BallsLimit;
            return (gameModel.Balls.Count == 0 || gameModel.Balls.Last().CurrentPositionOnPath > gameModel.GameSettings.BallRadius * 2f) && !ballsLimitReached;
        }

        public static void SpawnNewBall(ref GameModel gameModel)
        {
            if (gameModel.BallStack.Count > 0)
            {
                var ball = gameModel.BallStack.Pop();
                gameModel.Balls.Add(new ColorBallModel(ball.Level));
                return;
            }

            BallLevel ballLevel;
            if (gameModel.GameSettings.LevelDescModel.Balls != null && gameModel.NumberOfBallsSpawned < gameModel.GameSettings.LevelDescModel.Balls.Length)
            {
                var index = gameModel.NumberOfBallsSpawned;
                ballLevel = gameModel.GameSettings.LevelDescModel.Balls[index];
            }
            else
            {
                var maxBallLevel = gameModel.HighestBallLevelReached.Value - 1;
                if (maxBallLevel < gameModel.GameSettings.MaxNewBallLevel)
                {
                    maxBallLevel = gameModel.GameSettings.MaxNewBallLevel;
                }
                ballLevel = new BallLevel(gameModel.Rng.Next(0, maxBallLevel + 1));
                if (gameModel.Balls.Count > 0)
                {
                    var lastBallLevel = gameModel.Balls.Last().Level;
                    while (ballLevel == lastBallLevel)
                    {
                        ballLevel = new BallLevel(gameModel.Rng.Next(0, gameModel.GameSettings.MaxNewBallLevel));
                    }
                }
            }
            gameModel.Balls.Add(new ColorBallModel(ballLevel));
            if (ballLevel > gameModel.HighestBallLevelReached)
            {
                gameModel.HighestBallLevelReached = ballLevel;
            }
            gameModel.LastSpawnTime = gameModel.Time;
            ++gameModel.NumberOfBallsSpawned;
        }

        public static bool CanMoveBalls(ref GameModel gameModel)
        {
            return gameModel.Projectiles.Count == 0;
        }

        public static void MoveBalls([NotNull] ref GameModel gameModel)
        {
            if (gameModel.Balls.Count <= 0)
            {
                return;
            }

            if (!CanMoveBalls(ref gameModel))
            {
                return;
            }

            if (gameModel.MovementModel.MatchPauseTime > 0f)
            {
                gameModel.MovementModel.MovementType = MovementType.Stopped;
            }
            else
            {
                gameModel.MovementModel.MovementType = gameModel.MovementModel.DamageRollbackTime > 0f || gameModel.MovementModel.MatchRollbackTime > 0f ? MovementType.Backward : MovementType.Forward;
            }

            switch (gameModel.MovementModel.MovementType)
            {
                case MovementType.Forward:
                {
                    MoveForward(ref gameModel);
                    break;
                }
                case MovementType.Backward:
                {
                    MoveBackward(ref gameModel);
                    break;
                }
                case MovementType.Stopped:
                {
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }

            static void MoveForward(ref GameModel model)
            {
                if (model.Balls.Count == 0)
                {
                    return;
                }
                var lastBall = model.Balls.Last();
                var speedForward = (model.Time < model.StartSpeedUpTime)
                    ? model.MovementModel.CurrentBallSpeedForward * 40f
                    : model.MovementModel.CurrentBallSpeedForward;
                var forwardDelta = speedForward * model.DeltaTime.Seconds;
                var backwardDelta = model.GameSettings.BallSpeedBackward * model.DeltaTime.Seconds;
                lastBall.CurrentPositionOnPath += forwardDelta;
                for (var ballIndex = model.Balls.Count - 1; ballIndex >= 0; --ballIndex)
                {
                    var ball = model.Balls[ballIndex];
                    var prevIndex = ballIndex + 1;
                    if (prevIndex < model.Balls.Count)
                    {
                        var prevBall = model.Balls[prevIndex];
                        var distance = Math.Abs(ball.CurrentPositionOnPath - prevBall.CurrentPositionOnPath);
                        if (distance < model.GameSettings.BallRadius * 2f + backwardDelta)
                        {
                            ball.CurrentPositionOnPath =
                                prevBall.CurrentPositionOnPath + model.GameSettings.BallRadius * 2f;
                        }
                        else
                        {
                            ball.CurrentPositionOnPath -= backwardDelta;
                        }
                    }
                }
            }

            static void MoveBackward(ref GameModel model)
            {
                if (model.Balls.Count == 0)
                {
                    return;
                }
                var firstBall = model.Balls.First();
                var backwardDelta = model.GameSettings.BallSpeedBackward * model.DeltaTime.Seconds;
                firstBall.CurrentPositionOnPath -= backwardDelta;
                for (var ballIndex = 0; ballIndex < model.Balls.Count; ++ballIndex)
                {
                    var ball = model.Balls[ballIndex];
                    var prevIndex = ballIndex - 1;
                    if (prevIndex >= 0)
                    {
                        var prevBall = model.Balls[prevIndex];
                        var distance = Math.Abs(ball.CurrentPositionOnPath - prevBall.CurrentPositionOnPath);
                        if (distance < model.GameSettings.BallRadius * 2f)
                        {
                            ball.CurrentPositionOnPath =
                                prevBall.CurrentPositionOnPath - model.GameSettings.BallRadius * 2f;
                        }
                    }
                }
            }
        }

        public static bool TryToRemoveFirstBalls(ref GameModel gameModel)
        {
            var ballsToRemove = new List<ColorBallModel>();
            
            if (gameModel.Balls.Count == 0)
            {
                return false;
            }

            foreach (var ball in gameModel.Balls)
            {
                if (ball.CurrentPositionOnPath >= gameModel.GameSettings.PathLength)
                {
                    ballsToRemove.Add(ball);
                }
            }

            var damageDealt = ballsToRemove.Count > 0;
            
            foreach (var ballToRemove in ballsToRemove)
            {
                gameModel.Balls.Remove(ballToRemove);
            }
            ballsToRemove.Clear();

            if (damageDealt)
            {
                DealDamage(ref gameModel, gameModel.GameSettings.DamagePerBall);
            }

            return damageDealt;
        }

        public static bool TryToRemoveLastBalls(ref GameModel gameModel)
        {
            var ballsToRemove = new List<ColorBallModel>();
            
            if (gameModel.Balls.Count == 0)
            {
                return false;
            }

            for (var ballIndex = gameModel.Balls.Count - 1; ballIndex >= 0; --ballIndex)
            {
                var ball = gameModel.Balls[ballIndex];
                if (ball.CurrentPositionOnPath <= 0)
                {
                    ballsToRemove.Add(ball);
                }
            }

            var removed = ballsToRemove.Count > 0;
            
            foreach (var ballToRemove in ballsToRemove)
            {
                gameModel.Balls.Remove(ballToRemove);
                gameModel.BallStack.Push(ballToRemove);
            }
            ballsToRemove.Clear();

            return removed;
        }
        
        public static void InsertBall(ref GameModel gameModel, int index, BallLevel level)
        {
            Assert.IsTrue(index >= 0 && index <= gameModel.Balls.Count,
                $"{nameof(index)} {index.ToString()} {nameof(gameModel.Balls.Count)} {gameModel.Balls.Count.ToString()}");
            var tmpBall = index < gameModel.Balls.Count
                ? GetBall(ref gameModel, index)
                : GetBall(ref gameModel, index - 1);
            var positiononOnPath = index < gameModel.Balls.Count
                ? tmpBall.CurrentPositionOnPath
                : tmpBall.CurrentPositionOnPath - gameModel.GameSettings.BallRadius * 2f;
            gameModel.Balls.Insert(index, new ColorBallModel(level, positiononOnPath));
        
            for (var ballIndex = gameModel.Balls.Count - 1; ballIndex >= 0; --ballIndex)
            {
                var ball = gameModel.Balls[ballIndex];
                var prevIndex = ballIndex + 1;
                if (prevIndex < gameModel.Balls.Count)
                {
                    if (ball.CurrentPositionOnPath - gameModel.Balls[prevIndex].CurrentPositionOnPath <
                        gameModel.GameSettings.BallRadius * 2f)
                    {
                        ball.CurrentPositionOnPath = gameModel.Balls[prevIndex].CurrentPositionOnPath +
                                                     gameModel.GameSettings.BallRadius * 2f;
                    }
                }
            }
            gameModel.LastMatchTime = gameModel.Time;
        }
        
        public static int RemoveMatches(ref GameModel gameModel)
        {
            if (!CanRemoveMatches(ref gameModel))
            {
                return -1;
            }
            
            var ballToReplaceIndex = -1;
            for (var ballIndex = 0; ballIndex < gameModel.Balls.Count; ++ballIndex)
            {
                var prevBallIndex = ballIndex - 1;
                if (prevBallIndex >= 0)
                {
                    var ball = gameModel.Balls[ballIndex];
                    var prevBall = gameModel.Balls[prevBallIndex];
                    var distance = prevBall.CurrentPositionOnPath - ball.CurrentPositionOnPath;
                    if (ball.Level == prevBall.Level && distance <= gameModel.GameSettings.BallRadius * 2.01f)
                    {
                        ballToReplaceIndex = prevBallIndex;
                        break;
                    }
                }
            }

            if (ballToReplaceIndex >= 0)
            {
                var ball = GetBall(ref gameModel, ballToReplaceIndex);
                ++ball.Level;
                if (ball.Level > gameModel.HighestBallLevelReached)
                {
                    gameModel.HighestBallLevelReached = ball.Level;
                }
                gameModel.Score += Mathf.CeilToInt((float)Math.Pow(2, ball.Level.Value + 1));
                if (ballToReplaceIndex + 1 < gameModel.Balls.Count)
                {
                    gameModel.Balls.RemoveAt(ballToReplaceIndex + 1);
                }
                
                gameModel.MovementModel.MatchPauseTime = gameModel.GameSettings.MovementPauseAfterBallMatchTime;
                gameModel.MovementModel.MovementType = MovementType.Stopped;
                gameModel.LastMatchTime = gameModel.Time;

                if (gameModel.GameSettings.MatchRollbackTimes.Length > 0)
                {
                    var index = ball.Level < gameModel.GameSettings.MatchRollbackTimes.Length
                        ? ball.Level.Value
                        : gameModel.GameSettings.MatchRollbackTimes.Length - 1;
                    var rollbackTime = gameModel.GameSettings.MatchRollbackTimes[index];
                    if (rollbackTime > 0f)
                    {
                        gameModel.MovementModel.MatchRollbackTime = new GameTime(rollbackTime) + gameModel.GameSettings.MovementPauseAfterBallMatchTime;
                    }
                }
            }

            return ballToReplaceIndex;
        }

        public static void SpawnProjectile([NotNull] ref GameModel gameModel)
        {
            if (!ReadyToSpawnProjectile(ref gameModel))
            {
                return;
            }

            var projectileLevel = new BallLevel(0);
            if (gameModel.GameSettings.LevelDescModel.Projectiles != null &&
                gameModel.NumberOfProjectilesSpawned < gameModel.GameSettings.LevelDescModel.Projectiles.Length)
            {
                var index = gameModel.NumberOfProjectilesSpawned;
                projectileLevel = gameModel.GameSettings.LevelDescModel.Projectiles[index];
            }
            else
            {
                var maxBallLevel = gameModel.HighestBallLevelReached.Value - 3;
                if (maxBallLevel < gameModel.GameSettings.MaxNewBallLevel)
                {
                    maxBallLevel = gameModel.GameSettings.MaxNewBallLevel;
                }
                projectileLevel = new BallLevel(gameModel.Rng.Next(0, maxBallLevel + 1));
            }

            gameModel.ProjectileLevel = projectileLevel;
            gameModel.HasProjectile = true;
            ++gameModel.NumberOfProjectilesSpawned;
        }

        public static void LaunchProjectile([NotNull] ref GameModel gameModel, Vector2 direction)
        {
            if (!ReadyToLaunchProjectile(ref gameModel))
            {
                return;
            }
            
            var projectile = new ProjectileModel(gameModel.ProjectileLevel, gameModel.GameSettings.ProjectileSpawnPosition,
                direction.normalized * gameModel.GameSettings.ProjectileSpeed, gameModel.Time);
            gameModel.Projectiles.Add(projectile);
            gameModel.HasProjectile = false;
        }
        
        public static void UpdateProjectiles([NotNull] ref GameModel gameModel)
        {
            var projectilesToRemove = new List<ProjectileModel>();
            
            for (var projectileIndex = 0; projectileIndex < gameModel.Projectiles.Count; ++projectileIndex)
            {
                var projectile = gameModel.Projectiles[projectileIndex];
                gameModel.Projectiles[projectileIndex] = new ProjectileModel(projectile.Level, projectile.StartPosition, projectile.Velocity, projectile.LaunchTime);
                var pos = GetProjectilePosition(projectile, gameModel.Time);
                pos = new Vector2(Math.Abs(pos.x), Math.Abs(pos.y));
                if (pos.x >= gameModel.GameSettings.ProjectileBounds.x ||
                    pos.y >= gameModel.GameSettings.ProjectileBounds.y)
                {
                    projectilesToRemove.Add(projectile);
                }

                if (gameModel.Time.Seconds >= projectile.LaunchTime.Seconds + 30f / gameModel.GameSettings.ProjectileSpeed)
                {
                    projectilesToRemove.Add(projectile);
                }
            }

            foreach (var projectileToRemove in projectilesToRemove)
            {
                gameModel.Projectiles.Remove(projectileToRemove);
            }
            projectilesToRemove.Clear();
        }

        public static Vector2 GetProjectilePosition(ProjectileModel projectile, GameTime time)
        {
            return projectile.StartPosition + projectile.Velocity * (time - projectile.LaunchTime).Seconds;
        }
        
        public static bool CheckProjectileCollisions([NotNull] ref GameModel gameModel, ProjectileModel projectile, SplineComputer splineComputer, ref ColorBallCollision result)
        {
            var ballDiameterSqr = gameModel.GameSettings.BallRadius * gameModel.GameSettings.BallRadius * 4f;
            var projectilePosition = GetProjectilePosition(projectile, gameModel.Time);

            for (var ballIndex = 0; ballIndex < gameModel.Balls.Count; ++ballIndex)
            {
                var ballWorldPos = GetBallWorldPosition(ref gameModel, ballIndex, splineComputer);
                if (!((ballWorldPos - projectilePosition).sqrMagnitude <= ballDiameterSqr))
                {
                    continue;
                }
                result = new ColorBallCollision(projectile, ballIndex);
                return true;
            }

            return false;
        }

        public static bool CheckAllProjectilesCollisions(ref GameModel gameModel, SplineComputer splineComputer)
        {
            ColorBallCollision collision = default;
            var collided = false;
            ProjectileModel projectileToRemove = default;
            foreach (var projectile in gameModel.Projectiles)
            {
                if (!CheckProjectileCollisions(ref gameModel, projectile, splineComputer, ref collision))
                {
                    continue;
                }

                collided = true;
                var ballDirection = GetBallWorldDirection(ref gameModel, collision.BallIndex, splineComputer);
                var collisionNormal = GetProjectilePosition(projectile, gameModel.Time) - GetBallWorldPosition(ref gameModel, collision.BallIndex, splineComputer);
                var ballRight = Vector3.Cross(new Vector3(ballDirection.x, 0, ballDirection.y), Vector3.up);
                var cross = Vector3.Cross(new Vector3(collisionNormal.x, 0, collisionNormal.y), ballRight);
                var insertionIndex = cross.y < 0f ? collision.BallIndex : collision.BallIndex + 1;
                if (insertionIndex > gameModel.Balls.Count)
                {
                    insertionIndex = gameModel.Balls.Count;
                }
                InsertBall(ref gameModel, insertionIndex, collision.Projectile.Level);
                projectileToRemove = collision.Projectile;
                break;
            }

            if (collided)
            {
                gameModel.Projectiles.Remove(projectileToRemove);
            }
            return collided;
        }
        
        public static bool ReadyToSpawnProjectile([NotNull] ref GameModel gameModel)
        {
            return gameModel.Projectiles.Count == 0 && !gameModel.HasProjectile;
        }

        public static bool ReadyToLaunchProjectile([NotNull] ref GameModel gameModel)
        {
            return gameModel.HasProjectile;
        }

        public static ColorBallModel GetBall(ref GameModel gameModel, int ballIndex)
        {
            Assert.IsTrue(ballIndex >= 0 && ballIndex < gameModel.Balls.Count,
                $"{nameof(ballIndex)} {ballIndex.ToString()} {nameof(gameModel.Balls.Count)} {gameModel.Balls.Count.ToString()}");
            return gameModel.Balls[ballIndex];
        }
        
        public static float GetBallPositionOnPath(ref GameModel gameModel, int ballIndex)
        {
            return GetBall(ref gameModel, ballIndex).CurrentPositionOnPath;
        }

        public static Vector2 GetBallWorldPosition(ref GameModel gameModel, int ballIndex, SplineComputer splineComputer)
        {
            var dist = GetBallPositionOnPath(ref gameModel, ballIndex);
            var percent = splineComputer.Travel(0d, dist);
            var tmpPos = splineComputer.EvaluatePosition(percent);
            return new Vector2(tmpPos.x, tmpPos.z);
        }

        public static Vector2 GetBallWorldDirection(ref GameModel gameModel, int ballIndex, SplineComputer splineComputer)
        {
            var dist = GetBallPositionOnPath(ref gameModel, ballIndex);
            var percent = splineComputer.Travel(0d, dist);
            var sample = splineComputer.Evaluate(percent);
            return new Vector2(sample.forward.x, sample.forward.z);
        }

        public static bool IsPlayerWon(ref GameModel gameModel)
        {
            // var ballsLimitReached = gameModel.GameSettings.BallsSettingsModel.UseBallLimit &&
            //                         gameModel.NumberOfBallsSpawned >=
            //                         gameModel.GameSettings.BallsSettingsModel.BallsLimit;
            // return ballsLimitReached && gameModel.Balls.Count <= 1;
            var goal = gameModel.GameSettings.LevelDescModel.Goal;
            return gameModel.Balls.Any(x => x.Level == goal);
        }

        public static bool IsPlayerLost(ref GameModel gameModel)
        {
            return !IsPlayerAlive(ref gameModel);
        }

        public static bool CanRemoveMatches(ref GameModel gameModel)
        {
            return gameModel.Time > gameModel.LastMatchTime + gameModel.GameSettings.PauseBetweenMatches;
        }
    }
}