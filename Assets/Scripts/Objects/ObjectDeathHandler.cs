using UnityEngine;

namespace Office.Objects
{
    public class ObjectDeathHandler : MonoBehaviour, IDeathHandler
    {
        public void Die() => Destroy(gameObject);
    }
}