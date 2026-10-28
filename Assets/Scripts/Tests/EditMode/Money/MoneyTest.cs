using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Office.Currency.Money;

namespace Office.Tests.EditMode
{
    public class MoneyTest
    {
        [Test]
        public void IncreaseBalance()
        {
            var counter = new MoneyCounter();
            counter.Count += 50;
            
            Assert.AreEqual(50, counter.Count);
        }
    }
}
