using Newtonsoft.Json;
using Pokemon.Core.Entities;
using Pokemon.Core.Repositories;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.EntityFrameworkCore.Repositories
{
    public class PokeAPIRepository : IPokeAPIRepository
    {
        public async Task<PokeApiNet.Pokemon> GetPokemonAPI(string name)
        {
            PokeApiNet.Pokemon pokemonItem = new PokeApiNet.Pokemon();
            try
            {
                RestClient client = new RestClient("https://pokeapi.co/api/v2/");
                RestRequest request = new RestRequest("/pokemon/" + name, Method.GET);
                request.RequestFormat = DataFormat.Json;
                var response = client.Execute(request);
                if (response.IsSuccessful)
                {
                    pokemonItem = JsonConvert.DeserializeObject<PokeApiNet.Pokemon>(response.Content);
                }
                else
                {
                    throw new Exception("Pokemon not found in PokeApi");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return pokemonItem;
        }
    }
}
