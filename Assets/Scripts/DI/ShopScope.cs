using Office.Economy.SkillPoints;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Office.DI
{
    [AddComponentMenu("Office/DI/Shop Menu")]
    public class ShopScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            //SkillPoints
            builder.Register<SkillPointsCounter>(Lifetime.Scoped);
        }
    }
}