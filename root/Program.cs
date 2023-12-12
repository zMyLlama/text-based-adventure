using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using root;
using System.Threading;
using System.Threading.Tasks;


Writer Writer = new Writer();
Pokemon Pokemon = new Pokemon();
MoveStats Moves = new MoveStats();
Effectiveness Multiplier = new Effectiveness();
Battle Battle = new Battle();


List<Pokemon> YourPokemons = new List<Pokemon>();
List<Pokemon> OpponentPokemons = new List<Pokemon>();



ScreenSize();
/*Battle.Fight(OpponentPokemons, YourPokemons);*/

Writer.WriteToPosition("\n\n    ,'\\\n_.----.     ____         ,'  _\\   ___    ___     ____\n_,-'       `.     |    |  /`.   \\,-'    |   \\  /   |   |    \\  |`.\n\\      __    \\    '-.  | /   `.  ___    |    \\/    |   '-.   \\ |  |\n \\.    \\ \\   |  __  |  |/    ,','_  `.  |          | __  |    \\|  |\n   \\    \\/   /,' _`.|      ,' / / / /   |          ,' _`.|     |  |\n    \\     ,-'/  /   \\    ,'   | \\/ / ,`.|         /  /   \\  |     |\n     \\    \\ |   \\_/  |   `-.  \\    `'  /|  |    ||   \\_/  | |\\    |\n      \\    \\ \\      /       `-.`.___,-' |  |\\  /| \\      /  | |   |\n       \\    \\ `.__,'|  |`-._    `|      |__| \\/ |  `.__,'|  | |   |\n        \\_.-'       |__|    `-._ |              '-.|     '-.| |   |\n                                `'                            '-._|", WritePositions.CENTER);
Writer.WriteToPosition("\n", WritePositions.CENTER);

CancellationTokenSource cts = new CancellationTokenSource();
Task flickerStartTask = new Task(FlickerStart, cts.Token);
flickerStartTask.Start();

while (!flickerStartTask.IsCompleted)
{
    ConsoleKeyInfo readKey = Console.ReadKey(true);
    if (readKey.Key == ConsoleKey.Spacebar)
    {
        Console.Clear();
        cts.Cancel();
        Start();
    }
}

void FlickerStart()
{
    while (!cts.IsCancellationRequested)
    {
        Writer.WriteToPosition("        --| PRESS [SPACE] TO START |--", WritePositions.CENTER);
        Thread.Sleep(1000);

        if (cts.IsCancellationRequested) return;
        Console.SetCursorPosition(0, Console.GetCursorPosition().Top - 1);
        Console.Write(new string(' ', Console.WindowWidth)); 
        Thread.Sleep(200);
    }
}

void Start()
{
    SelectStarterPokemon();
}

void ScreenSize()
{
    ConsoleKeyInfo key;
    while (true)
    {
        if (Console.WindowWidth < 120 || Console.WindowHeight < 30)
        {
            Writer.WriteToPosition("Make screen larger", WritePositions.CENTER);
            Writer.WriteToPosition("Min Width: 120 \nMin Height: 30", WritePositions.CENTER);
            Writer.WriteToPosition("Current Width: " + Console.WindowWidth, WritePositions.CENTER);
            Writer.WriteToPosition("Current Height: " + Console.WindowHeight, WritePositions.CENTER);
            Thread.Sleep(100);
            Console.Clear();
        }

        if (Console.WindowWidth >= 120 && Console.WindowHeight >= 30)
        {
            Writer.WriteToPosition("Perfect Size! \nIf done press ENTER", WritePositions.CENTER);
            Thread.Sleep(100);
            Console.Clear();
        }

        if (Console.KeyAvailable)
        {
            if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                break;
        }
    }

}

void SelectStarterPokemon()
{
    Console.SetCursorPosition(0,0);
    Writer.WriteToPosition("Welcome to Pokémon\nChoose your starter Pokémon!\n", WritePositions.CENTER);
    Writer.WriteToPosition("Bulbasaur", WritePositions.MIDLEFT, false);
    Writer.WriteToPosition("Charmander", WritePositions.CENTER, false);
    Writer.WriteToPosition("Squirtle", WritePositions.MIDRIGHT);
    string choice = Console.ReadLine().ToLower();
    switch (choice)
    {
        case "bulbasaur":
            YourPokemons.Insert(0, new Pokemon(PokemonNames.BULBASAUR));
            break;
        case "charmander":
            YourPokemons.Insert(0, new Pokemon(PokemonNames.CHARMANDER));
            break;
        case "squirtle":
            YourPokemons.Insert(0, new Pokemon(PokemonNames.SQUIRTLE));
            break;
        default: SelectStarterPokemon();
            break;
    }
}