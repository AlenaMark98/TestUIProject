using UnityEngine;

namespace TestUIProject.UI
{
    /// <summary>
    /// Даннные окна
    /// </summary>
    [CreateAssetMenu(fileName = "Window", menuName = "TestUIProject/WindowSO", order = 51)]
    public class WindowSO : ScriptableObject
    {
        [SerializeField] private string _id = default;
        [SerializeField] private GameObject _prefabWindow = default;

        /// <summary>
        /// ID окна
        /// </summary>
        public string ID => _id;
        /// <summary>
        /// Префаб окна
        /// </summary>
        public GameObject PrefabWindow => _prefabWindow;
    }
}