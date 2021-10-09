using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace ColorBallsPuzzle.UI
{
    public class LoadingScreenBehaviour : ScreenBehaviour
    {
        protected override async UniTask OnShow(CancellationToken token)
        {
            try
            {
                var width = ScreenLayout.RectTransform.rect.width;
                ScreenLayout.RectTransform.anchoredPosition = new Vector2(width, ScreenLayout.RectTransform.anchoredPosition.y);
                await ScreenLayout.RectTransform.DOAnchorPosX(0, 0.15f).WithCancellation(token);
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
    }
}