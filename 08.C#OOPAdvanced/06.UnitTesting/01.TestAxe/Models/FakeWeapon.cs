namespace Skeleton.Models
{
    using System;

    public class FakeWeapon : IWeapon
    {
        private int attackPoints;
        private int durabilityPoints;

        public FakeWeapon(int attack, int durability)
        {
            this.attackPoints = attack;
            this.durabilityPoints = durability;
        }
        public void Attack(ITarget target)
        {
            if (this.durabilityPoints <= 0)
            {
                throw new InvalidOperationException("FakeWeapon is broken.");
            }

            target.TakeAttack(this.attackPoints);
            this.durabilityPoints -= 1;
        }

        public int AttackPoints
        {
            get { return this.attackPoints; }
        }

        public int DurabilityPoints
        {
            get { return this.durabilityPoints; }
        }
    }
}
