using PokeApiNet;
using PokeInfo.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeInfo.Service;

public class PokeService
{
    PokeApiNet.PokeApiClient pokeApi = new PokeApiClient();

    public async Task<int> GetNumberOfPokemons()
    {
        var A = await pokeApi.GetNamedResourcePageAsync<Pokemon>(1, 0);
        return A.Count;
    }

    public async Task<List<PokemonDto>> GetListOfPokemons()
    {
        var count = await GetNumberOfPokemons();
        var data = await pokeApi.GetNamedResourcePageAsync<Pokemon>(count, 0);

        var poke = new List<PokemonDto>();
        for (int i = 0 ; i < data.Results.Count ; i++)
        {
            var item = data.Results[i];
            var path = $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/{i + 1}.png";
            poke.Add(new PokemonDto
            {
                Id = i,
                Name = item.Name,
                URL = item.Url,
                Path = path
            });
        }
        return poke;
    }

    public async Task<Pokemon> GetPokemonByName(string name)
    {
        return await pokeApi.GetResourceAsync<Pokemon>(name);
    }
}