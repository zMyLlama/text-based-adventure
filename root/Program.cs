using root;
using System.Threading;
using System.Threading.Tasks;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Writer Writer = new Writer();
Renderer Renderer = new Renderer();
InputListener Listener = new InputListener(Renderer);
Player Player = new Player(Renderer);

Renderer.SetPlayer(Player);

ScreenSize();

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
    Listener.Initialize();
    
    Renderer.Render();
    Listener.InputEvent += Movement!;

    while (true) { ConsoleKeyInfo readKey = Console.ReadKey(true); }
}

void Movement(object sender, InputEventArgs e)
{
    e.Arg ??= "1";
    if (!int.TryParse(e.Arg, out int offsetArg))
    {
        Renderer.Log("Du kan ikke rykke dig den angivne distance", LogTypes.ERROR);
        return;
    }

    offsetArg = Math.Clamp(offsetArg, 1, 10);
    
    //Renderer.Log("CALLED: " + e.Arg.ToString());
    switch (e.Type)
    {
        case InputEventTypes.MOVEFORWARDS:
            Player.Move(0, offsetArg);
            break;
        case InputEventTypes.MOVEBACKWARDS:
            Player.Move(0, -offsetArg);
            break;
        case InputEventTypes.MOVELEFT:
            Player.Move(-offsetArg, 0);
            break;
        case InputEventTypes.MOVERIGHT:
            Player.Move(offsetArg, 0);
            break;
    }
    
    Renderer.Log(e.Type.ToString(), LogTypes.INFO);
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