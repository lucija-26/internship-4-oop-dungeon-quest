using DungeonQuest.Domain.Repositories.Hero;
using DungeonQuest.Domain.Repositories.Monster;
using DungeonQuest.Domain.Repositories.Game;


bool status = true;
while (status)
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
    switch (heroChoice)
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