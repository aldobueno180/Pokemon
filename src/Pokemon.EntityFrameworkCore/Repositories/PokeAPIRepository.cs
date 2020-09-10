using Newtonsoft.Json.Linq;
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
        public async Task<PokemonEntity> GetPokemonAPI(string name)
        {
            var result = new PokemonEntity();
            try
            {
                RestClient client = new RestClient("https://pokeapi.co/api/v2/");
                RestRequest request = new RestRequest("/pokemon/" + name, Method.GET);
                request.RequestFormat = DataFormat.Json;
                var response = client.Execute(request);
                if (response.IsSuccessful)
                {
                    JObject json = JObject.Parse(response.Content);
                    result.Name = name;
                    result.Description = response.Content;
                }
            }
            catch (Exception ex)
            {
                result.Name = "none";
                result.Description = ex.Message;
            }
            return result;
        }
    }
}
