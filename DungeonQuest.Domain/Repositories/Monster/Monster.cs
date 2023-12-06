
namespace DungeonQuest.Domain.Repositories.Monster
{
    using DungeonQuest.Domain.Repositories.Hero;

    public class Monster
    {
        public double HealthPoints { get; set; }
        public double Damage { get; set; }
        public string Name { get; set; }
        public double ExperienceValue { get; set; }
        public bool IsStunned { get; set; }
        public bool IsDead { get; set; }
        public double MaxHealthPoints { get; internal set; }
        public Monster(double healthPoints, double damage, double experienceValue, bool isStunned)
        {
            HealthPoints = healthPoints;
            MaxHealthPoints = healthPoints;
            Damage = damage;
            ExperienceValue = experienceValue;
            IsStunned = isStunned;
            IsDead = false;
        }


        public virtual void TakeDamage(double damage)
        {
            HealthPoints -= damage;
            if (HealthPoints < 0)
            {
                HealthPoints = 0;
                IsDead = true;
            }
        }


        public void Stun()
        {
            IsStunned = true;
        }

        public void DisplayStatus()
        {
            Console.WriteLine($"{Name}: HP({HealthPoints}), Damage({Damage})");
        }


        public bool IsDefeated()
        {
            if (HealthPoints == 0)
                return true;
            else
                return false;
        }

        public virtual void Attack(Hero hero)
        {
            hero.HealthPoints -= Damage;
            if (hero.HealthPoints <= 0)
            {
                hero.HealthPoints = 0;
            }
            Console.WriteLine("(MONSTER) Preformed attack!");
        }
    }
}
