

namespace DungeonQuest.Domain.Repositories.Monster
{
    using DungeonQuest.Domain.Repositories.Hero;

    public class Goblin : Monster
    {
        Random random = new Random();
        public Goblin(string name, double hp, double damage, double xp, bool isStunned) : base(hp, damage, xp, isStunned)
        {
            Name = name;
            HealthPoints = random.Next(5, 25);
            Damage = random.Next(5, 25);
            ExperienceValue = random.Next(10, 25);
            IsStunned = isStunned;
        }

        public override void Attack(Hero hero)
        {
            base.Attack(hero);
        }
        public override void TakeDamage(double damage)
        {
            base.TakeDamage(damage);
        }
    }
}
