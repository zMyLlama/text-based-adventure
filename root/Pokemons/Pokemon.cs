using System.Diagnostics;

namespace root;

public class Pokemon
{
    /*private Writer Writer = new Writer();*/

    public List<PokemonMoves> Moves = new List<PokemonMoves>();
    
    public int hp;
    public int maxHP;
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
                maxHP = 45;
                attack = 49;
                defense = 49;
                speed = 45;
                firstElementType = Types.GRASS;
                secondElementType = Types.POISON;
                Moves.Add(PokemonMoves.GROWL);
                Moves.Add(PokemonMoves.TACKLE);
                Moves.Add(PokemonMoves.VINE_WHIP);
                break;
            case PokemonNames.CHARMANDER:
                name = "CHARMANDER";
                hp = 39;
                maxHP = 39;
                attack = 52;
                defense = 43;
                speed = 65;
                firstElementType = Types.FIRE;
                Moves.Add(PokemonMoves.GROWL);
                Moves.Add(PokemonMoves.SCRATCH);
                Moves.Add(PokemonMoves.EMBER);
                break;
            case PokemonNames.SQUIRTLE:
                name = "SQUIRTLE";
                hp = 44;
                maxHP = 44;
                attack = 48;
                defense = 65;
                speed = 43;
                firstElementType = Types.WATER;
                Moves.Add(PokemonMoves.TAIL_WHIP);
                Moves.Add(PokemonMoves.TACKLE);
                Moves.Add(PokemonMoves.WATER_GUN);
                break;
            case PokemonNames.CATERPIE:
                name = "CATERPIE";
                hp = 45;
                maxHP = 45;
                attack = 30;
                defense = 35;
                speed = 45;
                firstElementType = Types.BUG;
                Moves.Add(PokemonMoves.STRING_SHOT);
                Moves.Add(PokemonMoves.TACKLE);
                break;
            case PokemonNames.WEEDLE:
                name = "WEEDLE";
                hp = 40;
                maxHP = 40;
                attack = 35;
                defense = 30;
                speed = 50;
                firstElementType = Types.BUG;
                secondElementType = Types.POISON;
                Moves.Add(PokemonMoves.POISON_STING);
                Moves.Add(PokemonMoves.STRING_SHOT);
                break;
            case PokemonNames.PIDGEY:
                name = "PIDGEY";
                hp = 40;
                maxHP = 40;
                attack = 45;
                defense = 40;
                speed = 56;
                firstElementType = Types.NORMAL;
                secondElementType = Types.FLYING;
                Moves.Add(PokemonMoves.SAND_ATTACK);
                Moves.Add(PokemonMoves.TACKLE);
                Moves.Add(PokemonMoves.GUST);
                break;
            case PokemonNames.RATTATA:
                name = "RATTATA";
                hp = 30;
                maxHP = 30;
                attack = 56;
                defense = 35;
                speed = 72;
                firstElementType = Types.NORMAL;
                Moves.Add(PokemonMoves.QUICK_ATTACK);
                Moves.Add(PokemonMoves.TACKLE);
                Moves.Add(PokemonMoves.TAIL_WHIP);
                break;
            
        }

        Random rnd = new Random();
        level = rnd.Next(2, 7);
        hp = Convert.ToInt16(rnd.Next(90, 110) / 100f * hp);
        maxHP = hp;
        attack = Convert.ToInt16(rnd.Next(90, 110) / 100f * attack);
        defense = Convert.ToInt16(rnd.Next(90, 110) / 100f * defense);
        speed = Convert.ToInt16(rnd.Next(90, 110) / 100f * speed);
        /*Writer.WriteToPosition("hp " + hp + "\nattack " + attack + "\ndefense " + defense + "\nspeed " + speed, WritePositions.LEFT);*/
    }
}