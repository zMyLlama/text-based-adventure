using System.Diagnostics;

namespace root;

public class Pokemon
{
    /*private Writer Writer = new Writer();*/
    public MoveStats Move1 = new MoveStats();
    public MoveStats Move2 = new MoveStats();
    public MoveStats Move3 = new MoveStats();
    public MoveStats Move4 = new MoveStats();

    public PokemonMoves[] Moves = new PokemonMoves[4];
    
    public int hp;
    public int attack;
    public int defense;
    public int speed;
    public string name;
    public Types firstElementType;
    public Types secondElementType;
    public int level;
    
    


    public Pokemon(PokemonNames pokemon = PokemonNames.BULBASAUR)
    {
        PokemonWithStats(pokemon);
    }

    public void PokemonWithStats(PokemonNames pokemon = PokemonNames.BULBASAUR)
    {
        switch (pokemon)
        {
            case PokemonNames.BULBASAUR:
                name = "BULBASAUR";
                hp = 45;
                attack = 49;
                defense = 49;
                speed = 45;
                firstElementType = Types.GRASS;
                secondElementType = Types.POISON;
                Moves[0] = PokemonMoves.GROWL;
                Moves[1] = PokemonMoves.TACKLE;
                Moves[2] = PokemonMoves.VINE_WHIP;
                break;
            case PokemonNames.CHARMANDER:
                name = "CHARMANDER";
                hp = 39;
                attack = 52;
                defense = 43;
                speed = 65;
                firstElementType = Types.FIRE;
                Moves[0] = PokemonMoves.GROWL;
                Moves[1] = PokemonMoves.SCRATCH;
                Moves[2] = PokemonMoves.EMBER;
                break;
            case PokemonNames.SQUIRTLE:
                name = "SQUIRTLE";
                hp = 44;
                attack = 48;
                defense = 65;
                speed = 43;
                firstElementType = Types.WATER;
                Moves[0] = PokemonMoves.TAIL_WHIP;
                Moves[1] = PokemonMoves.TACKLE;
                Moves[2] = PokemonMoves.WATER_GUN;
                break;
            case PokemonNames.CATERPIE:
                name = "CATERPIE";
                hp = 45;
                attack = 30;
                defense = 35;
                speed = 45;
                firstElementType = Types.BUG;
                Moves[0] = PokemonMoves.STRING_SHOT;
                Moves[1] = PokemonMoves.TACKLE;
                break;
            case PokemonNames.WEEDLE:
                name = "WEEDLE";
                hp = 40;
                attack = 35;
                defense = 30;
                speed = 50;
                firstElementType = Types.BUG;
                secondElementType = Types.POISON;
                Moves[0] = PokemonMoves.POISON_STING;
                Moves[1] = PokemonMoves.STRING_SHOT;
                break;
            case PokemonNames.PIDGEY:
                name = "PIDGEY";
                hp = 40;
                attack = 45;
                defense = 40;
                speed = 56;
                firstElementType = Types.NORMAL;
                secondElementType = Types.FLYING;
                Moves[0] = PokemonMoves.SAND_ATTACK;
                Moves[1] = PokemonMoves.TACKLE;
                Moves[2] = PokemonMoves.GUST;
                break;
            case PokemonNames.RATTATA:
                name = "RATTATA";
                hp = 30;
                attack = 56;
                defense = 35;
                speed = 72;
                firstElementType = Types.NORMAL;
                Moves[0] = PokemonMoves.QUICK_ATTACK;
                Moves[1] = PokemonMoves.TACKLE;
                Moves[2] = PokemonMoves.TAIL_WHIP;
                break;
            
        }

        Random rnd = new Random();
        level = rnd.Next(2, 7);
        hp = Convert.ToInt16(rnd.Next(90, 110) / 100f * hp);
        attack = Convert.ToInt16(rnd.Next(90, 110) / 100f * attack);
        defense = Convert.ToInt16(rnd.Next(90, 110) / 100f * defense);
        speed = Convert.ToInt16(rnd.Next(90, 110) / 100f * speed);
        /*Writer.WriteToPosition("hp " + hp + "\nattack " + attack + "\ndefense " + defense + "\nspeed " + speed, WritePositions.LEFT);*/
    }
}