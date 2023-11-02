using System.Diagnostics;

namespace root;

public class Pokemon
{
    private int hp;
    private int attack;
    private int defense;
    private int speed;
    private string type;


    public Pokemon(int hp, int attack, int defense, int speed)
    {
        this.hp = hp;
        this.attack = attack;
        this.defense = defense;
        this.speed = speed;
    }

    public void PokemonMaker(PokemonNames pokemon = PokemonNames.BULBASAUR)
    {
        switch (pokemon)
        {
            case PokemonNames.BULBASAUR:
                
                break;
        }
    }
}