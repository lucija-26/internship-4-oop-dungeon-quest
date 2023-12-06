
namespace DungeonQuest.Domain.Repositories.Monster
{
    using DungeonQuest.Domain.Repositories.Hero;

    public class Brute : Monster
    {
        Random random = new Random();

        public Brute(string name, double hp, double damage, double xp, bool isStunned) : base(hp, damage, xp, isStunned)
        {
            Name = name;
            HealthPoints = random.Next(50, 80);
            Damage = random.Next(30, 80);
            ExperienceValue = random.Next(30, 60);
            IsStunned = isStunned;
        }

        public override void Attack(Hero hero)
        {
            Random random = new Random();
            double chance = random.NextDouble();

            if (chance > 0.6)
            {
                Console.WriteLine($"{this.Name} is using brute force to attack!");
                double damageStrongAttack = hero.HealthPoints * 0.2;
                hero.HealthPoints -= damageStrongAttack;

                if (hero.HealthPoints < 0)
                {
                    hero.HealthPoints = 0;
                }

            }
            else
            {
                base.Attack(hero);
            }


        }
    }
}
