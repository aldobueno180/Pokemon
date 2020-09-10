using Pokemon.Core.Entities;
using Pokemon.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Core
{
    public class PokemonManager : IPokemonManager
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IPokeAPIRepository _pokeAPIRepository;
        private readonly IShakespeareWebAppRepository _shakespeareWebAppRepository;
        public PokemonManager(IPokemonRepository pokemonRepository
            , IPokeAPIRepository pokeAPIRepository
            , IShakespeareWebAppRepository shakespeareWebAppRepository)
        {
            _pokemonRepository = pokemonRepository;
            _pokeAPIRepository = pokeAPIRepository;
            _shakespeareWebAppRepository = shakespeareWebAppRepository;
        }

        public async Task<PokemonEntity> GetPokemonByNameAsync(string name)
        {
            try
            {
                var pokemon = new PokemonEntity();
                var pokeapi = await _pokeAPIRepository.GetPokemonAPI(name);
                //abilities
                var abilitiesitems = pokeapi.Abilities.Select(a => a.Ability.Name).ToArray();
                string abilities = string.Join(", ", abilitiesitems.Take(abilitiesitems.Length - 1)) + (abilitiesitems.Length <= 1 ? "" : " and ") + abilitiesitems.LastOrDefault();

                //type
                var typeitems = pokeapi.Types.Select(t => t.Type.Name).ToArray();
                var types = string.Join(", ", typeitems.Take(typeitems.Length - 1)) + (typeitems.Length <= 1 ? "" : " and ") + typeitems.LastOrDefault();

                string description = pokeapi.Name
                        + " is a pokemon of type " + types + ", "
                        + " having abilities like " + abilities + ".";

                var shakespeareDescription = await _shakespeareWebAppRepository.TranslateText(description);

                pokemon.Name = pokeapi.Name;
                pokemon.Description = shakespeareDescription;
                return pokemon;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<List<PokemonEntity>> GetPokemonsAsync()
        {
            return await _pokemonRepository.GetAll();
        }
    }
}
