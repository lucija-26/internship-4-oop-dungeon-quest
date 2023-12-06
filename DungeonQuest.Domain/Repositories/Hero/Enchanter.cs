using DungeonQuest.Domain.Repositories.Hero;
using DungeonQuest.Domain.Repositories.Monster;


public class Enchanter : Hero
{
    public double MaxMana { get; private set; }
    public double Mana { get; set; }
    public bool IsRevived { get; private set; }

    public Enchanter(string name, double initialHealthPoints, double damage, double experience) : base(name, initialHealthPoints)
    {
        Damage = damage;
        Experience = experience;
        Mana = 0;
        MaxMana = 0;
        IsRevived = false;
    }

    public void AttackWithMana(Monster monster)
    {
        if (Mana > 0)
        {
            double damageDealt = Damage;
            Mana--;
            monster.TakeDamage(damageDealt);
            return;
        }
        Attack(monster);
    }

    public void RestoreMana()
    {
        Mana = MaxMana;
    }

    public void RestoreHealthWithMana(double manaCost)
    {
        if (Mana >= manaCost)
        {
            HealthPoints = MaxHealthPoints;
            Mana -= manaCost;
        }
    }


    public void Revive()
    {
        if (!IsRevived)
        {
            IsRevived = true;
            HealthPoints = MaxHealthPoints;
        }
    }
}
