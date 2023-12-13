using root;

Writer Writer = new Writer();
Renderer Renderer = new Renderer();
Player Player = new Player(Renderer);
InputListener Listener = new InputListener(Renderer);

Pokemon Pokemon = new Pokemon();
MoveStats Moves = new MoveStats();

ScreenSize();

Writer.WriteToPosition("\n\n    ,'\\\n_.----.     ____         ,'  _\\   ___    ___     ____\n_,-'       `.     |    |  /`.   \\,-'    |   \\  /   |   |    \\  |`.\n\\      __    \\    '-.  | /   `.  ___    |    \\/    |   '-.   \\ |  |\n \\.    \\ \\   |  __  |  |/    ,','_  `.  |          | __  |    \\|  |\n   \\    \\/   /,' _`.|      ,' / / / /   |          ,' _`.|     |  |\n    \\     ,-'/  /   \\    ,'   | \\/ / ,`.|         /  /   \\  |     |\n     \\    \\ |   \\_/  |   `-.  \\    `'  /|  |    ||   \\_/  | |\\    |\n      \\    \\ \\      /       `-.`.___,-' |  |\\  /| \\      /  | |   |\n       \\    \\ `.__,'|  |`-._    `|      |__| \\/ |  `.__,'|  | |   |\n        \\_.-'       |__|    `-._ |              '-.|     '-.| |   |\n                                `'                            '-._|", WritePositions.CENTER);
Writer.WriteToPosition("\n", WritePositions.CENTER);

CancellationTokenSource cts = new CancellationTokenSource();
Task flickerStartTask = new Task(FlickerStart, cts.Token);
Battle currentBattle;
BattleInterface currentBattleInterface;
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
    Renderer.SetPlayer(Player);
    Listener.Initialize();
    
    Renderer.Render();
    Listener.InputEvent += Movement!;

    while (true) { ConsoleKeyInfo readKey = Console.ReadKey(true); }
}

void Encounter()
{
    BattleInterface battleInterface = new BattleInterface(Player, Renderer, Listener);
    currentBattle = battleInterface.currentBattle;

    Listener.InputEvent -= Battle!;
    Listener.InputEvent += Battle!;
}

void Battle(object sender, InputEventArgs e)
{
    if (Player.state != PlayerStates.BATTLE) return;
    if (e.Arg == null) return;
    if (e.Type != InputEventTypes.BATTLE) return;
    
    currentBattle.Fight(e.Arg.ToUpper());
}

void Movement(object sender, InputEventArgs e)
{
    if (Player.state is not (PlayerStates.TOWN or PlayerStates.WILDERNESS)) return;
    
    e.Arg ??= "1";
    if (!int.TryParse(e.Arg, out int offsetArg))
    {
        Renderer.Log("Du kan ikke rykke dig den angivne distance", LogTypes.ERROR);
        return;
    }

    bool encounter = false;
    offsetArg = Math.Clamp(offsetArg, 1, 10);
    
    switch (e.Type)
    {
        case InputEventTypes.MOVEFORWARDS:
            encounter = Player.Move(0, offsetArg);
            break;
        case InputEventTypes.MOVEBACKWARDS:
            encounter = Player.Move(0, -offsetArg);
            break;
        case InputEventTypes.MOVELEFT:
            encounter = Player.Move(-offsetArg, 0);
            break;
        case InputEventTypes.MOVERIGHT:
            encounter = Player.Move(offsetArg, 0);
            break;
    }
    
    if (encounter) Encounter();
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

        if (!Console.KeyAvailable) continue;
        if (Console.ReadKey(true).Key == ConsoleKey.Enter)
            break;
    }
}

void SelectStarterPokemon()
{
    /*Console.SetCursorPosition(0,0);
    Writer.WriteToPosition("Welcome to Pokémon\nChoose your starter Pokémon!\n", WritePositions.CENTER);
    Writer.WriteToPosition("Bulbasaur", WritePositions.MIDRIGHT, false);
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
    }*/
}