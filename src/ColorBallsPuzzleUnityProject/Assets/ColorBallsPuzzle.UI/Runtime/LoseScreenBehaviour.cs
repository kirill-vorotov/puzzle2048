using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace ColorBallsPuzzle.UI
{
    public class LoseScreenBehaviour : ScreenBehaviour
    {
        [SerializeField] private Button _buttonRestart;
        
        private Sequence _appearanceSequence;

        protected override async UniTask OnShow(CancellationToken token)
        {
            if (_appearanceSequence != null)
            {
                _appearanceSequence.Kill();
            }
            _appearanceSequence = DOTween.Sequence();
                
            ScreenLayout.RectTransform.localScale = new Vector3(0.2f, 0.2f, 1f);
            _buttonRestart.interactable = false;
            _buttonRestart.image.rectTransform.localScale = new Vector3(0.2f, 0.2f, 1f);
            _buttonRestart.image.enabled = false;
            
            _appearanceSequence.Append(ScreenLayout.RectTransform.DOScale(new Vector3(1.2f, 1.2f, 1f), 0.2f));
            _appearanceSequence.Append(ScreenLayout.RectTransform.DOScale(new Vector3(1f, 1f, 1f), 0.1f));
            await UniTask.Delay(TimeSpan.FromSeconds(0.3f));
            _buttonRestart.image.enabled = true;
            await _buttonRestart.image.rectTransform.DOScale(new Vector3(1f, 1f, 1f), 0.2f).ToUniTask(cancellationToken: token);
            _buttonRestart.interactable = true;
        }

        protected override UniTask OnHide(CancellationToken token)
        {
            try
            {
                if (_appearanceSequence != null)
                {
                    _appearanceSequence.Kill();
                }

                _appearanceSequence = null;
                _buttonRestart.interactable = false;
                return UniTask.CompletedTask;
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                throw;
            }
        }
        
        protected override void OnEnable()
        {
            _buttonRestart.onClick.AddListener(OnContinueClick);
        }
        
        protected override void OnDisable()
        {
            _buttonRestart.onClick.RemoveListener(OnContinueClick);
        }
        
        private void OnContinueClick()
        {
            UiSceneController.StartGame();
        }
    }
}