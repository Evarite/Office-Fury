using UnityEngine;

namespace Office.Settings
{
    [System.Serializable]
    public class GameSettings
    {
        [SerializeField] private float _mouseSensitivity = 1f;

        public bool IsDirty { get; set; }

        public float MouseSensitivity
        {
            get => _mouseSensitivity;
            set
            {
                _mouseSensitivity = value;
                IsDirty = true;
            }
        }
    }
}
