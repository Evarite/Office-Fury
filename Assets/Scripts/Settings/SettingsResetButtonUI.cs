using UnityEngine;
using VContainer;

namespace Office.Settings
{
    [AddComponentMenu("Office/Settings/Settings Reset Button UI")]
    public class SettingsResetButtonUI : MonoBehaviour
    {
        [Inject] private SettingsSaveUtil _settingsSaveUtil;
        
        public void Reset() => _settingsSaveUtil.Reset();
    }
}