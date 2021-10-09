using System;
using UnityEngine;

namespace ColorBallsPuzzle.Gameplay.Views
{
    public class SceneController : MonoBehaviour
    {
        protected GameContext GameContext;
        
        public void Initialize(GameContext gameContext)
        {
            GameContext = gameContext;
            OnInitialize();
        }
        
        protected virtual void OnInitialize()
        {
            // No op.
        }
    }
}