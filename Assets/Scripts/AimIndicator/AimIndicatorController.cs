using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Office.AimIndicator
{
    [RequireComponent(typeof(DecalProjector))]
    [AddComponentMenu("Office/Aim Indicator/Aim Indicator Controller")]
    public class AimIndicatorController : MonoBehaviour
    {
        private const float MaterialRingRadius = 0.5f;

        private static readonly int s_outerRadiusId = Shader.PropertyToID("_OuterRadius");
        private static readonly int s_innerRadiusId = Shader.PropertyToID("_InnerRadius");
        private static readonly int s_ringColorId = Shader.PropertyToID("_RingColor");
        private static readonly int s_dashCountId = Shader.PropertyToID("_DashCount");
        private static readonly int s_dashFillId = Shader.PropertyToID("_DashFill");

        [SerializeField] private float _projectionDepth = 5f;

        private DecalProjector _decalProjector;
        private Material _instance;
        private Material _sourceMaterial;

        private void Awake() => _decalProjector = GetComponent<DecalProjector>();

        private void OnDestroy()
        {
            if (_instance != null)
                Destroy(_instance);
        }

        public void Apply(AimIndicatorData data)
        {
            if (_sourceMaterial != data.Material)
            {
                if (_instance != null)
                    Destroy(_instance);

                _sourceMaterial = data.Material;
                _instance = new(data.Material);
                _decalProjector.material = _instance;
            }

            float diameter = data.OuterRadius * 2f;
            _decalProjector.size = new(diameter, diameter, _projectionDepth);
            _decalProjector.pivot = new(0f, 0f, _projectionDepth * 0.5f);

            float innerRadius = data.InnerRadius / data.OuterRadius * MaterialRingRadius;

            _instance.SetFloat(s_outerRadiusId, MaterialRingRadius);
            _instance.SetFloat(s_innerRadiusId, innerRadius);
            _instance.SetColor(s_ringColorId, data.Color);
            _instance.SetFloat(s_dashCountId, data.DashCount);
            _instance.SetFloat(s_dashFillId, data.DashFill);
        }
    }
}