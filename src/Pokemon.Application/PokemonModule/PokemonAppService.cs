using System.Linq;
using AutoMapper;
using Pokemon.Application.Shared.Pokemons;
using Pokemon.Application.Shared.Pokemons.Dtos;
using Pokemon.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Application.PokemonModule
{
    public class PokemonAppService : IPokemonAppService
    {
        private readonly IMapper _mapper;
        private readonly IPokemonManager _pokemonManager;
        public PokemonAppService(IMapper mapper,
            IPokemonManager pokemonManager)
        {
            _mapper = mapper;
            _pokemonManager = pokemonManager;
        }
        public async Task<ServiceResponse<List<GetPokemonDto>>> GetAllPokemons()
        {
            var serviceResponse = new ServiceResponse<List<GetPokemonDto>>();
            try
            {
                var pokemons = await _pokemonManager.GetPokemonsAsync();
                serviceResponse.Data = pokemons.Select(p => _mapper.Map<GetPokemonDto>(p)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }            
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPokemonDto>> GetPokemonByName(string Name)
        {
            var serviceResponse = new ServiceResponse<GetPokemonDto>();
            try
            {

                var result = _mapper.Map<GetPokemonDto>(await  _pokemonManager.GetPokemonByNameAsync(Name));
                if (result == null)
                {
                    throw new Exception("Pokemon not found");
                }
                serviceResponse.Data = result;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}
