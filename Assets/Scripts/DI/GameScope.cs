using Office.Controls;
using Office.Currency.Money;
using Office.Managers;
using Office.Pooling;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Office.DI
{
    /// <summary>
    ///     Configuration class for dependency injection.
    /// </summary>
    [AddComponentMenu("Office/DI/GameScope")]
    public class GameScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            //Managers
            builder.Register<InputManager>(Lifetime.Singleton);
            builder.Register<EquipmentManager>(Lifetime.Singleton);
            builder.Register<SettingsManager>(Lifetime.Singleton);
            
            //Pooling
            builder.RegisterEntryPoint<PoolService>().AsSelf();
            
            //Controls
            builder.RegisterComponentInHierarchy<AttackControls>();
            builder.RegisterComponentInHierarchy<AimControls>();
            
            //Money
            builder.Register<MoneyCounter>(Lifetime.Singleton);
            builder.RegisterComponentInHierarchy<MoneyCounterUI>();
            builder.RegisterComponentInHierarchy<MoneyChangeEffect>();
        }
    }
}