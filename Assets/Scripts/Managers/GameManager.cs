using Office.Input;
using Office.Weapons;
using UnityEngine;

namespace Office.Managers
{
    /// <summary>
    /// This class manages global game data and provides access to it.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        private Weapon _currentWeapon;
        private InputActions _inputSystem;

        public Weapon CurrentWeapon => _currentWeapon;
        public InputActions InputSystem => _inputSystem;

        private void Awake()
        {
            SingletonSetup();

            _inputSystem = new();
            _inputSystem.Enable();
        }

        private void SingletonSetup()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        public void RegisterWeapon(Weapon newWeapon) => _currentWeapon = newWeapon;
    }
}