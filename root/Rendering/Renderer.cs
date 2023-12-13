using root.Helpers;
using root.Maps;

namespace root;

public enum LogTypes
{
    DEFAULT,
    INFO,
    ERROR
}

public class Renderer
{
    public readonly int MainHeight = 25;
    public readonly int MainWidth = 60;
    private readonly string _logsHeader = "―――――――― OUTPUT ――――――――+";

    private Player _player;
    private readonly List<string> _logs = new List<string>();

    public void SetPlayer(Player player)
    {
        _player = player;
    }

    public void RenderPlayer(bool noBoundry, bool rightBoundry)
    {
        Console.SetCursorPosition(
            noBoundry ? (MainWidth - 2) / 2 : !rightBoundry ? _player.xPosition + 1 :
            (MainWidth - 2) - (RawMap.PALLET_TOWN[0].Length - (_player.xPosition + 1)), 
            _player.yPosition + 1
        );
        Console.Write('P');
        
        ResetCursorToDefault();
    }
    
    public void RenderMap()
    {
        int min = 0;
        int max = RawMap.PALLET_TOWN[0].Length - (MainWidth - 2);
        int xOffset = Math.Clamp(_player.xPosition - (MainWidth - 2) / 2, min, max);
        
        Console.ForegroundColor = ConsoleColor.White;
        int yOffset = 0;
        for (int i = 0; i < RawMap.PALLET_TOWN.Count; i++)
        {
            Console.SetCursorPosition(1, 1 + yOffset);
            Console.Write(RawMap.PALLET_TOWN[i].Substring(xOffset, MainWidth - 2));
            yOffset++;
        }
        
        ResetCursorToDefault();
        RenderPlayer(xOffset != min && xOffset != max, xOffset == max);
    }

    public void ResetCursorToDefault()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(0, MainHeight + 2);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, MainHeight + 2);
        Console.Write("> ");
    }

    public void ClearViewport()
    {
        for (int i = 1; i <= MainHeight - 2; i++)
        {
            Console.SetCursorPosition(1, i);
            Console.Write(new string(' ', MainWidth - 2));
        }
    }
    
    public void Render(bool onlyFrame = false, bool alsoRenderLogs = false)
    {
        Console.SetCursorPosition(0, 0);
        for (int i = 0; i < MainHeight; i++)
        {
            if (i == 0)
            {
                // TODO: Move city state to Player
                string cityState = _player.state switch
                {
                    PlayerStates.TOWN => "PALLET TOWN",
                    PlayerStates.WILDERNESS => "WILDERNESS",
                    _ => "IN BATTLE"
                };;
                
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("+―――― " + cityState + ' ' + new string('―', MainWidth - (7 + cityState.Length)) + "+" + _logsHeader);
                continue;
            }

            if (i == MainHeight - 1)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("+" + new String('―', MainWidth - 1) + "+" + new string('―', _logsHeader.Length - 1) + "+");
                continue;
            }
            
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("|{0," + (MainWidth + _logsHeader.Length) + "}", "|" + new string(' ', _logsHeader.Length - 1) + "|");
        }

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("1. Quit{0,10}", "?. Help\n");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("> ");
        
        if (!onlyFrame) RenderMap();
        if (alsoRenderLogs) RenderLogs(Console.ForegroundColor);
    }

    public void RenderLogs(ConsoleColor restoreColor)
    {
        if (_logs.Count == 0) return;
        int prevHeight = -1;
        
        switch (_logs[0].Substring(0, 3))
        {
            case "(?)":
                Console.ForegroundColor = ConsoleColor.Blue;
                break;
            case "(!)":
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            default:
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                break;
        }

        foreach (string storedMessage in _logs)
        {
            int xPos = 0;
            int yPos = prevHeight + 2;
            if (yPos > MainHeight - 2) break;
            string finalMessage = storedMessage;
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
                
                Console.SetCursorPosition(MainWidth + 2 + xPos, yPos);
                if (yPos >= MainHeight - 4 && xPos > _logsHeader.Length - 8)
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
        
        Console.ForegroundColor = restoreColor;
        ResetCursorToDefault();
    }

    public void Log(string message, LogTypes type = LogTypes.DEFAULT, bool onlyFrame = false)
    {
        Render(onlyFrame);

        ConsoleColor savedConsoleColor = Console.ForegroundColor;
        
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

        RenderLogs(savedConsoleColor);
    }
}