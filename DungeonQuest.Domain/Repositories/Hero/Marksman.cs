using DungeonQuest.Domain.Repositories.Hero;
using DungeonQuest.Domain.Repositories.Monster;
public class Marksman : Hero
{
    public double CriticalChance { get; private set; }
    public double StunChance { get; private set; }

    public Marksman(string name, double initialHealthPoints, double initialCriticalChance, double initialStunChance) : base(name, initialHealthPoints)
    {
        CriticalChance = initialCriticalChance;
        StunChance = initialStunChance;
    }

    public void AttackWithChances(Monster monster)
    {
        if (RandomChance(CriticalChance))
        {
            double damageDealt = Damage * 2;
            monster.TakeDamage(damageDealt);
        }
        else if (RandomChance(StunChance))
        {
            monster.Stun();
        }
        else
        {
            Attack(monster);
        }
    }

    private bool RandomChance(double chance)
    {
        double randomValue = new Random().NextDouble();
        return randomValue < chance;
    }
    public void LevelUp(double experienceGained, double healthIncrease, double damageIncrease, double criticalChanceIncrease, double stunChanceIncrease)
    {
        base.LevelUp(experienceGained, healthIncrease, damageIncrease);
        CriticalChance += criticalChanceIncrease;
        StunChance += stunChanceIncrease;
    }
}
