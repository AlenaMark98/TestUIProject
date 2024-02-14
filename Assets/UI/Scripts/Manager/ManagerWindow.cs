using System.Collections.Generic;
using UnityEngine;

namespace TestUIProject.UI
{
    /// <summary>
    /// ћенеджер окон
    /// </summary>
    public class ManagerWindow : MonoBehaviour
    {
        /// <summary>
        /// —сылка на экземпл€р класса ManagerWindow
        /// </summary>
        public static ManagerWindow Instance;
        
        [SerializeField] private List<WindowSO> _listAllWindowSO = default;
        [SerializeField] private WindowSO _windowDefalt = default;

        /// <summary>
        /// —сылка на все Window в сцене
        /// </summary>
        public IReadOnlyDictionary<string, Window> ListWindowInScene => _listWindowInScene;
        /// <summary>
        /// —сылка на текущее открытое окно
        /// </summary>
        public Window CurrentOpenWindow => _currentOpenWindow;

        private Dictionary<string, Window> _listWindowInScene = new Dictionary<string, Window>();
        private Window _currentOpenWindow = default;

        private void Awake()
        {
            Instance = this;

            InstantiateWindow(_windowDefalt);
        }

        private void InstantiateWindow(WindowSO _windowSO)
        {
            GameObject _gameObject = Instantiate(_windowSO.PrefabWindow, transform);
            Window _window = _gameObject.GetComponent<Window>() == null ? _gameObject.AddComponent<Window>() : _gameObject.GetComponent<Window>();
            _window.ID = _windowSO.ID;

            _currentOpenWindow = _window;
            _listWindowInScene.Add(_currentOpenWindow.ID, _currentOpenWindow);
        }

        /// <summary>
        /// ѕереключить окно на выбранный
        /// </summary>
        /// <param name="_idWindowOpen"> id окна дл€ открыти€ </param>
        public void SwitchWindow(string _idWindowOpen)
        {
            if (_listWindowInScene.ContainsKey(_idWindowOpen))
            {
                foreach (var _windowinSene in _listWindowInScene)
                {
                    _currentOpenWindow = _idWindowOpen == _windowinSene.Key ? _windowinSene.Value : _currentOpenWindow;                    
                    _windowinSene.Value.gameObject.SetActive(_idWindowOpen == _windowinSene.Key);
                }
            }
            else
            {
                foreach (var _windowInSene in _listWindowInScene)
                {
                    _windowInSene.Value.gameObject.SetActive(false);
                }

                foreach (var _window in _listAllWindowSO)
                {
                    if (_idWindowOpen == _window.ID)
                    {
                        InstantiateWindow(_window);
                    }
                }
            }
            
        }
    }
}