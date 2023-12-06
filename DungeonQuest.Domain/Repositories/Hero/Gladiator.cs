

namespace DungeonQuest.Domain.Repositories.Hero
{
    using DungeonQuest.Domain.Repositories.Monster;
    using System.Threading;
    using static System.Net.Mime.MediaTypeNames;

    public class Gladiator : Hero
    {
        public bool IsInRage { get; private set; }

        public Gladiator(string name, double initialHealthPoints, double damage, double experience) : base(name, initialHealthPoints)
        {
            Damage = damage;
            Experience = experience;
            IsInRage = false;
        }

        public void AttackWithRage(Monster monster)
        {
            if (IsInRage)
            {
                double damageDealt = Damage * 2;
                double rageCost = HealthPoints * 0.15;
                HealthPoints -= rageCost;
                IsInRage = false;
                monster.TakeDamage(damageDealt);
                return;
            }
            Attack(monster);
        }

        public void ActivateRage()
        {
            IsInRage = true;
        }
    }
}
