using UnityEngine;
using VContainer;

namespace Office.Settings
{
    [AddComponentMenu("Office/Settings/Settings Apply Button UI")]
    public class SettingsApplyButtonUI : MonoBehaviour
    {
        [Inject] private SettingsSaveUtil _settingsSaveUtil;
        
        public void Apply() => _ = _settingsSaveUtil.Save();
    }
}