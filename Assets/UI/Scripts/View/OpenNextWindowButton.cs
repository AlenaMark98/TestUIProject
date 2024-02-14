using UnityEngine;
using UnityEngine.UI;

namespace TestUIProject.UI
{
    /// <summary>
    /// Кнопка открытия следующего окна
    /// </summary>
    [RequireComponent(typeof(Button))]
    public class OpenNextWindowButton : MonoBehaviour
    {
        [SerializeField] private WindowSO _window = default;

        private Button _button = default;

        private ManagerWindow _managerWindow = default;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(WindowStateChanged);
        }

        private void Start() => _managerWindow = ManagerWindow.Instance;

        private void OnDestroy() => _button.onClick.RemoveListener(WindowStateChanged);

        private void WindowStateChanged() => _managerWindow.SwitchWindow(_window.ID);
    }
}