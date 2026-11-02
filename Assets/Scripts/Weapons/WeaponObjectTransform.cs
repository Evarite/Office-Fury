using System;
using UnityEngine;

namespace Office.Weapons
{
    [Serializable]
    public class WeaponObjectTransform
    {
        [SerializeField] private Transform _parentObject;
        [SerializeField] private Transform _strikingPoint;
        [SerializeField] private Transform _pivotPoint;

        public WeaponObjectTransform(Transform strikingPoint, Transform pivotPoint,
            Transform parentObject)
        {
            _strikingPoint = strikingPoint;
            _pivotPoint = pivotPoint;
            _parentObject = parentObject;
        }

        public Transform ParentObject => _parentObject;
        public Transform StrikingPoint => _strikingPoint;
        public Transform PivotPoint => _pivotPoint;
    }
}