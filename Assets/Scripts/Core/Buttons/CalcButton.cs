using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Core.Buttons
{
    public class CalcButton : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private Color _activeColor;
        [SerializeField] private Color _inactiveColor;
        [SerializeField] private Image _backImage;
        private bool _isInteractable = true;

        public void OnPointerDown(PointerEventData eventData)
        {
            Click();
        }

        public event Action<CalcButton> Clicked;

        private void Click()
        {
            if (!_isInteractable)
                return;
            
            Clicked?.Invoke(this);
        }

        public void SetInteractable(bool interactable)
        {
            _isInteractable = interactable;
            _backImage.color = interactable ? _activeColor : _inactiveColor;
        }
    }
}