namespace DungeonQuest.Domain.Repositories.Hero
{
    using DungeonQuest.Domain.Repositories.Monster;
    using System.Threading;


    public class Hero
    {
        public string Name { get; set; }
        public double HealthPoints { get; set; }
        public double MaxHealthPoints { get; set; }
        public double Experience { get; set; }
        public double Damage { get; set; }
        public int victories { get; set; }
        public Hero(string name, double initialHealthPoints)
        {
            Name = name;
            HealthPoints = initialHealthPoints;
            MaxHealthPoints = initialHealthPoints;
            Experience = 0;
            Damage = 10;
            victories = 0;
        }

        public void LevelUp(double experienceGained, double healthIncrease, double damageIncrease)
        {
            Experience += experienceGained;
            if (Experience >= 100)
            {
                IncreaseLevel(healthIncrease, damageIncrease);
                Experience -= 100;
            }
        }
        private void IncreaseLevel(double healthIncrease, double damageIncrease)
        {
            MaxHealthPoints += healthIncrease;
            HealthPoints = MaxHealthPoints;
            Damage += damageIncrease;
        }

        public void DisplayStatus()
        {
            Console.WriteLine($"{Name}: HP({HealthPoints}/{MaxHealthPoints}), Damage({Damage}), XP({Experience}), Victories({victories})");
        }
        public void Attack(Monster monster)
        {
            monster.TakeDamage(Damage);
        }

        public bool IsDefeated()
        {
            if (HealthPoints == 0)
                return true;
            else
                return false;
        }

    }
}
