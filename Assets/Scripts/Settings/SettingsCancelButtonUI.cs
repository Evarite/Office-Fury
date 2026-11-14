using Office.Managers;
using UnityEngine;
using VContainer;

namespace Office.Settings
{
    [AddComponentMenu("Office/Settings/Settings Cancel Button UI")]
    public class SettingsCancelButtonUI : MonoBehaviour
    {
        [Inject] private SettingsSaveUtil _settingsSaveUtil;
        [Inject] private SettingsManager _settingsManager;
        
        public void CancelChanges()
        {
            if (_settingsManager.Settings.IsDirty)
                _ = _settingsSaveUtil.CancelChanges();
        }
    }
}