namespace root;

public class WildPokemon
{
    private Pokemon[] palletTown = {new Pokemon(PokemonNames.PIDGEY), new Pokemon(PokemonNames.WEEDLE), new Pokemon(PokemonNames.RATTATA),new Pokemon(PokemonNames.CATERPIE)};
    private Random rnd;
    private int randomPokemon;

    private Pokemon wildPokemon;
    
    public void Route(string route)
    {
        switch (route)
        {
            case "pallet town":
                randomPokemon = rnd.Next(0, palletTown.Length);
                wildPokemon = palletTown[randomPokemon];
                break;
        }
    }
}