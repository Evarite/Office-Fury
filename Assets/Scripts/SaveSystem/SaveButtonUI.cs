using Office.Managers;
using UnityEngine;
using VContainer;

namespace Office.SaveSystem
{
    [AddComponentMenu("Office/Save System/Save Button UI")]
    public class SaveButtonUI : MonoBehaviour
    {
        [Inject] private SaveManager _saveManager;

        public void Save() => _ = _saveManager.Save();
    }
}