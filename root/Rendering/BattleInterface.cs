using root.Maps;

namespace root;

public class BattleInterface
{
    private Renderer _renderer;
    private InputListener _input;
    private Player _player;
    public Battle currentBattle;
    private Random _rnd = new Random();
    private int _lowerShelfHeight = 6;
    
    
    private List<char> symbols = new List<char>() { '!', '#', '@', '%', '&', '$', '€', '*' };
    private List<ConsoleColor> colors = new List<ConsoleColor>() { ConsoleColor.Blue, ConsoleColor.Magenta, ConsoleColor.Cyan, ConsoleColor.Green, ConsoleColor.Red, ConsoleColor.Yellow, ConsoleColor.DarkMagenta };

    public BattleInterface(Player player, Renderer renderer, InputListener input)
    {
        _player = player;
        _input = input;
        _renderer = renderer;
        player.state = PlayerStates.BATTLE;
        input.Terminate();
        renderer.Render(true, true);
        renderer.ClearViewport();

        List<string> allPositions = new List<string>();
        List<string> randomPositions = new List<string>();
        for (int i = 1; i <= renderer.MainHeight - 2; i++)
        {
            for (int j = 1; j <= renderer.MainWidth - 1; j++)
            {
                allPositions.Add(j + ";" + i);
            }
        }

        while (allPositions.Count != 0)
        {
            int r = _rnd.Next(allPositions.Count);
            randomPositions.Add(allPositions[r]);
            allPositions.RemoveAt(r);
        }

        for (int i = 0; i < randomPositions.Count; i++)
        {
            int x = Int32.Parse(randomPositions[i].Split(";")[0]);
            int y = Int32.Parse(randomPositions[i].Split(";")[1]);

            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = colors[_rnd.Next(colors.Count)];
            Console.Write(symbols[_rnd.Next(symbols.Count)]);

            if (i % 20 == 0) Thread.Sleep(1);
        }

        Thread.Sleep(500);

        for (int i = 0; i < randomPositions.Count; i++)
        {
            int x = Int32.Parse(randomPositions[i].Split(";")[0]);
            int y = Int32.Parse(randomPositions[i].Split(";")[1]);

            Console.SetCursorPosition(x, y);
            Console.Write(' ');

            if (i % 40 == 0) Thread.Sleep(1);
        }

        renderer.ResetCursorToDefault();
        Thread.Sleep(1000);

        input.Initialize();
        
        player.pokemons.Insert(0, new Pokemon(PokemonNames.CHARMANDER));
        List<Pokemon> opponentPokemons = new List<Pokemon>();
        opponentPokemons.Insert(0, new WildPokemon("PALLET TOWN").pokemon);

        currentBattle = new Battle(opponentPokemons, player.pokemons, this, renderer, input);
        RenderBattle();
    }

    public void RenderBattle(int xPadding = 6, int yPadding = 2)
    {
        ConsoleColor savedColor = Console.ForegroundColor;
        Pokemon opponentPokemon = currentBattle.OpponentPokemons[currentBattle.OpponentSelectedPokemon];
        Pokemon playerPokemon = currentBattle.PlayerPokemons[currentBattle.PlayerSelectedPokemon];

        string opponentPokemonName = "OPPONENT: " + opponentPokemon.name;
        string opponentPokemonStats = "HP: " + opponentPokemon.hp + "/" + opponentPokemon.maxHP;
        string playerPokemonName = "YOU: " + playerPokemon.name;
        string playerPokemonStats = "HP: " + playerPokemon.hp + "/" + playerPokemon.maxHP;

        Console.ForegroundColor = ConsoleColor.Red;
        Console.SetCursorPosition(_renderer.MainWidth - (1 + xPadding + opponentPokemonName.Length), 1 + yPadding);
        Console.Write(opponentPokemonName);
        Console.SetCursorPosition(_renderer.MainWidth - (1 + xPadding + opponentPokemonName.Length), 2 + yPadding);
        Console.Write(opponentPokemonStats + "      ");
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(1 + xPadding, _renderer.MainHeight - (2 + yPadding + _lowerShelfHeight));
        Console.Write(playerPokemonName);
        Console.SetCursorPosition(1 + xPadding, _renderer.MainHeight - (1 + yPadding + _lowerShelfHeight));
        Console.Write(playerPokemonStats  + "      ");

        int shelfPosition = _renderer.MainHeight - _lowerShelfHeight;
        Console.SetCursorPosition(0, shelfPosition);
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("+" + new String('―', _renderer.MainWidth - 1) + "+");
        
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.SetCursorPosition(4, shelfPosition + 2);
        Console.Write("ATTACK COMMAND: USE/ATTACK ");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write("<move name>");
        
        Console.SetCursorPosition(4, shelfPosition + 3);
        Console.ForegroundColor = ConsoleColor.Gray;
        string playerMoves = "";
        for (int i = 0; i < playerPokemon.Moves.Count; i++)
        {
            playerMoves += playerPokemon.Moves[i].ToString().Replace("_", " ");
            if (i != playerPokemon.Moves.Count - 1) playerMoves += ", ";
        }
        Console.Write("YOUR MOVES: " + playerMoves);
        
        Console.ForegroundColor = savedColor;
        _renderer.ResetCursorToDefault();
    }

    private void DrawTextDown(string text, int delay = 0, ConsoleColor color = ConsoleColor.Green)
    {
        ConsoleColor savedColor = Console.ForegroundColor;
        for (int i = 1; i < _renderer.MainHeight - 1; i++)
        {
            Console.SetCursorPosition(_renderer.MainWidth / 2 - text.Length / 2, i);
            Console.ForegroundColor = color;
            Console.Write(text);
            
            if (delay != 0) Thread.Sleep(delay);
        }

        Console.ForegroundColor = savedColor;
    }

    public void EndBattleInterface(bool playerWon)
    {
        _input.Terminate();
        ConsoleColor color = playerWon ? ConsoleColor.Green : ConsoleColor.Red;
        string faintedText = playerWon ? currentBattle.OpponentPokemons[currentBattle.OpponentSelectedPokemon].name + " FAINTED" : currentBattle.PlayerPokemons[currentBattle.PlayerSelectedPokemon].name + " FAINTED";
        string wonText = playerWon ? "YOU WON!" : "YOU LOST...";
        _renderer.ClearViewport();
        
        DrawTextDown(faintedText, 30, color);
        _renderer.ResetCursorToDefault();
        Thread.Sleep(400);
        
        for (int i = 0; i < 6; i++)
        {
            _renderer.ClearViewport();
            Thread.Sleep(125);
            DrawTextDown(wonText, 0, color);
            Thread.Sleep(175);
        }
        
        _renderer.ResetCursorToDefault();
        Thread.Sleep(500);
        
        _renderer.Log(wonText, LogTypes.DEFAULT, true);
        
        _player.state = PlayerStates.TOWN;
        _renderer.ClearViewport();
        _renderer.Render(false, true);
        _input.Initialize();
    }
}