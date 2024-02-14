using UnityEngine;
using UnityEngine.UI;

namespace TestUIProject.UI
{
    /// <summary>
    /// Ёлемент
    /// </summary>
    [RequireComponent(typeof(Button))]
    public class Element : MonoBehaviour, IElementRemoved
    {
        private Button _button = default;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(Removed);
        }

        private void OnDestroy() => _button.onClick.RemoveListener(Removed);

        public void Removed()
        {
            //NOTE: Eсли есть возможность добавлени€ runtime, можно выключить объект и использовать в дальнейшем (PoolObject)
            //gameObject.SetActive(false);

            Destroy(gameObject);
        }

    }
}