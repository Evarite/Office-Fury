using System;
using UnityEngine;

namespace Office.Weapons
{
    [Serializable]
    public class WeaponObjectTransform
    {
        [SerializeField] private Transform _strikingPoint;
        [SerializeField] private Transform _pivotPoint;

        public WeaponObjectTransform(Transform strikingPoint, Transform pivotPoint)
        {
            _strikingPoint = strikingPoint;
            _pivotPoint = pivotPoint;
        }

        public Transform StrikingPoint => _strikingPoint;
        public Transform PivotPoint => _pivotPoint;
    }
}