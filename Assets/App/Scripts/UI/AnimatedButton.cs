using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;
using Game.Audio;

namespace Game.UI
{
    public class AnimatedButton : MonoBehaviour, IPointerDownHandler
    {
        [field: SerializeField] public Button Button { get; set; }

        private Tween _activeTween;

        private void OnDestroy()
        {
            transform.DOKill();
        }

        private void OnDisable()
        {
            if (_activeTween != null)
            {
                _activeTween.Kill();
                _activeTween = null;
            }
        }

        public void AnimateScale()
        {
            if (_activeTween != null) return;
            transform.localScale = Vector3.one;
            _activeTween = transform.DOScale(1.07f, 0.45f).SetEase(Ease.OutSine)
                .SetLoops(2, LoopType.Yoyo).OnComplete(() => _activeTween = null);
        }

        public void OnClickButton()
        {
            if (!Button.interactable || !Button.image.raycastTarget) return;

            AudioManager.Instance.PlayButtonSound();

            transform.DOKill();
            transform.localScale = Vector3.one;
            transform.DOScale(1.07f, 0.1f).SetEase(Ease.OutSine).SetLoops(2, LoopType.Yoyo);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            OnClickButton();
        }
    }
}
