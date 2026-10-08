using Office.Controls;
using Office.Currency.Money;
using Office.Managers;
using VContainer;
using VContainer.Unity;

namespace Office.DI
{
    /// <summary>
    /// Configuration class for dependency injection.
    /// </summary>
    public class GameScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<InputManager>(Lifetime.Singleton);
            builder.Register<EquipmentManager>(Lifetime.Singleton);
            builder.Register<SettingsManager>(Lifetime.Singleton);
            builder.Register<MoneyCounter>(Lifetime.Singleton);

            builder.RegisterComponentInHierarchy<AttackControls>();
            builder.RegisterComponentInHierarchy<AimControls>();
            builder.RegisterComponentInHierarchy<MoneyCounterUI>();
        }
    }
}