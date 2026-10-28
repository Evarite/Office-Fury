using NUnit.Framework;
using Office.Economy.Money;

namespace Office.Tests.EditMode
{
    public class MoneyTest
    {
        [Test]
        public void IncreaseBalance()
        {
            var counter = new MoneyCounter();

            bool invoked = false;
            int currentBalance = 0;
            int changedBalance = 0;

            counter.OnValueChanged +=
                (newCount, dif) =>
                {
                    invoked = true;
                    currentBalance = newCount;
                    changedBalance = dif;
                };

            counter.Count += 50;
            counter.Count += 25;

            Assert.AreEqual(75, counter.Count);
            Assert.AreEqual(75, currentBalance);
            Assert.AreEqual(25, changedBalance);
            Assert.IsTrue(invoked);
        }

        [Test]
        public void IsNegativeInvokes()
        {
            var counter = new MoneyCounter();
            bool invoked = false;

            counter.OnNegativeBalance += () => { invoked = true; };
            counter.Count = -50;

            Assert.IsTrue(invoked);
        }
    }
}