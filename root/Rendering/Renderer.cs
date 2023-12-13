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
    
    private void RenderPlayer(bool noXBoundry, bool rightXBoundry, bool noYBoundry, bool bottomYBoundry)
    {
        /*
         * When rendering the player in the center of the scene, then we cant offset both the map position and player as this would cause a double offset making a sort of parallax effect
         * To circumvent this we pass in variables depending on what bounding box of the map we are hitting. If the camera isnt being bound then we just place the player in the middle of the screen.
         * If the camera is hitting the bounding box of the map, then we do some fancy math to properly position the player.
         * This way we can keep the player position in world space, meaning that the player's x can be 100 instead of being bound by the viewport size of ~60.
         * In this way we can easily look up the surrounding characters of the player, allowing us to easily implement dialog interactions.
         */
        Console.SetCursorPosition(
            noXBoundry ? (MainWidth - 2) / 2 : !rightXBoundry ? _player.xPosition + 1 :
            (MainWidth - 2) - (RawMap.PALLET_TOWN[0].Length - (_player.xPosition + 1)), 
            noYBoundry ? (MainHeight - 2) / 2 : !bottomYBoundry ? _player.yPosition + 1 : 
            (MainHeight - 2) - (RawMap.PALLET_TOWN.Count - (_player.yPosition + 1))
        );
        Console.Write('P');
        
        ResetCursorToDefault();
    }
    
    /// <summary>
    /// Renders the current selected map to the viewport of the scene, based on the players current coordinates.
    /// </summary>
    /// <remarks>If possible then positions the camera in the center of the player</remarks>
    public void RenderCurrentScene()
    {
        int xyMin = 0;
        int xMax = RawMap.PALLET_TOWN[0].Length - (MainWidth - 2);
        int yMax = RawMap.PALLET_TOWN.Count - (MainHeight - 2);
        int xOffset = Math.Clamp(_player.xPosition - (MainWidth - 2) / 2, xyMin, xMax);
        int yOffset = Math.Clamp(_player.yPosition - (MainHeight - 2) / 2, xyMin, yMax);
        /*
         * Noticed that we subtract 2 often? Thats because the MainWidth also includes the borders, which in this case arent needed, hence the removal of the 2 character border.
         */
        
        Console.ForegroundColor = ConsoleColor.White;
        int cursorYOffset = 0;
        for (int i = 0; i < MainHeight - 2; i++)
        {
            Console.SetCursorPosition(1, 1 + cursorYOffset);
            Console.Write(RawMap.PALLET_TOWN[i + yOffset].Substring(xOffset, MainWidth - 2));
            cursorYOffset++;
        }
        
        ResetCursorToDefault();
        RenderPlayer(xOffset != xyMin && xOffset != xMax, xOffset == xMax, yOffset != xyMin && yOffset != yMax, yOffset == yMax);
    }

    /// <summary>
    /// Resets the consle cursor position to the default input field.
    /// </summary>
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
    
    /// <summary>
    /// Renders the entire game to the console, this includes the frame and map.
    /// </summary>
    /// <param name="onlyFrame">An optional boolean telling the renderer to only render the frame and not the scene</param>
    /// <param name="alsoRenderLogs">An optional boolean forcing the renderer to also rerender the logs</param>
    /// <remarks>Forcing logs to render shouldnt be used unless necessary</remarks>
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
        
        if (!onlyFrame) RenderCurrentScene();
        if (alsoRenderLogs) RenderLogs(Console.ForegroundColor);
    }

    /// <summary>
    /// Renders all possibe logs that are currently stored in the system
    /// </summary>
    /// <param name="restoreColor">A console color to restore to after the operation is done</param>
    public void RenderLogs(ConsoleColor restoreColor)
    {
        if (_logs.Count == 0) return;
        int prevHeight = -1;
        
        // BUG: Will probably break if the message is less than 3 characters
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
            for (int j = 0; j < storedMessage.Length; j++)
            {
                char messagePiece = storedMessage[j];
                if (messagePiece == '\n')
                {
                    prevHeight += 1;
                    yPos += 1;
                    xPos = storedMessage[j + 1] == ' ' ? -1 : 0;
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
                xPos = storedMessage[j + 1] == ' ' ? -1 : 0;
            }
            
            Console.ForegroundColor = ConsoleColor.DarkGray;
            prevHeight += 2;
        }
        
        Console.ForegroundColor = restoreColor;
        ResetCursorToDefault();
    }

    /// <summary>
    /// Adds a log to the system and automatically renders it to the console.
    /// Rerenders the frame to clear previous logs.
    /// </summary>
    /// <param name="message">The message to log to the user</param>
    /// <param name="type">The importance / relevance of the message. Changes the color and adds a symbol depending on the type</param>
    /// <param name="onlyFrame">Makes the rerender only render the frame. Useful for when you want to keep the content of the viewport intact</param>
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