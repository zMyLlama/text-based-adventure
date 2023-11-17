using System.Net.Security;
using root;
using System.Threading;
using System.Threading.Tasks;


Writer Writer = new Writer();
Pokemon Pokemon = new Pokemon();
MoveStats Moves = new MoveStats();
Effectiveness multiplier = new Effectiveness();


List<Pokemon> YourPokemons = new List<Pokemon>();
List<Pokemon> OpponentPokemons = new List<Pokemon>();
float criticalHit = 1f;


ScreenSize();
Battle();

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
    Writer.WriteToPosition("\nWelcome!\nType *anything* to begin!", WritePositions.CENTER);

    /*Pokemon.PokemonWithStats(PokemonNames.BULBASAUR);
    int damage = Convert.ToInt16(2f + 0.4f * Pokemon.level * Pokemon.attack * Moves.power / Pokemon.defense / 50f + 2f);
    Writer.WriteToPosition("Damage: " + damage,WritePositions.LEFT);*/

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

void Battle()
{
    /*/*YourPokemons.Insert(0,new Pokemon(PokemonNames.BULBASAUR));
    OpponentPokemons.Insert(0,new Pokemon(PokemonNames.BULBASAUR));
    
    BattleInterface();
    while (OpponentPokemons[0].hp > 0)
    {
        string command = Console.ReadLine();
        if (command == "tackle")
        {
            Random rnd = new Random();
            criticalHit = rnd.Next(1 , 255);
            if (criticalHit < YourPokemons[0].speed / 2)
                criticalHit = 1.5f;
            else
                criticalHit = 1f;
            /*int damage = Convert.ToInt16(((2 * YourPokemons[0].level * criticalHit / 5 + 2) * YourPokemons[0].Move1.power * YourPokemons[0].attack / OpponentPokemons[0].defense / 50 + 2) * 1 * multiplier.Effective(YourPokemons[0].Move1.type,OpponentPokemons[0].type1) * 1 * 1);#2#
            OpponentPokemons[0].hp -= damage;
            Console.Clear();
            BattleInterface();#1#
        }
    }*/
}

void BattleInterface()
{
    Writer.WriteToPosition("" + OpponentPokemons[0].name,WritePositions.CENTER, false);
    Writer.WriteToPosition("HP: " + OpponentPokemons[0].hp + "\n\n\n\n\n" ,WritePositions.MIDLEFT);
    Writer.WriteToPosition("" + YourPokemons[0].name,WritePositions.LEFT, false);
    Writer.WriteToPosition("HP: " + YourPokemons[0].hp,WritePositions.MIDLEFT);

}