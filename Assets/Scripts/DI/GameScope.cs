using Office.AimIndicator;
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
    [AddComponentMenu("Office/DI/Game Scope")]
    public class GameScope : LifetimeScope
    {
        [Space(20)]
        [SerializeField] private PoolData[] _poolDatas;
        [SerializeField] private Transform _aimIndicatorTransform;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_poolDatas);

            //Managers
            builder.Register<EquipmentManager>(Lifetime.Scoped);
            builder.Register<AimManager>(Lifetime.Scoped)
                .WithParameter(_aimIndicatorTransform);
            
            //AimIndicator
            builder.RegisterComponentInHierarchy<AimIndicatorController>();
            builder.RegisterEntryPoint<AimIndicatorSwitch>();

            //Pooling
            builder.RegisterEntryPoint<PoolService>().AsSelf();

            //Controls
            builder.RegisterComponentInHierarchy<AttackControls>();
            builder.RegisterComponentInHierarchy<AimControls>();

            //Money
            builder.RegisterComponentInHierarchy<MoneyUI>();
            builder.RegisterComponentInHierarchy<MoneyChangeEffectUI>();

            //Weapons
            builder.RegisterComponentInHierarchy<WeaponFollow>();
            builder.RegisterComponentInHierarchy<WeaponAttack>();
        }
    }
}