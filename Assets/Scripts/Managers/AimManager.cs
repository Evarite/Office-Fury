using JetBrains.Annotations;
using UnityEngine;

namespace Office.Managers
{
    [UsedImplicitly]
    public class AimManager
    {
        public AimManager(Transform aimIndicatorTransform) =>
            AimIndicatorTransform = aimIndicatorTransform;

        public Transform AimIndicatorTransform { get; }
        
        public float SphereRadius => AimIndicatorTransform.localScale.x / 2;
    }
}