using Office.Weapons;
using UnityEngine;

namespace Office.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        private Weapon _currentWeapon;

        public Weapon CurrentWeapon { get => _currentWeapon; set => _currentWeapon = value; }

        private void Awake() => SingletonSetup();

        private void SingletonSetup()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }
    }
}