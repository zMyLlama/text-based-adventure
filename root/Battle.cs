namespace root;

public class Battle
{
    public List<Pokemon> OpponentPokemons;
    public List<Pokemon> PlayerPokemons;
    public int PlayerSelectedPokemon = 0;
    public int OpponentSelectedPokemon = 0;

    public MoveStats playerUsedMove = new MoveStats();
    public MoveStats opponentUsedMove = new MoveStats();
    private PokemonMoves moveUsed;

    public bool ongoingBattle = true;
    public int fightOrder;

    private float firstDmgMultiplier = 1;
    private float secondDmgMultiplier = 1;
    private float oppoFirstDmgMultiplier = 1;
    private float oppoSecondDmgMultiplier = 1;
    private float criticalHit = 1;
    private float oppoCriticalHit = 1;
    private int damage;

    private BattleInterface _battleInterface;
    private Renderer _renderer;
    private InputListener _input;
    
    public Battle(List<Pokemon> opponentPokemons, List<Pokemon> playerPokemons, BattleInterface battleInterface, Renderer renderer, InputListener input)
    {
        OpponentPokemons = opponentPokemons;
        PlayerPokemons = playerPokemons;
        _battleInterface = battleInterface;
        _renderer = renderer;
        _input = input;
    }

    public void Fight(string command)
    {
        switch (command)
        {
            case "GUST":
                moveUsed = PokemonMoves.GUST;
                if (PlayerPokemons[PlayerSelectedPokemon].Moves.Contains(moveUsed))
                {
                    playerUsedMove.PokeMoves(PokemonMoves.GUST);
                }
                else
                    return;
                break;

            case "SAND ATTACK":
                moveUsed = PokemonMoves.SAND_ATTACK;
                if (PlayerPokemons[PlayerSelectedPokemon].Moves.Contains(moveUsed))
                {
                    playerUsedMove.PokeMoves(PokemonMoves.SAND_ATTACK);
                }
                else
                    return;
                break;

            case "TACKLE":
                moveUsed = PokemonMoves.TACKLE;
                if (PlayerPokemons[PlayerSelectedPokemon].Moves.Contains(moveUsed))
                {
                    playerUsedMove.PokeMoves(PokemonMoves.TACKLE);
                }
                else
                    return;
                break;

            case "TAIL WHIP":
                moveUsed = PokemonMoves.TAIL_WHIP;
                if (PlayerPokemons[PlayerSelectedPokemon].Moves.Contains(moveUsed))
                {
                    playerUsedMove.PokeMoves(PokemonMoves.TAIL_WHIP);
                }
                else
                    return;
                break;

            case "QUICK ATTACK":
                moveUsed = PokemonMoves.QUICK_ATTACK;
                if (PlayerPokemons[PlayerSelectedPokemon].Moves.Contains(moveUsed))
                {
                    playerUsedMove.PokeMoves(PokemonMoves.QUICK_ATTACK);
                }
                else
                    return;
                break;

            case "GROWL":
                moveUsed = PokemonMoves.GROWL;
                if (PlayerPokemons[PlayerSelectedPokemon].Moves.Contains(moveUsed))
                {
                    playerUsedMove.PokeMoves(PokemonMoves.GROWL);
                }
                else
                    return;
                break;

            case "VINE WHIP":
                moveUsed = PokemonMoves.VINE_WHIP;
                if (PlayerPokemons[PlayerSelectedPokemon].Moves.Contains(moveUsed))
                {
                    playerUsedMove.PokeMoves(PokemonMoves.VINE_WHIP);
                }
                else
                    return;
                break;

            case "SCRATCH":
                moveUsed = PokemonMoves.SCRATCH;
                if (PlayerPokemons[PlayerSelectedPokemon].Moves.Contains(moveUsed))
                {
                    playerUsedMove.PokeMoves(PokemonMoves.SCRATCH);
                }
                else
                    return;
                break;

            case "EMBER":
                moveUsed = PokemonMoves.EMBER;
                if (PlayerPokemons[PlayerSelectedPokemon].Moves.Contains(moveUsed))
                {
                    playerUsedMove.PokeMoves(PokemonMoves.EMBER);
                }
                else
                    return;
                break;

            case "BUBBLE":
                moveUsed = PokemonMoves.BUBBLE;
                if (PlayerPokemons[PlayerSelectedPokemon].Moves.Contains(moveUsed))
                {
                    playerUsedMove.PokeMoves(PokemonMoves.BUBBLE);
                }
                else
                    return;
                break;

            case "STRING SHOT":
                moveUsed = PokemonMoves.STRING_SHOT;
                if (PlayerPokemons[PlayerSelectedPokemon].Moves.Contains(moveUsed))
                {
                    playerUsedMove.PokeMoves(PokemonMoves.STRING_SHOT);
                }
                else
                    return;
                break;

            case "POISON STING":
                moveUsed = PokemonMoves.POISON_STING;
                if (PlayerPokemons[PlayerSelectedPokemon].Moves.Contains(moveUsed))
                {
                    playerUsedMove.PokeMoves(PokemonMoves.POISON_STING);
                }
                else
                    return;
                break;
            
            default: return;
        }

        if (playerUsedMove.immuneAgainst.Contains(OpponentPokemons[OpponentSelectedPokemon].firstElementType) ||
            playerUsedMove.immuneAgainst.Contains(OpponentPokemons[OpponentSelectedPokemon].secondElementType))
        {
            firstDmgMultiplier = 0;
            secondDmgMultiplier = 0;
        }
        else if (playerUsedMove.strongAgainst.Contains(OpponentPokemons[OpponentSelectedPokemon].firstElementType))
            firstDmgMultiplier = 2;
        else if (playerUsedMove.weakAgainst.Contains(OpponentPokemons[OpponentSelectedPokemon].firstElementType))
            firstDmgMultiplier = 0.5f;
        else
            firstDmgMultiplier = 1;

        if (playerUsedMove.strongAgainst.Contains(OpponentPokemons[OpponentSelectedPokemon].secondElementType))
            secondDmgMultiplier = 2;
        else if (playerUsedMove.weakAgainst.Contains(OpponentPokemons[OpponentSelectedPokemon].secondElementType))
            secondDmgMultiplier = 0.5f;
        else
            secondDmgMultiplier = 1;
        
        OpponentsMove(OpponentPokemons[OpponentSelectedPokemon]);
        if (opponentUsedMove.immuneAgainst.Contains(PlayerPokemons[PlayerSelectedPokemon].firstElementType) ||
            opponentUsedMove.immuneAgainst.Contains(PlayerPokemons[PlayerSelectedPokemon].secondElementType))
        {
            oppoFirstDmgMultiplier = 0;
            oppoSecondDmgMultiplier = 0;
        }
        else if (opponentUsedMove.strongAgainst.Contains(PlayerPokemons[PlayerSelectedPokemon].firstElementType))
            oppoFirstDmgMultiplier = 2;
        else if (opponentUsedMove.weakAgainst.Contains(PlayerPokemons[PlayerSelectedPokemon].firstElementType))
            oppoFirstDmgMultiplier = 0.5f;
        else
            oppoFirstDmgMultiplier = 1;

        if (opponentUsedMove.strongAgainst.Contains(PlayerPokemons[PlayerSelectedPokemon].secondElementType))
            oppoSecondDmgMultiplier = 2;
        else if (opponentUsedMove.weakAgainst.Contains(PlayerPokemons[PlayerSelectedPokemon].secondElementType))
            oppoSecondDmgMultiplier = 0.5f;
        else
            oppoSecondDmgMultiplier = 1;

        Random rnd = new Random();
        criticalHit = rnd.Next(1, 255);
        if (criticalHit < PlayerPokemons[PlayerSelectedPokemon].speed / 2)
            criticalHit = 1.5f;
        else
            criticalHit = 1f;

        if (criticalHit < OpponentPokemons[OpponentSelectedPokemon].speed / 2)
            oppoCriticalHit = 1.5f;
        else
            criticalHit = 1f;
        
        if (PlayerPokemons[PlayerSelectedPokemon].speed >= OpponentPokemons[OpponentSelectedPokemon].speed)
            fightOrder = 1;
        else
            fightOrder = 2;


        switch (fightOrder)
        {
            case 1: //player attacks first
                _renderer.Log("YOU USED: " + playerUsedMove.moveUsed, LogTypes.DEFAULT, true);
                damage =
                    Convert.ToInt16(
                        ((2 * PlayerPokemons[PlayerSelectedPokemon].level * criticalHit / 5 + 2) * playerUsedMove.power *
                            PlayerPokemons[PlayerSelectedPokemon].attack /
                            OpponentPokemons[OpponentSelectedPokemon].defense / 50 + 2) * 1 * firstDmgMultiplier *
                        secondDmgMultiplier * 1);
                OpponentPokemons[OpponentSelectedPokemon].hp -= damage;
                if (OpponentPokemons[OpponentSelectedPokemon].hp <= 0)
                {
                    OpponentPokemons[OpponentSelectedPokemon].hp = 0;
                    _battleInterface.EndBattleInterface(true);
                    break;
                }
                
                _battleInterface.RenderBattle();
                _input.Terminate();
                Thread.Sleep(1000);
                _input.Initialize();
                _renderer.Log("OPPONENT USED: " + opponentUsedMove.moveUsed, LogTypes.ERROR, true);
                
                damage =
                    Convert.ToInt16(
                        ((2 * OpponentPokemons[OpponentSelectedPokemon].level * criticalHit / 5 + 2) *
                            opponentUsedMove.power * OpponentPokemons[OpponentSelectedPokemon].attack /
                            PlayerPokemons[PlayerSelectedPokemon].defense / 50 + 2) * 1 * firstDmgMultiplier *
                        secondDmgMultiplier * 1);
                PlayerPokemons[PlayerSelectedPokemon].hp -= damage;
                if (PlayerPokemons[PlayerSelectedPokemon].hp <= 0)
                {
                    PlayerPokemons[PlayerSelectedPokemon].hp = 0;
                    _battleInterface.EndBattleInterface(false);
                    break;
                }
                
                _battleInterface.RenderBattle();
                break;
            case 2: //opponent attacks first
                _renderer.Log("OPPONENT USED: " + opponentUsedMove.moveUsed, LogTypes.ERROR, true);
                damage =
                    Convert.ToInt16(
                        ((2 * OpponentPokemons[OpponentSelectedPokemon].level * criticalHit / 5 + 2) *
                            opponentUsedMove.power * OpponentPokemons[OpponentSelectedPokemon].attack /
                            PlayerPokemons[PlayerSelectedPokemon].defense / 50 + 2) * 1 * firstDmgMultiplier *
                        secondDmgMultiplier * 1);
                PlayerPokemons[PlayerSelectedPokemon].hp -= damage;
                if (PlayerPokemons[PlayerSelectedPokemon].hp <= 0)
                {
                    PlayerPokemons[PlayerSelectedPokemon].hp = 0;
                    _battleInterface.EndBattleInterface(false);
                    break;
                }
                
                _battleInterface.RenderBattle();
                _input.Terminate();
                Thread.Sleep(1000);
                _input.Initialize();
                
                _renderer.Log("YOU USED: " + playerUsedMove.moveUsed, LogTypes.DEFAULT, true);
                damage =
                    Convert.ToInt16(
                        ((2 * PlayerPokemons[PlayerSelectedPokemon].level * criticalHit / 5 + 2) * playerUsedMove.power *
                            PlayerPokemons[PlayerSelectedPokemon].attack /
                            OpponentPokemons[OpponentSelectedPokemon].defense / 50 + 2) * 1 * firstDmgMultiplier *
                        secondDmgMultiplier * 1);

                OpponentPokemons[OpponentSelectedPokemon].hp -= damage;
                if (OpponentPokemons[OpponentSelectedPokemon].hp >= 0)
                {
                    OpponentPokemons[OpponentSelectedPokemon].hp = 0;
                    _battleInterface.EndBattleInterface(true);
                    break;
                }
                
                _battleInterface.RenderBattle();
                break;
        }
    }

    public void OpponentsMove(Pokemon opponentPokemon)
    {
        Random rnd = new Random();
        int random = rnd.Next(0, opponentPokemon.Moves.Count);

        opponentUsedMove.PokeMoves(opponentPokemon.Moves[random]);
    }
}