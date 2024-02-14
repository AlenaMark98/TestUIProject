using UnityEngine;

namespace TestUIProject.UIExtension
{
    /// <summary>
    /// Установить зону для безрамочных экранов
    /// </summary>
    [RequireComponent(typeof(RectTransform))]
    public class SetSafeArea : MonoBehaviour
    {
        private RectTransform _rectTransform = default;
        private Rect _safeArea = default;

        private Vector2 _anchorMin = default;
        private Vector2 _anchorMax = default;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            UpdateSafeArea();
        }

        private void UpdateSafeArea()
        {
            _safeArea = Screen.safeArea;

            _anchorMin = _safeArea.position;
            _anchorMax = _anchorMin + _safeArea.size;

            _anchorMin.x /= Screen.width;
            _anchorMin.y /= Screen.height;
            _anchorMax.x /= Screen.width;
            _anchorMax.y /= Screen.height;

            _rectTransform.anchorMin = _anchorMin;
            _rectTransform.anchorMax = _anchorMax;
        }
    }
}

