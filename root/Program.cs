using root;
using System.Threading;
using System.Threading.Tasks;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Writer Writer = new Writer();
Renderer Renderer = new Renderer();

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
    Renderer.Render();

    while (true)
    {
        string? readLine = Console.ReadLine();
        Renderer.Log("You typed:\n" + readLine, LogTypes.INFO);
    }
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