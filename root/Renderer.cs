namespace root;

public enum LogTypes
{
    DEFAULT,
    INFO,
    ERROR
}

public class Renderer
{
    private readonly int _mainHeight = 25;
    private readonly int _mainWidth = 60;
    private readonly string _logsHeader = "―――――――― OUTPUT ――――――――+";
    
    private readonly List<string> _logs = new List<string>();
    
    public void Render(int x = 0, int y = 0)
    {
        Console.SetCursorPosition(0, 0);
        for (int i = 0; i < _mainHeight; i++)
        {
            if (i == 0)
            {
                // TODO: Move city state to Player
                const string cityState = "PALLET TOWN";
                
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("+―――― " + cityState + ' ' + new string('―', _mainWidth - (7 + cityState.Length)) + "+" + _logsHeader);
                continue;
            }

            if (i == _mainHeight - 1)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("+" + new String('―', _mainWidth - 1) + "+" + new string('―', _logsHeader.Length - 1) + "+");
                continue;
            }
            
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("|{0," + (_mainWidth + _logsHeader.Length) + "}", "|" + new string(' ', _logsHeader.Length - 1) + "|");
        }

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("1. Quit{0,10}", "?. Help\n");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("> ");
    }

    public void Log(string message, LogTypes type = LogTypes.DEFAULT)
    {
        Render();

        ConsoleColor savedConsoleColor = Console.ForegroundColor;
        int savedCaretXPos = Console.GetCursorPosition().Left;
        int savedCaretYPos = Console.GetCursorPosition().Top;
        
        switch (type)
        {
            case LogTypes.DEFAULT:
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                break;
            case LogTypes.INFO:
                message = "(?) " + message;
                Console.ForegroundColor = ConsoleColor.Blue;
                break;
            case LogTypes.ERROR:
                message = "(!) " + message;
                Console.ForegroundColor = ConsoleColor.Red;
                break;
        }
        _logs.Insert(0, message);

        string hourMinute = DateTime.Now.ToString("HH:mm");
        int prevHeight = -1;

        foreach (string storedMessage in _logs)
        {
            int xPos = 0;
            int yPos = prevHeight + 2;
            if (yPos > _mainHeight - 2) break;
            string finalMessage = storedMessage + " (" + hourMinute + ")";
            for (int j = 0; j < finalMessage.Length; j++)
            {
                char messagePiece = finalMessage[j];
                if (messagePiece == '\n')
                {
                    prevHeight += 1;
                    yPos += 1;
                    xPos = finalMessage[j + 1] == ' ' ? -1 : 0;
                    continue;
                }
                
                Console.SetCursorPosition(_mainWidth + 2 + xPos, yPos);
                if (yPos >= _mainHeight - 3 && xPos > _logsHeader.Length - 8)
                {
                    Console.Write("...");
                    break;
                };
                Console.Write(messagePiece);

                xPos += 1;
                if (xPos < 22) continue;
                
                prevHeight += 1;
                yPos += 1;
                xPos = finalMessage[j + 1] == ' ' ? -1 : 0;
            }
            
            Console.ForegroundColor = ConsoleColor.DarkGray;
            prevHeight += 2;
        }

        Console.ForegroundColor = savedConsoleColor;
        Console.SetCursorPosition(savedCaretXPos, savedCaretYPos);
    }
}