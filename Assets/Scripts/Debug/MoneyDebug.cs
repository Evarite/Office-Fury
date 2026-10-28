#if UNITY_EDITOR
using System.Collections;
using Office.Economy.Money;
using UnityEngine;
using VContainer;

namespace Office.Debugging
{
    [AddComponentMenu("Office/Debug/Money Debug")]
    public class MoneyDebug : MonoBehaviour
    {
        [Inject] private MoneyCounter _counter;

        public void OnEnable()
        {
            StartCoroutine(IncreaseMoneyValue());
            StartCoroutine(DecreaseMoneyValue());
        }

        private void OnDisable() => StopAllCoroutines();

        private IEnumerator IncreaseMoneyValue()
        {
            while (true)
            {
                yield return new WaitForSeconds(3f);
                _counter.Count += 10;
            }
        }

        private IEnumerator DecreaseMoneyValue()
        {
            while (true)
            {
                _counter.Count -= 10;
                yield return new WaitForSeconds(2f);
            }
        }
    }
}
#endif