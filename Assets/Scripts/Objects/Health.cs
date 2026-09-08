using UnityEngine;

namespace Office.Objects
{
    public class Health : MonoBehaviour
    {
        private float _health;
        public float HP => _health;

        public void TakeDamage(float damage) => _health -= damage;
    }
}