using UnityEngine;

namespace Office.AimIndicator
{
    [RequireComponent(typeof(Renderer))]
    [AddComponentMenu("Office/Aim Indicator/Aim Indicator Controller")]
    public class AimIndicatorController : MonoBehaviour
    {
        private const float MaterialRingRadius = 0.5f;

        private static readonly int s_outerRadiusId = Shader.PropertyToID("_OuterRadius");
        private static readonly int s_innerRadiusId = Shader.PropertyToID("_InnerRadius");
        private static readonly int s_ringColorId = Shader.PropertyToID("_RingColor");
        private static readonly int s_dashCountId = Shader.PropertyToID("_DashCount");
        private static readonly int s_dashFillId = Shader.PropertyToID("_DashFill");

        private MaterialPropertyBlock _materialPropertyBlock;
        private Renderer _renderer;

        private void Awake()
        {
            _renderer = GetComponent<Renderer>();
            _materialPropertyBlock = new MaterialPropertyBlock();
        }

        public void Apply(AimIndicatorData data)
        {
            if (_renderer.sharedMaterial != data.Material)
                _renderer.sharedMaterial = data.Material;

            float scale = data.OuterRadius * 2f;
            transform.localScale = new Vector3(scale, scale, 1f);

            float innerRadius = data.InnerRadius / data.OuterRadius * MaterialRingRadius;

            _renderer.GetPropertyBlock(_materialPropertyBlock);
            _materialPropertyBlock.SetFloat(s_outerRadiusId, MaterialRingRadius);
            _materialPropertyBlock.SetFloat(s_innerRadiusId, innerRadius);
            _materialPropertyBlock.SetColor(s_ringColorId, data.Color);
            _materialPropertyBlock.SetFloat(s_dashCountId, data.DashCount);
            _materialPropertyBlock.SetFloat(s_dashFillId, data.DashFill);
            _renderer.SetPropertyBlock(_materialPropertyBlock);
        }
    }
}