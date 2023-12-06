namespace DungeonQuest.Domain.Repositories.Round
{
    using DungeonQuest.Domain.Repositories.Monster;
    using DungeonQuest.Domain.Repositories.Hero;

    public class Round
    {
        public string HeroAction { get; }
        public string MonsterAction { get; }
        public int RoundNumber { get; set; }

        public Round(string heroAction, string monsterAction, int roundNumber)
        {
            HeroAction = heroAction;
            MonsterAction = monsterAction;
            RoundNumber = roundNumber;
        }

        private bool BeatingMove()
        {
            if (MonsterAction == "Counter" && HeroAction == "Direct")
                return true;
            else if (MonsterAction == "Direct" && HeroAction == "Side")
                return true;
            else if (MonsterAction == "Side" && HeroAction == "Counter")
                return true;
            return false;
        }

        public bool HeroWins(Hero hero, Monster monster)
        {

            if (HeroAction == MonsterAction)
            {
                Console.WriteLine("Both sides picked the same action");
                return false;
            }
            else if (BeatingMove())
            {
                hero.Attack(monster);
                if (monster.HealthPoints <= 0)
                {
                    Console.WriteLine("Hero wins this round!");
                    hero.LevelUp(10, 10, 10);
                    hero.victories++;
                    return true;
                }
                return false;

            }
            else
            {
                monster.Attack(hero);

                if (hero.HealthPoints <= 0)
                    Console.WriteLine("Monster wins this round!");
                return false;

            }
        }
    }
}
