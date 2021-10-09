using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace ColorBallsPuzzle.UI
{
    public class WinScreenBehaviour : ScreenBehaviour
    {
        [SerializeField] private Image _star1;
        [SerializeField] private Image _star2;
        [SerializeField] private Image _star3;
        [SerializeField] private Button _buttonContinue;

        private Sequence _appearanceSequence;

        protected override async UniTask OnShow(CancellationToken token)
        {
            try
            {
                if (_appearanceSequence != null)
                {
                    _appearanceSequence.Kill();
                }
                _appearanceSequence = DOTween.Sequence();
                
                ScreenLayout.RectTransform.localScale = new Vector3(0.2f, 0.2f, 1f);
                _star1.rectTransform.localScale = new Vector3(0.2f, 0.2f, 1f);
                _star2.rectTransform.localScale = new Vector3(0.2f, 0.2f, 1f);
                _star3.rectTransform.localScale = new Vector3(0.2f, 0.2f, 1f);
                _star1.enabled = false;
                _star2.enabled = false;
                _star3.enabled = false;
                _buttonContinue.interactable = false;
                _buttonContinue.image.rectTransform.localScale = new Vector3(0.2f, 0.2f, 1f);
                _buttonContinue.image.enabled = false;
                
                _appearanceSequence.Append(ScreenLayout.RectTransform.DOScale(new Vector3(1.2f, 1.2f, 1f), 0.2f));
                _appearanceSequence.Append(ScreenLayout.RectTransform.DOScale(new Vector3(1f, 1f, 1f), 0.1f));
                await UniTask.Delay(TimeSpan.FromSeconds(0.3f));
                _star1.enabled = true;
                await _star1.rectTransform.DOScale(new Vector3(1f, 1f, 1f), 0.2f).ToUniTask(cancellationToken: token);
                await UniTask.Delay(TimeSpan.FromSeconds(0.1f));
                _star2.enabled = true;
                await _star2.rectTransform.DOScale(new Vector3(1f, 1f, 1f), 0.2f).ToUniTask(cancellationToken: token);
                await UniTask.Delay(TimeSpan.FromSeconds(0.2f));
                _star3.enabled = true;
                await _star3.rectTransform.DOScale(new Vector3(1f, 1f, 1f), 0.2f).ToUniTask(cancellationToken: token);
                await UniTask.Delay(TimeSpan.FromSeconds(0.3f));
                _buttonContinue.image.enabled = true;
                await _buttonContinue.image.rectTransform.DOScale(new Vector3(1f, 1f, 1f), 0.2f).ToUniTask(cancellationToken: token);
                _buttonContinue.interactable = true;
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                throw;
            }
        }
        
        protected override async UniTask OnHide(CancellationToken token)
        {
            try
            {
                if (_appearanceSequence != null)
                {
                    _appearanceSequence.Kill();
                }

                _appearanceSequence = null;
                _buttonContinue.interactable = false;
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                throw;
            }
        }

        protected override void OnEnable()
        {
            _buttonContinue.onClick.AddListener(OnContinueClick);
        }
        
        protected override void OnDisable()
        {
            _buttonContinue.onClick.RemoveListener(OnContinueClick);
        }
        
        private void OnContinueClick()
        {
            UiSceneController.StartGame();
        }
    }
}