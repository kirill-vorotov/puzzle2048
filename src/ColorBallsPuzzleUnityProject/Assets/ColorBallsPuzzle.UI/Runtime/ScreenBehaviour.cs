using System;
using System.Threading;
using ColorBallsPuzzle.Gameplay;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ColorBallsPuzzle.UI
{
    public class ScreenBehaviour : UIBehaviour
    {
        private CancellationTokenSource _cts;
        
        [SerializeField] protected Canvas Canvas;
        [SerializeField] protected CanvasScaler canvasScaler;
        [SerializeField] protected CanvasGroup CanvasGroup;
        [SerializeField] protected ScreenLayout ScreenLayout;
        [SerializeField] protected Camera ScreenCamera;
        
        protected GameContext GameContext;
        protected UISceneController UiSceneController;
        
        public void Initialize(GameContext gameContext, UISceneController uiSceneController)
        {
            Cancel();
            GameContext = gameContext;
            UiSceneController = uiSceneController;
            OnInitialize();
        }

        public UniTask Show()
        {
            try
            {
                Cancel();
                Canvas.enabled = true;
                _cts = new CancellationTokenSource();
                return OnShow(_cts.Token);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                throw;
            }
        }
        
        public async UniTask Hide()
        {
            try
            {
                Cancel();
                _cts = new CancellationTokenSource();
                if (Canvas.isActiveAndEnabled)
                {
                    await OnHide(_cts.Token);
                }
                Canvas.enabled = false;
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                throw;
            }
        }

        public void Cancel()
        {
            _cts?.Cancel();
            _cts = null;
        }

        protected virtual void OnInitialize()
        {
            // No op.
        }

        protected virtual UniTask OnShow(CancellationToken token)
        {
            return UniTask.CompletedTask;
        }
        
        protected virtual UniTask OnHide(CancellationToken token)
        {
            return UniTask.CompletedTask;
        }

        protected override void OnDestroy()
        {
            Cancel();
        }
    }
}