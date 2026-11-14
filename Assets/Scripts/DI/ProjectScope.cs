using Office.Economy.Money;
using Office.Managers;
using Office.SaveSystem.Data;
using Office.Settings;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Office.DI
{
    [AddComponentMenu("Office/DI/Project Scope")]
    public class ProjectScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            //Managers
            builder.Register<SettingsManager>(Lifetime.Singleton);
            builder.Register<InputManager>(Lifetime.Singleton);
            
            //Money
            builder.Register<MoneyCounter>(Lifetime.Singleton);
            
            //Settings
            builder.RegisterEntryPoint<SettingsSaveUtil>().AsSelf();
        }
    }
}