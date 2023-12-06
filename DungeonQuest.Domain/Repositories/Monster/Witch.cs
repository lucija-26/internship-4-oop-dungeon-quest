

namespace DungeonQuest.Domain.Repositories.Monster
{
    using DungeonQuest.Domain.Repositories.Hero;
    using DungeonQuest.Domain.Repositories.Monster;


    public class Witch : Monster
    {
        public bool SpecialAttack { get; set; }

        Random random = new Random();

        public Witch(string name, double hp, double damage, double xp, bool isStunned) : base(hp, damage, xp, isStunned)
        {
            Name = name;
            HealthPoints = random.Next(20, 100);
            Damage = random.Next(20, 80);
            ExperienceValue = random.Next(50, 80);
            SpecialAttack = false;
        }
        public override void Attack(Hero hero)
        {

            double chance = random.NextDouble();

            if (chance < 0.2)
            {
                UseSpecialPower(hero);
                SpecialAttack = true;
            }
            else
            {
                base.Attack(hero);
            }
        }

        private void UseSpecialPower(Hero hero)
        {
            HealthPoints = random.Next(1, 101);
            hero.HealthPoints = random.Next(1, 101);
        }

        public void SpecialAttackMonsters(List<Monster> monsters)
        {
            if (SpecialAttack)
            {
                foreach (var monster in monsters)
                {
                    monster.HealthPoints = random.Next(1, 101);
                }
            }
        }

        public void SpawnNewMonsters()
        {
            if (HealthPoints == 0)
            {
                double randomHealth = random.Next(2, 25);
                double randomExperience = random.Next(2, 25);
                double randomDamage = random.Next(2, 25);
                new Goblin("goblin", randomHealth, randomExperience, randomDamage, false);
                new Brute("brute", randomDamage, randomHealth, randomExperience, false);
            }
        }
    }
}
