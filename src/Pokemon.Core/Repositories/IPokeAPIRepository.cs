using Pokemon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Core.Repositories
{
    public interface IPokeAPIRepository
    {
        Task<PokeApiNet.Pokemon> GetPokemonAPI(string name);
    }
}
