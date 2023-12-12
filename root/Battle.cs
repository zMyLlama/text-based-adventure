namespace root;

public class Battle
{
    private Writer Writer = new Writer();

    private int currentPokemon = 0;
    private int oppoCurrentPokemon = 0;

    public MoveStats currentMove = new MoveStats();
    public MoveStats oppoCurrentMove = new MoveStats();
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

    public void Fight(List<Pokemon> OpponentPokemons, List<Pokemon> YourPokemons)
    {
        while (ongoingBattle)
        {
            BattleInterface(OpponentPokemons[oppoCurrentPokemon], YourPokemons[currentPokemon]);
            string command = Console.ReadLine().ToUpper();
            switch (command)
            {
                case "GUST":
                    moveUsed = PokemonMoves.GUST;
                    if (YourPokemons[currentPokemon].Moves.Contains(moveUsed))
                    {
                        currentMove.PokeMoves(PokemonMoves.GUST);
                    }
                    else
                        continue;
                    break;

                case "SAND ATTACK":
                    moveUsed = PokemonMoves.SAND_ATTACK;
                    if (YourPokemons[currentPokemon].Moves.Contains(moveUsed))
                    {
                        currentMove.PokeMoves(PokemonMoves.SAND_ATTACK);
                    }
                    else
                        continue;
                    break;

                case "TACKLE":
                    moveUsed = PokemonMoves.TACKLE;
                    if (YourPokemons[currentPokemon].Moves.Contains(moveUsed))
                    {
                        currentMove.PokeMoves(PokemonMoves.TACKLE);
                    }
                    else
                        continue;
                    break;

                case "TAIL WHIP":
                    moveUsed = PokemonMoves.TAIL_WHIP;
                    if (YourPokemons[currentPokemon].Moves.Contains(moveUsed))
                    {
                        currentMove.PokeMoves(PokemonMoves.TAIL_WHIP);
                    }
                    else
                        continue;
                    break;

                case "QUICK ATTACK":
                    moveUsed = PokemonMoves.QUICK_ATTACK;
                    if (YourPokemons[currentPokemon].Moves.Contains(moveUsed))
                    {
                        currentMove.PokeMoves(PokemonMoves.QUICK_ATTACK);
                    }
                    else
                        continue;
                    break;

                case "GROWL":
                    moveUsed = PokemonMoves.GROWL;
                    if (YourPokemons[currentPokemon].Moves.Contains(moveUsed))
                    {
                        currentMove.PokeMoves(PokemonMoves.GROWL);
                    }
                    else
                        continue;
                    break;

                case "VINE WHIP":
                    moveUsed = PokemonMoves.VINE_WHIP;
                    if (YourPokemons[currentPokemon].Moves.Contains(moveUsed))
                    {
                        currentMove.PokeMoves(PokemonMoves.VINE_WHIP);
                    }
                    else
                        continue;
                    break;

                case "SCRATCH":
                    moveUsed = PokemonMoves.SCRATCH;
                    if (YourPokemons[currentPokemon].Moves.Contains(moveUsed))
                    {
                        currentMove.PokeMoves(PokemonMoves.SCRATCH);
                    }
                    else
                        continue;
                    break;

                case "EMBER":
                    moveUsed = PokemonMoves.EMBER;
                    if (YourPokemons[currentPokemon].Moves.Contains(moveUsed))
                    {
                        currentMove.PokeMoves(PokemonMoves.EMBER);
                    }
                    else
                        continue;
                    break;

                case "BUBBLE":
                    moveUsed = PokemonMoves.BUBBLE;
                    if (YourPokemons[currentPokemon].Moves.Contains(moveUsed))
                    {
                        currentMove.PokeMoves(PokemonMoves.BUBBLE);
                    }
                    else
                        continue;
                    break;

                case "STRING SHOT":
                    moveUsed = PokemonMoves.STRING_SHOT;
                    if (YourPokemons[currentPokemon].Moves.Contains(moveUsed))
                    {
                        currentMove.PokeMoves(PokemonMoves.STRING_SHOT);
                    }
                    else
                        continue;
                    break;

                case "POISON STING":
                    moveUsed = PokemonMoves.POISON_STING;
                    if (YourPokemons[currentPokemon].Moves.Contains(moveUsed))
                    {
                        currentMove.PokeMoves(PokemonMoves.POISON_STING);
                    }
                    else
                        continue;
                    break;
                
                case "stats":
                    Writer.WriteToPosition("" + YourPokemons[currentPokemon].defense);
                    Writer.WriteToPosition("" + YourPokemons[currentPokemon].attack);
                    Writer.WriteToPosition("" + YourPokemons[currentPokemon].speed);
                    Writer.WriteToPosition("" + YourPokemons[currentPokemon].level);
                    Writer.WriteToPosition("" + YourPokemons[currentPokemon].hp);
                    Writer.WriteToPosition("" + YourPokemons[currentPokemon].firstElementType);
                    Writer.WriteToPosition("" + YourPokemons[currentPokemon].secondElementType);
                    Writer.WriteToPosition("" + YourPokemons[currentPokemon].Moves);
                    break;
                
                default: continue;
            }

            if (currentMove.immuneAgainst.Contains(OpponentPokemons[oppoCurrentPokemon].firstElementType) ||
                currentMove.immuneAgainst.Contains(OpponentPokemons[oppoCurrentPokemon].secondElementType))
            {
                firstDmgMultiplier = 0;
                secondDmgMultiplier = 0;
            }
            else if (currentMove.strongAgainst.Contains(OpponentPokemons[oppoCurrentPokemon].firstElementType))
                firstDmgMultiplier = 2;
            else if (currentMove.weakAgainst.Contains(OpponentPokemons[oppoCurrentPokemon].firstElementType))
                firstDmgMultiplier = 0.5f;
            else
                firstDmgMultiplier = 1;

            if (currentMove.strongAgainst.Contains(OpponentPokemons[oppoCurrentPokemon].secondElementType))
                secondDmgMultiplier = 2;
            else if (currentMove.weakAgainst.Contains(OpponentPokemons[oppoCurrentPokemon].secondElementType))
                secondDmgMultiplier = 0.5f;
            else
                secondDmgMultiplier = 1;
            
            OpponentsMove(OpponentPokemons[oppoCurrentPokemon]);
            if (oppoCurrentMove.immuneAgainst.Contains(YourPokemons[currentPokemon].firstElementType) ||
                oppoCurrentMove.immuneAgainst.Contains(YourPokemons[currentPokemon].secondElementType))
            {
                oppoFirstDmgMultiplier = 0;
                oppoSecondDmgMultiplier = 0;
            }
            else if (oppoCurrentMove.strongAgainst.Contains(YourPokemons[currentPokemon].firstElementType))
                oppoFirstDmgMultiplier = 2;
            else if (oppoCurrentMove.weakAgainst.Contains(YourPokemons[currentPokemon].firstElementType))
                oppoFirstDmgMultiplier = 0.5f;
            else
                oppoFirstDmgMultiplier = 1;

            if (oppoCurrentMove.strongAgainst.Contains(YourPokemons[currentPokemon].secondElementType))
                oppoSecondDmgMultiplier = 2;
            else if (oppoCurrentMove.weakAgainst.Contains(YourPokemons[currentPokemon].secondElementType))
                oppoSecondDmgMultiplier = 0.5f;
            else
                oppoSecondDmgMultiplier = 1;

            Random rnd = new Random();
            criticalHit = rnd.Next(1, 255);
            if (criticalHit < YourPokemons[currentPokemon].speed / 2)
                criticalHit = 1.5f;
            else
                criticalHit = 1f;

            if (criticalHit < OpponentPokemons[oppoCurrentPokemon].speed / 2)
                oppoCriticalHit = 1.5f;
            else
                criticalHit = 1f;
            
            if (YourPokemons[currentPokemon].speed >= OpponentPokemons[oppoCurrentPokemon].speed)
                fightOrder = 1;
            else
                fightOrder = 2;


            switch (fightOrder)
            {
                case 1: //player attacks first
                    damage =
                        Convert.ToInt16(
                            ((2 * YourPokemons[currentPokemon].level * criticalHit / 5 + 2) * currentMove.power *
                                YourPokemons[currentPokemon].attack /
                                OpponentPokemons[oppoCurrentPokemon].defense / 50 + 2) * 1 * firstDmgMultiplier *
                            secondDmgMultiplier * 1);
                    OpponentPokemons[oppoCurrentPokemon].hp -= damage;
                    if (OpponentPokemons[oppoCurrentPokemon].hp <= 0)
                    {
                        OpponentPokemons[oppoCurrentPokemon].hp = 0;
                        break;
                    }
                        BattleInterface(OpponentPokemons[oppoCurrentPokemon], YourPokemons[currentPokemon]);
                        Thread.Sleep(500);
                        BattleInterface(OpponentPokemons[oppoCurrentPokemon], YourPokemons[currentPokemon]);
                        damage =
                            Convert.ToInt16(
                                ((2 * OpponentPokemons[oppoCurrentPokemon].level * criticalHit / 5 + 2) *
                                    oppoCurrentMove.power * OpponentPokemons[oppoCurrentPokemon].attack /
                                    YourPokemons[currentPokemon].defense / 50 + 2) * 1 * firstDmgMultiplier *
                                secondDmgMultiplier * 1);
                    YourPokemons[currentPokemon].hp -= damage;
                    if (YourPokemons[currentPokemon].hp <= 0)
                            YourPokemons[currentPokemon].hp = 0;
                    break;
                case 2: //opponent attacks first
                    damage =
                        Convert.ToInt16(
                            ((2 * OpponentPokemons[oppoCurrentPokemon].level * criticalHit / 5 + 2) *
                                oppoCurrentMove.power * OpponentPokemons[oppoCurrentPokemon].attack /
                                YourPokemons[currentPokemon].defense / 50 + 2) * 1 * firstDmgMultiplier *
                            secondDmgMultiplier * 1);
                    YourPokemons[currentPokemon].hp -= damage;
                    if (YourPokemons[currentPokemon].hp <= 0)
                        {
                            YourPokemons[currentPokemon].hp = 0;
                            break;
                        }
                    
                        BattleInterface(OpponentPokemons[oppoCurrentPokemon], YourPokemons[currentPokemon]);
                        Thread.Sleep(500);
                        BattleInterface(OpponentPokemons[oppoCurrentPokemon], YourPokemons[currentPokemon]);
                        damage =
                            Convert.ToInt16(
                                ((2 * YourPokemons[currentPokemon].level * criticalHit / 5 + 2) * currentMove.power *
                                    YourPokemons[currentPokemon].attack /
                                    OpponentPokemons[oppoCurrentPokemon].defense / 50 + 2) * 1 * firstDmgMultiplier *
                                secondDmgMultiplier * 1);

                    OpponentPokemons[oppoCurrentPokemon].hp -= damage;
                    if (OpponentPokemons[oppoCurrentPokemon].hp >= 0)
                        OpponentPokemons[oppoCurrentPokemon].hp = 0;
                    break;
            }

            /*if (OpponentPokemons[oppoCurrentPokemon].hp <= 0)
            {
                Console.Clear();
                Thread.Sleep(2000);
                YouWin();
                Thread.Sleep(2000);
                Console.Clear();
                break;
            }*/
            Console.SetCursorPosition(0,0);
        }
    }

    public void BattleInterface(Pokemon OpponentPokemon, Pokemon YourPokemon)
    {
        Console.SetCursorPosition(0,0);
        Writer.WriteToPosition("" + OpponentPokemon.name,WritePositions.CENTER, false);
        Writer.WriteToPosition("HP: " + OpponentPokemon.hp + "\n\n\n\n\n" ,WritePositions.MIDLEFT);
        Writer.WriteToPosition("" + YourPokemon.name,WritePositions.LEFT, false);
        Writer.WriteToPosition("HP: " + YourPokemon.hp,WritePositions.MIDLEFT);
    }

    public void YouWin()
    {
        Console.WriteLine("You Win!");
    }

    public void OpponentsMove(Pokemon OpponentPokemon)
    {
        Random rnd = new Random();
        int random = rnd.Next(0, OpponentPokemon.Moves.Count);

        oppoCurrentMove.PokeMoves(OpponentPokemon.Moves[random]);
    }
}