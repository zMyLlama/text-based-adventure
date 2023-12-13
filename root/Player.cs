using root.Maps;

namespace root;

public class Player
{
    private Random _rnd = new Random();
    private Renderer _renderer;
    public List<string> currentMap = RawMap.PALLET_TOWN;
    public PlayerStates state = PlayerStates.TOWN;
    public List<Pokemon> pokemons = new List<Pokemon>();
    public int xPosition = 0;
    public int yPosition = 0;

    public Player(Renderer renderer)
    {
        _renderer = renderer;
    }

    /// <summary>
    /// Checks if a designated spot on the current map contains a collider.
    /// Does not handle out of bounds detection.
    /// </summary>
    /// <param name="x">X Position to scan for on map</param>
    /// <param name="y">Y position to scan for on map</param>
    /// <returns>A boolean indicating if the spot contains a collider</returns>
    public bool IsMapColliderAtPosition(int x, int y)
    {
        /*
         * I did consider using a HashSet over a list because of its time complexity of O(1)
         * However because of the small List size the linear time complexity of O(n) will outperfom the HashSet.
         */
        List<char> nonColliders = new List<char>()
        {
            ' ', ';', 'P', '.'
        };
        return !nonColliders.Contains(currentMap[Math.Clamp(y, 0, currentMap.Count - 1)][Math.Clamp(x, 0, currentMap[0].Length)]);
    }

    public char GetCharAtPosition(int x, int y)
    {
        return currentMap[Math.Clamp(y, 0, currentMap.Count - 1)][Math.Clamp(x, 0, currentMap[0].Length)];
    }
    
    /// <summary>
    /// Moves the player by the specified amount. Also takes into acount boundaries and other collider.
    /// Since it fits nicely it also checks for encounters in tall grass.
    /// </summary>
    /// <param name="xOffset">Amount to move the player by on the x-axis</param>
    /// <param name="yOffset">Amount to move the player by on the y-axis</param>
    /// <param name="dontRender">If this is true then the program will not rerender the viewport when the player has moved</param>
    /// <returns>A boolean indicating if the player encountered a pokemon in tall grass.</returns>
    public bool Move(int xOffset = 0, int yOffset = 0, bool dontRender = false)
    {
        bool encounter = false;
        ConsoleColor savedConsoleColor = Console.ForegroundColor;
        
        if (xOffset != 0)
        {
            for (int i = 0; i < xOffset; i++)
            {
                if (GetCharAtPosition(xPosition + i, yPosition) == ';' && _rnd.Next(1,256) < 25)
                {
                    _renderer.Log("ENCOUNTER!!!", LogTypes.INFO);
                    encounter = true;
                    xOffset = i;
                    break;
                }
                if (IsMapColliderAtPosition(xPosition + i, yPosition)) xOffset = i;
            }
        }
        if (yOffset != 0)
        {
            for (int i = 1; i <= Math.Abs(yOffset); i++)
            {
                if (!IsMapColliderAtPosition(Math.Clamp(xPosition - 1, 0, currentMap[0].Length), yOffset < 0 ? yPosition + i : yPosition - i)) continue;
                
                if (yOffset < 0) yOffset = -(i - 1);
                if (yOffset > 0) yOffset = i - 1;
                break;
            }
        }
        
        xPosition = Math.Clamp(xPosition + xOffset, 0, currentMap[0].Length);
        yPosition = Math.Clamp(-yOffset + yPosition, 0, currentMap.Count - 1);

        if (dontRender)
        {
            _renderer.RenderLogs(savedConsoleColor);
            return encounter;
        }
        _renderer.Render();
        _renderer.RenderLogs(savedConsoleColor);

        return encounter;
    }
}