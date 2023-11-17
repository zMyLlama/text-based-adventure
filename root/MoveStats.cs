namespace root;

public class MoveStats
{
    public Types type;
    public int power;
    public int accuracy;
    public int pp;

    public List<Types> strongAgainst = new List<Types>();
    public List<Types> weakAgainst = new List<Types>();
    public List<Types> immuneAgainst = new List<Types>();

    public void PokeMoves(PokemonMoves move = PokemonMoves.TACKLE)
    {
        strongAgainst.Clear();
        weakAgainst.Clear();
        immuneAgainst.Clear();
        switch (move)
        {
            case PokemonMoves.TACKLE:
                type = Types.NORMAL;
                power = 35;
                accuracy = 95;
                pp = 35;
                immuneAgainst.Add(Types.GHOST);
                weakAgainst.Add(Types.ROCK);
                break;
            case PokemonMoves.GUST:
                type = Types.NORMAL;
                power = 40;
                accuracy = 100;
                pp = 35;
                immuneAgainst.Add(Types.GHOST);
                weakAgainst.Add(Types.ROCK);
                break;
            case PokemonMoves.EMBER:
                type = Types.FIRE;
                power = 40;
                accuracy = 100;
                pp = 25;
                strongAgainst.Add(Types.GRASS);
                strongAgainst.Add(Types.ICE);
                strongAgainst.Add(Types.BUG);
                weakAgainst.Add(Types.FIRE);
                weakAgainst.Add(Types.WATER);
                weakAgainst.Add(Types.ROCK);
                weakAgainst.Add(Types.DRAGON);
                /*10% chance of burning opponent*/
                break;
            case PokemonMoves.GROWL:
                type = Types.NORMAL;
                accuracy = 100;
                pp = 40;
                immuneAgainst.Add(Types.GHOST);
                weakAgainst.Add(Types.ROCK);
                /*lowers oppenents attack by 1 stage*/
                break;
            case PokemonMoves.BUBBLE:
                type = Types.WATER;
                power = 20;
                accuracy = 100;
                pp = 30;
                strongAgainst.Add(Types.FIRE);
                strongAgainst.Add(Types.GROUND);
                strongAgainst.Add(Types.ROCK);
                weakAgainst.Add(Types.WATER);
                weakAgainst.Add(Types.GRASS);
                weakAgainst.Add(Types.DRAGON);
                /*10% chance of lowering opponent speed by 1 stage*/
                break;
            case PokemonMoves.SCRATCH:
                type = Types.NORMAL;
                power = 40;
                accuracy = 100;
                pp = 35;
                immuneAgainst.Add(Types.GHOST);
                weakAgainst.Add(Types.ROCK);
                break;
            case PokemonMoves.TAIL_WHIP:
                type = Types.NORMAL;
                accuracy = 100;
                pp = 30;
                immuneAgainst.Add(Types.GHOST);
                weakAgainst.Add(Types.ROCK);
                /*lowers opponents defense by 1 stage*/
                break;
            case PokemonMoves.VINE_WHIP:
                type = Types.GRASS;
                power = 35;
                accuracy = 100;
                pp = 10;
                strongAgainst.Add(Types.WATER);
                strongAgainst.Add(Types.GROUND);
                strongAgainst.Add(Types.ROCK);
                weakAgainst.Add(Types.FIRE);
                weakAgainst.Add(Types.GRASS);
                weakAgainst.Add(Types.POISON);
                weakAgainst.Add(Types.FLYING);
                weakAgainst.Add(Types.BUG);
                weakAgainst.Add(Types.DRAGON);
                break;
            case PokemonMoves.SAND_ATTACK:
                type = Types.NORMAL;
                accuracy = 100;
                pp = 15;
                immuneAgainst.Add(Types.GHOST);
                weakAgainst.Add(Types.ROCK);
                /*lowers opponents accuracy by 1 stage*/
                break;
            case PokemonMoves.STRING_SHOT:
                type = Types.BUG;
                accuracy = 95;
                pp = 40;
                strongAgainst.Add(Types.GRASS);
                strongAgainst.Add(Types.POISON);
                strongAgainst.Add(Types.PSYCHIC);
                weakAgainst.Add(Types.FIRE);
                weakAgainst.Add(Types.FIGHTING);
                weakAgainst.Add(Types.FLYING);
                weakAgainst.Add(Types.GHOST);
                /*lowers opponents speed by 1 stage*/
                break;
            case PokemonMoves.POSION_STING:
                type = Types.POISON;
                power = 15;
                accuracy = 100;
                pp = 35;
                strongAgainst.Add(Types.GRASS);
                strongAgainst.Add(Types.BUG);
                weakAgainst.Add(Types.POISON);
                weakAgainst.Add(Types.GROUND);
                weakAgainst.Add(Types.ROCK);
                weakAgainst.Add(Types.GHOST);
                /*30% chance of poisoning opponent*/
                break;
            case PokemonMoves.QUICK_ATTACK:
                type = Types.NORMAL;
                power = 40;
                accuracy = 100;
                pp = 30;
                immuneAgainst.Add(Types.GHOST);
                weakAgainst.Add(Types.ROCK);
                /*this move has +1 priority, meaning it will go before other moves with less priority*/
                break;
        }
    }
}