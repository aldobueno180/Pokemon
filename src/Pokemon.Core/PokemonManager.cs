using Pokemon.Core.Entities;
using Pokemon.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Core
{
    public class PokemonManager : IPokemonManager
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IPokeAPIRepository _pokeAPIRepository;
        public PokemonManager(IPokemonRepository pokemonRepository,
            IPokeAPIRepository pokeAPIRepository)
        {
            _pokemonRepository = pokemonRepository;
            _pokeAPIRepository = pokeAPIRepository;
        }

        public async Task<PokemonEntity> GetPokemonByNameAsync(string name)
        {
            var pokemon = await _pokemonRepository.FirstOrDefaultAsync(p => p.Name.ToLower().Equals(name.ToLower()));
            var pokeapi = await _pokeAPIRepository.GetPokemonAPI(name);
            return pokemon;
        }

        public async Task<List<PokemonEntity>> GetPokemonsAsync()
        {
            return await _pokemonRepository.GetAll();
        }
    }
}
