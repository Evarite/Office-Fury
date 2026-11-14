using System;
using TMPro;
using UnityEngine;
using VContainer;

namespace Office.Economy.SkillPoints
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    [AddComponentMenu("Office/Economy/Skill Points/Skill Points UI")]
    public class SkillPointsUI : MonoBehaviour
    {
        [Inject] private SkillPointsCounter _skillPointsCounter;
        
        private TextMeshProUGUI _text;

        private void Awake() => _text = GetComponent<TextMeshProUGUI>();

        private void OnEnable() => _skillPointsCounter.OnValueChanged += OnValueChanged;

        private void OnDisable() => _skillPointsCounter.OnValueChanged -= OnValueChanged;

        private void OnValueChanged(int newValue) => _text.text = newValue.ToString();
    }
}