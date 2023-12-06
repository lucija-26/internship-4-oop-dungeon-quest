using DungeonQuest.Domain.Repositories.Hero;
using DungeonQuest.Domain.Repositories.Monster;
using DungeonQuest.Domain.Repositories.Round;


bool status = true;
while(status)
{
    Console.WriteLine("Press enter to play or 0 to exit");
    var choice = Console.ReadLine();
    if (choice == "0")
    {
        Console.WriteLine("Thanks for playing!");
        break;
    }
    Console.Clear();
    Console.WriteLine("Choose your hero: ");
    HeroOptions();
    int heroChoice = GetNumberFromUser();
    switch(heroChoice)
    {
        case 1:
            GladiatorChoice();
            break;
        case 2:
            EnchanterChoice();
            break;
        case 3:
            MarksmanChoice();
            break;
        case 0:
            status = false;
            break;
        default:
            Console.WriteLine("Please pick a valid option.");
            break;
    }
}

// Start game

static void StartGame(Hero hero)
{
    List<Monster> monsters = new List<Monster>();
    GenerateTenRandomMonsters(monsters);
    DisplayGameInfo(monsters, hero);
    Game(monsters, hero);
}

// User-checks

static int GetNumberFromUser()
{
    int number;
    do
    {
        Console.WriteLine("Input a number: ");
        var input = int.TryParse(Console.ReadLine(), out number);
        if (!input || number < 0)
            Console.WriteLine("Please try again. ");
        else
        {
            return number;
        }
    } while (true);
}

//Hero options

static void HeroOptions()
{
    Console.WriteLine("Number\tName\t\tHP\tDamage");
    Console.WriteLine("1\tGladiator\t200\t10");
    Console.WriteLine("2\tEnchanter\t100\t40");
    Console.WriteLine("3\tMarksman\t150\t20");
    Console.WriteLine("");
}

static void GladiatorChoice()
{
    var name = GetHeroName();
    Gladiator gladiator = new Gladiator(name, 200, 10, 0);
    Console.Clear();
}

static string GetHeroName()
{
    string name;
    while (true)
    {
        Console.WriteLine("Hero name: ");
        var inputName = Console.ReadLine();

        if (string.IsNullOrEmpty(inputName))
        {
            Console.WriteLine("Name can't be empty");
        }
        else
        {
            return inputName;
        }
    }
}


static void Game(List<Monster> monsters, Hero hero)
{
    Dictionary<int, string> availableMoves = new Dictionary<int, string> {
        {1, "Direct" },
        {2, "Counter" },
        {3, "Side" }
    };
    Console.WriteLine();

    int userChoice;
    int currentRound = 1;

    foreach (var monster in monsters)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"{hero.GetType().Name} encounters {monster.GetType().Name}");
            Console.WriteLine($"Current Round: {currentRound}");
            DisplayMoves(availableMoves);

            userChoice = GenerateHeroMove(availableMoves);
            string userSelectedMove = availableMoves[userChoice];
            Console.WriteLine($"You choose: {userSelectedMove}");

            int monsterMove = GenerateMonsterMove();
            string monsterSelectedMove = availableMoves[monsterMove];
            Console.WriteLine($"Monster chooses: {monsterSelectedMove}\n");

            Round currentRoundInfo = new Round(userSelectedMove, monsterSelectedMove, currentRound);
            DetermineOutcome(monster, hero, currentRoundInfo, monsters);

            Console.WriteLine("Do you want to quit? Y/N");
            string quitInput = Console.ReadLine();
            if (quitInput == "yes")
            {
                Console.Clear();
                return;
            }
            DisplayGameInfo(monsters, hero);
            if(monster.IsDefeated())
            {
                monsters.Remove(monster);
            }
            Console.WriteLine("\nPress any key to proceed to the next round...");
            Console.ReadKey();
        }
    }
}

static void DisplayMoves(Dictionary<int, string> availableMoves)
{
    foreach(var move in availableMoves)
    {
        Console.WriteLine($"- {move.Key} - {move.Value}");
    }
}

static int GenerateMonsterMove()
{
    Random random = new Random();
    return random.Next(1, 4);
}
static int GenerateHeroMove(Dictionary<int, string> moves)
{
    int choice;
    do
    {
        Console.WriteLine("Pick a move");
        choice = GetNumberFromUser();
        if (!moves.ContainsKey(choice))
        {
            Console.WriteLine("Please, try again");
        }
    } while (!moves.ContainsKey(choice));
    return choice;
}

static void DetermineOutcome(Monster monster, Hero hero, Round round, List<Monster> monsters)
{
    bool heroWon = round.HeroWins(hero, monster);

    if (monster.GetType() == typeof(Witch))
    {
        Witch witch = (Witch)monster;
        if (witch.SpecialAttack)
            witch.SpecialAttackMonsters(monsters);
    }
    if (heroWon)
    {
        hero.LevelUp(10, 10, 10);

    }
    else if (hero.IsDefeated())
    {
        Console.WriteLine("Game over. You lost. ");

    }

}

static void DisplayGameInfo(List<Monster> monsters, Hero hero) 
{
    hero.DisplayStatus();
    foreach(var monster in monsters)
    {
        monster.DisplayStatus();
    }
}

// Enchanter
static void EnchanterChoice()
{
    var name = GetHeroName();
    Enchanter enchanter = new Enchanter(name, 100, 40, 0);
    Console.Clear();
    StartGame(enchanter);
}

// Marksman

static void MarksmanChoice()
{
    var name = GetHeroName();
    Marksman marksman = new Marksman(name, 150, 20, 0);
    Console.Clear();
    StartGame(marksman);

}

// Generating monsters

static void GenerateTenRandomMonsters(List<Monster> monsters)
{
    Random random = new Random();

    for (int i = 0; i < 10; i++)
    {
        double randomDouble = random.NextDouble();
        int randomHP = random.Next(20, 100);
        int randomDamage = random.Next(5, 80);
        int randomXP = random.Next(10, 80);

        if (randomDouble <= 0.6)
        {
            monsters.Add(new Goblin("goblin", randomHP, randomDamage, randomXP, false));
        }
        else if (randomDouble >= 0.6 && randomDouble <= 0.85)
        {
            monsters.Add(new Brute("brute", randomHP, randomDamage, randomXP, false));
        }
        else if (randomDouble > 0.85)
        {
            monsters.Add(new Witch("witch", randomHP, randomDamage, randomXP, false));
        }
    }
}
