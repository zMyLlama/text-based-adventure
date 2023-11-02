using System.Diagnostics;

namespace root;

public class Pokemon
{
    private Writer Writer = new Writer();
    
    private int hp;
    private int attack;
    private int defense;
    private int speed;
    private string type;


    /*public Pokemon(int hp, int attack, int defense, int speed)
    {
        this.hp = hp;
        this.attack = attack;
        this.defense = defense;
        this.speed = speed;
    }*/

    public void PokemonWithStats(PokemonNames pokemon = PokemonNames.BULBASAUR)
    {
        switch (pokemon)
        {
            case PokemonNames.BULBASAUR:
                hp = 45;
                attack = 49;
                defense = 49;
                speed = 45;
                break;
            case PokemonNames.IVYSAUR:
                hp = 60;
                attack = 62;
                defense = 63;
                speed = 60;
                break;
            case PokemonNames.VENUSAUR:
                hp = 80;
                attack = 82;
                defense = 83;
                speed = 80;
                break;
            case PokemonNames.CHARMANDER:
                hp = 39;
                attack = 52;
                defense = 43;
                speed = 65;
                break;
            case PokemonNames.CHARMELEON:
                hp = 58;
                attack = 64;
                defense = 58;
                speed = 80;
                break;
            case PokemonNames.CHARIZARD:
                hp = 78;
                attack = 84;
                defense = 78;
                speed = 100;
                break;
            case PokemonNames.SQUIRTLE:
                hp = 44;
                attack = 48;
                defense = 65;
                speed = 43;
                break;
            case PokemonNames.WARTORTLE:
                hp = 59;
                attack = 63;
                defense = 80;
                speed = 58;
                break;
            case PokemonNames.BLASTOISE:
                hp = 79;
                attack = 83;
                defense = 100;
                speed = 78;
                break;
            case PokemonNames.CATERPIE:
                hp = 45;
                attack = 30;
                defense = 35;
                speed = 45;
                break;
            case PokemonNames.METAPOD:
                hp = 50;
                attack = 20;
                defense = 55;
                speed = 30;
                break;
            case PokemonNames.BUTTERFREE:
                hp = 60;
                attack = 45;
                defense = 50;
                speed = 70;
                break;
            case PokemonNames.WEEDLE:
                hp = 40;
                attack = 35;
                defense = 30;
                speed = 50;
                break;
            case PokemonNames.KAKUNA:
                hp = 45;
                attack = 25;
                defense = 50;
                speed = 35;
                break;
            case PokemonNames.BEEDRILL:
                hp = 65;
                attack = 80;
                defense = 40;
                speed = 75;
                break;
            case PokemonNames.PIDGEY:
                hp = 40;
                attack = 45;
                defense = 40;
                speed = 56;
                break;
            case PokemonNames.PIDGEOTTO:
                hp = 63;
                attack = 60;
                defense = 55;
                speed = 71;
                break;
            case PokemonNames.PIDGEOT:
                hp = 83;
                attack = 80;
                defense = 75;
                speed = 91;
                break;
            case PokemonNames.RATTATA:
                hp = 30;
                attack = 56;
                defense = 35;
                speed = 72;
                break;
            case PokemonNames.RATICATE:
                hp = 55;
                attack = 81;
                defense = 60;
                speed = 97;
                break;
            case PokemonNames.SPEAROW:
                hp = 40;
                attack = 60;
                defense = 30;
                speed = 70;
                break;
            case PokemonNames.FEAROW:
                hp = 65;
                attack = 90;
                defense = 65;
                speed = 100;
                break;
            case PokemonNames.EKANS:
                hp = 35;
                attack = 60;
                defense = 44;
                speed = 55;
                break;
            case PokemonNames.ARBOK:
                hp = 60;
                attack = 85;
                defense = 69;
                speed = 80;
                break;
            case PokemonNames.PIKACHU:
                hp = 35;
                attack = 55;
                defense = 40;
                speed = 90;
                break;
            case PokemonNames.RAICHU:
                hp = 60;
                attack = 90;
                defense = 55;
                speed = 110;
                break;
            case PokemonNames.SANDSHREW:
                hp = 50;
                attack = 75;
                defense = 85;
                speed = 40;
                break;
            case PokemonNames.SANDSLASH:
                hp = 75;
                attack = 100;
                defense = 110;
                speed = 65;
                break;
            case PokemonNames.NIDORAN_F:
                hp = 55;
                attack = 47;
                defense = 52;
                speed = 41;
                break;
            case PokemonNames.NIDORINA:
                hp = 70;
                attack = 62;
                defense = 67;
                speed = 56;
                break;
            case PokemonNames.NIDOQUEEN:
                hp = 90;
                attack = 92;
                defense = 87;
                speed = 76;
                break;
            case PokemonNames.NIDORAN_M:
                hp = 46;
                attack = 57;
                defense = 40;
                speed = 50;
                break;
            case PokemonNames.NIDORINO:
                hp = 61;
                attack = 72;
                defense = 57;
                speed = 65;
                break;
            case PokemonNames.NIDOKING:
                hp = 81;
                attack = 102;
                defense = 77;
                speed = 85;
                break;
            case PokemonNames.CLEFAIRY:
                hp = 70;
                attack = 45;
                defense = 48;
                speed = 35;
                break;
            case PokemonNames.CLEFABLE:
                hp = 95;
                attack = 70;
                defense = 73;
                speed = 60;
                break;
            case PokemonNames.VULPIX:
                hp = 38;
                attack = 41;
                defense = 40;
                speed = 65;
                break;
            case PokemonNames.NINETALES:
                hp = 73;
                attack = 76;
                defense = 75;
                speed = 100;
                break;
            case PokemonNames.JIGGLYPUFF:
                hp = 115;
                attack = 45;
                defense = 20;
                speed = 20;
                break;
            case PokemonNames.WIGGLYTUFF:
                hp = 140;
                attack = 70;
                defense = 45;
                speed = 45;
                break;
            case PokemonNames.ZUBAT:
                hp = 40;
                attack = 45;
                defense = 35;
                speed = 55;
                break;
            case PokemonNames.GOLBAT:
                hp = 75;
                attack = 80;
                defense = 70;
                speed = 90;
                break;
            case PokemonNames.ODDISH:
                hp = 45;
                attack = 50;
                defense = 55;
                speed = 30;
                break;
            case PokemonNames.GLOOM:
                hp = 60;
                attack = 65;
                defense = 70;
                speed = 40;
                break;
            case PokemonNames.VILEPLUME:
                hp = 75;
                attack = 80;
                defense = 85;
                speed = 50;
                break;
            case PokemonNames.PARAS:
                hp = 35;
                attack = 70;
                defense = 55;
                speed = 25;
                break;
            case PokemonNames.PARASECT:
                hp = 60;
                attack = 95;
                defense = 80;
                speed = 30;
                break;
            case PokemonNames.VENONAT:
                hp = 60;
                attack = 55;
                defense = 50;
                speed = 45;
                break;
            case PokemonNames.VENOMOTH:
                hp = 70;
                attack = 65;
                defense = 60;
                speed = 90;
                break;
            case PokemonNames.DIGLETT:
                hp = 10;
                attack = 55;
                defense = 25;
                speed = 95;
                break;
            case PokemonNames.DUGTRIO:
                hp = 35;
                attack = 80;
                defense = 50;
                speed = 120;
                break;
            case PokemonNames.MEOWTH:
                hp = 40;
                attack = 45;
                defense = 35;
                speed = 90;
                break;
            case PokemonNames.PERSIAN:
                hp = 65;
                attack = 70;
                defense = 60;
                speed = 115;
                break;
            case PokemonNames.PSYDUCK:
                hp = 50;
                attack = 52;
                defense = 48;
                speed = 55;
                break;
            case PokemonNames.GOLDUCK:
                hp = 80;
                attack = 82;
                defense = 78;
                speed = 85;
                break;
            case PokemonNames.MANKEY:
                hp = 40;
                attack = 80;
                defense = 35;
                speed = 70;
                break;
            case PokemonNames.PRIMEAPE:
                hp = 65;
                attack = 105;
                defense = 60;
                speed = 95;
                break;
            case PokemonNames.GROWLITHE:
                hp = 55;
                attack = 70;
                defense = 45;
                speed = 60;
                break;
            case PokemonNames.ARCANINE:
                hp = 90;
                attack = 110;
                defense = 80;
                speed = 95;
                break;
            case PokemonNames.POLIWAG:
                hp = 40;
                attack = 50;
                defense = 40;
                speed = 90;
                break;
            case PokemonNames.POLIWHIRL:
                hp = 65;
                attack = 65;
                defense = 65;
                speed = 90;
                break;
            case PokemonNames.POLIWRATH:
                hp = 90;
                attack = 85;
                defense = 95;
                speed = 70;
                break;
            case PokemonNames.ABRA:
                hp = 25;
                attack = 20;
                defense = 15;
                speed = 90;
                break;
            case PokemonNames.KADABRA:
                hp = 40;
                attack = 35;
                defense = 30;
                speed = 105;
                break;
            case PokemonNames.ALAKAZAM:
                hp = 55;
                attack = 50;
                defense = 45;
                speed = 120;
                break;
            case PokemonNames.MACHOP:
                hp = 70;
                attack = 80;
                defense = 50;
                speed = 35;
                break;
            case PokemonNames.MACHOKE:
                hp = 80;
                attack = 100;
                defense = 70;
                speed = 45;
                break;
            case PokemonNames.MACHAMP:
                hp = 90;
                attack = 130;
                defense = 80;
                speed = 55;
                break;
            case PokemonNames.BELLSPROUT:
                hp = 50;
                attack = 75;
                defense = 35;
                speed = 40;
                break;
            case PokemonNames.WEEPINBELL:
                hp = 65;
                attack = 90;
                defense = 50;
                speed = 55;
                break;
            case PokemonNames.VICTREEBEL:
                hp = 80;
                attack = 105;
                defense = 65;
                speed = 70;
                break;
            case PokemonNames.TENTACOOL:
                hp = 40;
                attack = 40;
                defense = 35;
                speed = 70;
                break;
            case PokemonNames.TENTACRUEL:
                hp = 80;
                attack = 70;
                defense = 65;
                speed = 100;
                break;
            case PokemonNames.GEODUDE:
                hp = 40;
                attack = 80;
                defense = 100;
                speed = 20;
                break;
            case PokemonNames.GRAVELER:
                hp = 55;
                attack = 95;
                defense = 115;
                speed = 35;
                break;
            case PokemonNames.GOLEM:
                hp = 80;
                attack = 120;
                defense = 130;
                speed = 45;
                break;
            case PokemonNames.PONYTA:
                hp = 50;
                attack = 85;
                defense = 55;
                speed = 90;
                break;
            case PokemonNames.RAPIDASH:
                hp = 65;
                attack = 100;
                defense = 70;
                speed = 105;
                break;
            case PokemonNames.SLOWPOKE:
                hp = 90;
                attack = 65;
                defense = 65;
                speed = 15;
                break;
            case PokemonNames.SLOWBRO:
                hp = 95;
                attack = 75;
                defense = 110;
                speed = 30;
                break;
            case PokemonNames.MAGNEMITE:
                hp = 25;
                attack = 35;
                defense = 70;
                speed = 45;
                break;
            case PokemonNames.MAGNETON:
                hp = 50;
                attack = 60;
                defense = 95;
                speed = 70;
                break;
            case PokemonNames.FARFETCHD:
                hp = 52;
                attack = 65;
                defense = 55;
                speed = 60;
                break;
            case PokemonNames.DODUO:
                hp = 35;
                attack = 85;
                defense = 45;
                speed = 75;
                break;
            case PokemonNames.DODRIO:
                hp = 60;
                attack = 110;
                defense = 70;
                speed = 100;
                break;
            case PokemonNames.SEEL:
                hp = 65;
                attack = 45;
                defense = 55;
                speed = 45;
                break;
            case PokemonNames.DEWGONG:
                hp = 90;
                attack = 70;
                defense = 80;
                speed = 70;
                break;
            case PokemonNames.GRIMER:
                hp = 80;
                attack = 80;
                defense = 50;
                speed = 25;
                break;
            case PokemonNames.MUK:
                hp = 105;
                attack = 105;
                defense = 75;
                speed = 50;
                break;
            case PokemonNames.SHELLDER:
                hp = 30;
                attack = 65;
                defense = 100;
                speed = 40;
                break;
            case PokemonNames.CLOYSTER:
                hp = 50;
                attack = 95;
                defense = 180;
                speed = 70;
                break;
            case PokemonNames.GASTLY:
                hp = 30;
                attack = 35;
                defense = 30;
                speed = 80;
                break;
            case PokemonNames.HAUNTER:
                hp = 45;
                attack = 50;
                defense = 45;
                speed = 95;
                break;
            case PokemonNames.GENGAR:
                hp = 60;
                attack = 65;
                defense = 60;
                speed = 110;
                break;
            case PokemonNames.ONIX:
                hp = 35;
                attack = 45;
                defense = 160;
                speed = 70;
                break;
            case PokemonNames.DROWZEE:
                hp = 60;
                attack = 48;
                defense = 45;
                speed = 42;
                break;
            case PokemonNames.HYPNO:
                hp = 85;
                attack = 73;
                defense = 70;
                speed = 67;
                break;
            case PokemonNames.KRABBY:
                hp = 30;
                attack = 105;
                defense = 90;
                speed = 50;
                break;
            case PokemonNames.KINGLER:
                hp = 55;
                attack = 130;
                defense = 115;
                speed = 75;
                break;
            case PokemonNames.VOLTORB:
                hp = 40;
                attack = 30;
                defense = 50;
                speed = 100;
                break;
            case PokemonNames.ELECTRODE:
                hp = 60;
                attack = 50;
                defense = 70;
                speed = 140;
                break;
            case PokemonNames.EXEGGCUTE:
                hp = 60;
                attack = 40;
                defense = 80;
                speed = 40;
                break;
            case PokemonNames.EXEGGUTOR:
                hp = 95;
                attack = 95;
                defense = 85;
                speed = 55;
                break;
            case PokemonNames.CUBONE:
                hp = 50;
                attack = 50;
                defense = 95;
                speed = 35;
                break;
            case PokemonNames.MAROWAK:
                hp = 60;
                attack = 80;
                defense = 110;
                speed = 45;
                break;
            case PokemonNames.HITMONLEE:
                hp = 50;
                attack = 120;
                defense = 53;
                speed = 87;
                break;
            case PokemonNames.HITMONCHAN:
                hp = 50;
                attack = 105;
                defense = 79;
                speed = 76;
                break;
            case PokemonNames.LICKITUNG:
                hp = 90;
                attack = 55;
                defense = 75;
                speed = 30;
                break;
            case PokemonNames.KOFFING:
                hp = 40;
                attack = 65;
                defense = 95;
                speed = 35;
                break;
            case PokemonNames.WEEZING:
                hp = 65;
                attack = 90;
                defense = 120;
                speed = 60;
                break;
            case PokemonNames.RHYHORN:
                hp = 80;
                attack = 85;
                defense = 95;
                speed = 25;
                break;
            case PokemonNames.RHYDON:
                hp = 105;
                attack = 130;
                defense = 120;
                speed = 40;
                break;
            case PokemonNames.CHANSEY:
                hp = 250;
                attack = 5;
                defense = 5;
                speed = 50;
                break;
            case PokemonNames.TANGELA:
                hp = 65;
                attack = 55;
                defense = 115;
                speed = 60;
                break;
            case PokemonNames.KANGASKHAN:
                hp = 105;
                attack = 95;
                defense = 80;
                speed = 90;
                break;
            case PokemonNames.HORSEA:
                hp = 30;
                attack = 40;
                defense = 70;
                speed = 60;
                break;
            case PokemonNames.SEADRA:
                hp = 55;
                attack = 65;
                defense = 95;
                speed = 85;
                break;
            case PokemonNames.GOLDEEN:
                hp = 45;
                attack = 67;
                defense = 60;
                speed = 63;
                break;
            case PokemonNames.SEAKING:
                hp = 80;
                attack = 92;
                defense = 65;
                speed = 68;
                break;
            case PokemonNames.STARYU:
                hp = 30;
                attack = 45;
                defense = 55;
                speed = 85;
                break;
            case PokemonNames.STARMIE:
                hp = 60;
                attack = 75;
                defense = 85;
                speed = 115;
                break;
            case PokemonNames.MR_MIME:
                hp = 40;
                attack = 45;
                defense = 65;
                speed = 90;
                break;
            case PokemonNames.SCYTHER:
                hp = 70;
                attack = 110;
                defense = 80;
                speed = 105;
                break;
            case PokemonNames.JYNX:
                hp = 65;
                attack = 50;
                defense = 35;
                speed = 95;
                break;
            case PokemonNames.ELECTABUZZ:
                hp = 65;
                attack = 83;
                defense = 57;
                speed = 105;
                break;
            case PokemonNames.MAGMAR:
                hp = 65;
                attack = 95;
                defense = 57;
                speed = 93;
                break;
            case PokemonNames.PINSIR:
                hp = 65;
                attack = 125;
                defense = 100;
                speed = 85;
                break;
            case PokemonNames.TAUROS:
                hp = 75;
                attack = 100;
                defense = 95;
                speed = 110;
                break;
            case PokemonNames.MAGIKARP:
                hp = 20;
                attack = 10;
                defense = 55;
                speed = 80;
                break;
            case PokemonNames.GYARADOS:
                hp = 95;
                attack = 125;
                defense = 79;
                speed = 81;
                break;
            case PokemonNames.LAPRAS:
                hp = 130;
                attack = 85;
                defense = 80;
                speed = 60;
                break;
            case PokemonNames.DITTO:
                hp = 48;
                attack = 48;
                defense = 48;
                speed = 48;
                break;
            case PokemonNames.EEVEE:
                hp = 55;
                attack = 55;
                defense = 50;
                speed = 55;
                break;
            case PokemonNames.VAPOREON:
                hp = 130;
                attack = 65;
                defense = 60;
                speed = 65;
                break;
            case PokemonNames.JOLTEON:
                hp = 65;
                attack = 65;
                defense = 60;
                speed = 130;
                break;
            case PokemonNames.FLAREON:
                hp = 65;
                attack = 130;
                defense = 60;
                speed = 65;
                break;
            case PokemonNames.PORYGON:
                hp = 65;
                attack = 60;
                defense = 70;
                speed = 40;
                break;
            case PokemonNames.OMANYTE:
                hp = 35;
                attack = 40;
                defense = 100;
                speed = 35;
                break;
            case PokemonNames.OMASTAR:
                hp = 70;
                attack = 60;
                defense = 125;
                speed = 55;
                break;
            case PokemonNames.KABUTO:
                hp = 30;
                attack = 80;
                defense = 90;
                speed = 55;
                break;
            case PokemonNames.KABUTOPS:
                hp = 60;
                attack = 115;
                defense = 105;
                speed = 80;
                break;
            case PokemonNames.AERODACTYL:
                hp = 80;
                attack = 105;
                defense = 65;
                speed = 130;
                break;
            case PokemonNames.SNORLAX:
                hp = 160;
                attack = 110;
                defense = 65;
                speed = 30;
                break;
            case PokemonNames.ARTICUNO:
                hp = 90;
                attack = 85;
                defense = 100;
                speed = 85;
                break;
            case PokemonNames.ZAPDOS:
                hp = 90;
                attack = 90;
                defense = 85;
                speed = 100;
                break;
            case PokemonNames.MOLTRES:
                hp = 90;
                attack = 100;
                defense = 90;
                speed = 90;
                break;
            case PokemonNames.DRATINI:
                hp = 41;
                attack = 64;
                defense = 45;
                speed = 50;
                break;
            case PokemonNames.DRAGONAIR:
                hp = 61;
                attack = 84;
                defense = 65;
                speed = 70;
                break;
            case PokemonNames.DRAGONITE:
                hp = 91;
                attack = 134;
                defense = 95;
                speed = 80;
                break;
            case PokemonNames.MEWTWO:
                hp = 106;
                attack = 110;
                defense = 90;
                speed = 130;
                break;
            case PokemonNames.MEW:
                hp = 100;
                attack = 100;
                defense = 100;
                speed = 100;
                break;
        }

        Random rnd = new Random();
        hp = Convert.ToInt16(rnd.Next(90,110) / 100f * hp);
        attack = Convert.ToInt16(rnd.Next(90, 110) / 100f * attack);
        defense = Convert.ToInt16(rnd.Next(90, 110) / 100f * defense);
        speed = Convert.ToInt16(rnd.Next(90, 110) / 100f * speed);
        /*Writer.WriteToPosition("hp " + hp + "\nattack " + attack + "\ndefense " + defense + "\nspeed " + speed, WritePositions.LEFT);*/
    }
}