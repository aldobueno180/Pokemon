using System;
using System.Collections.Generic;
using System.Text;
using Pokemon.Core.Entities;
using System.Threading.Tasks;


namespace Pokemon.Core
{
    public interface IPokemonManager
    {
        Task<PokemonEntity> GetPokemonByNameAsync(string name);
        Task<List<PokemonEntity>> GetPokemonsAsync();
    }
}
