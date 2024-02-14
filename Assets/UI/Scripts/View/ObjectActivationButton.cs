using UnityEngine;
using UnityEngine.UI;

namespace TestUIProject.UI
{
    /// <summary>
    /// Кнопка включения объекта
    /// </summary>
    [RequireComponent(typeof(Button))]
    public class ObjectActivationButton : MonoBehaviour
    {
        [SerializeField] private GameObject _objectActive = default;
        [SerializeField] private ObjectState _state = default;

        private Button _button = default;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(ActivateObject);
        }

        private void OnDestroy() => _button.onClick.RemoveListener(ActivateObject);

        private void ActivateObject() => _objectActive.SetActive(_state == ObjectState.Open);

    }
}
