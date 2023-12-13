namespace root;

public class WildPokemon
{
    private Pokemon[] palletTown = {new Pokemon(PokemonNames.PIDGEY), new Pokemon(PokemonNames.WEEDLE), new Pokemon(PokemonNames.RATTATA),new Pokemon(PokemonNames.CATERPIE)};
    private Random rnd = new Random();

    public Pokemon pokemon;
    
    public WildPokemon(string route)
    {
        switch (route)
        {
            case "PALLET TOWN":
                pokemon = palletTown[rnd.Next(palletTown.Length)];
                break;
        }
    }
}