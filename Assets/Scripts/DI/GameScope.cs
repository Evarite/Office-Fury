using Office.Controls;
using Office.Economy.Money;
using Office.Managers;
using Office.Pooling;
using Office.Weapons;
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
        [Space(20)] [SerializeField] private PoolData[] _poolDatas;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_poolDatas);

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
            builder.RegisterComponentInHierarchy<MoneyUI>();
            builder.RegisterComponentInHierarchy<MoneyChangeEffectUI>();

            //Weapons
            builder.RegisterComponentInHierarchy<WeaponFollow>();
            builder.RegisterComponentInHierarchy<WeaponAttack>();
        }
    }
}