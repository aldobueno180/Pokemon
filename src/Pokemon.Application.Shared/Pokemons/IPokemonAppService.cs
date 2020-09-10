using Pokemon.Application.Shared.Pokemons.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Application.Shared.Pokemons
{
    public interface IPokemonAppService
    {
        Task<ServiceResponse<List<GetPokemonDto>>> GetAllPokemons();
        Task<ServiceResponse<GetPokemonDto>> GetPokemonByName(string Name);
    }
}
