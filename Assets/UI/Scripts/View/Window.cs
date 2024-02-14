using System;
using UnityEngine;

namespace TestUIProject.UI
{
    /// <summary>
    /// Окно
    /// </summary>
    public class Window : MonoBehaviour
    {
        /// <summary>
        /// Изменен ID окна
        /// </summary>
        public event Action OnWindowIDChanged = delegate { };

        private string _id = default;

        /// <summary>
        /// ID окна
        /// </summary>
        public string ID
        {
            get => _id;
            set 
            {
                if (value != null && value != ID)
                {
                    _id = value;
                    OnWindowIDChanged();
                }
            }
        }
    }
}