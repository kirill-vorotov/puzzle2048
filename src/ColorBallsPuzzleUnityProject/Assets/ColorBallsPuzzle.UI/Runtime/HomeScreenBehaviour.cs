using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace ColorBallsPuzzle.UI
{
    public class HomeScreenBehaviour : ScreenBehaviour
    {
        [SerializeField] private Button _buttonStart;
        private Sequence _sequence;
        
        protected override async UniTask OnShow(CancellationToken token)
        {
            try
            {
                var width = ScreenLayout.RectTransform.rect.width;
                ScreenLayout.RectTransform.anchoredPosition = new Vector2(width, ScreenLayout.RectTransform.anchoredPosition.y);
                await ScreenLayout.RectTransform.DOAnchorPosX(0, 0.15f).WithCancellation(token);

                _buttonStart.interactable = true;
                StartButtonAnimation();
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
                if (_sequence != null)
                {
                    _sequence.Kill();
                }
                _sequence = null;
                
                _buttonStart.interactable = false;
                ScreenLayout.RectTransform.anchoredPosition = new Vector2(0, ScreenLayout.RectTransform.anchoredPosition.y);
                var width = ScreenLayout.RectTransform.rect.width;
                await ScreenLayout.RectTransform.DOAnchorPosX(-width, 0.15f).WithCancellation(token);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                throw;
            }
        }

        protected override void OnEnable()
        {
            _buttonStart.onClick.AddListener(OnButtonStartClick);
        }

        protected override void OnDisable()
        {
            _buttonStart.onClick.RemoveListener(OnButtonStartClick);
        }

        protected override void OnInitialize()
        {
            
        }

        private void OnButtonStartClick()
        {
            UiSceneController.StartGame().Forget();
        }

        private void StartButtonAnimation()
        {
            if (_sequence != null)
            {
                _sequence.Kill();
            }
            _sequence = DOTween.Sequence();
            _sequence.Append(_buttonStart.GetComponent<RectTransform>()
                .DOPunchScale(new Vector3(0.2f, 0.2f, 1f), 0.2f, 2, 1f)).SetLoops(-1, LoopType.Restart);
            _sequence.PrependInterval(2f);
        }
    }
}