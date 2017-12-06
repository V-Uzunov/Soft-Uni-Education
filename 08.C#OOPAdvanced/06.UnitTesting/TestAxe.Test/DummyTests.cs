namespace TestAxe.Test
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class DummyTests
    {
        private const int AxeAttack = 2;
        private const int AxeDurability = 2;
        private const int DummyHealth = 20;
        private const int DummyXP = 20;
        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void TestInit()
        {
            this.axe = new Axe(AxeAttack, AxeDurability);
            this.dummy = new Dummy(DummyHealth, DummyXP);
        }

        [Test]
        public void DummyLosesHealthIfAttacked()
        {            
            dummy.TakeAttack(AxeAttack);

            Assert.AreEqual(this.dummy.Health, DummyHealth-AxeAttack);
        }

        [Test]
        public void DeadDummyThrowExeptionIfAttacked()
        {
            dummy.TakeAttack(this.dummy.Health);

            var ex = Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(this.dummy.Health));

            Assert.AreEqual("Dummy is dead.", ex.Message);
        }

        [Test]
        public void DeadDummyCanGiveExpirience()
        {            
            dummy.TakeAttack(this.dummy.Health);

            Assert.That(this.dummy.GiveExperience(), Is.EqualTo(this.dummy.GiveExperience()));
        }

        [Test]
        public void AliveDummyCannotGiveExpirience()
        {
            dummy.TakeAttack(AxeAttack);

            var ex = Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
            Assert.AreEqual("Dummy is not dead.", ex.Message);
        }
    }
}
