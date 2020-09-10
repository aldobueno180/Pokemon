using Pokemon.Core.Entities;
using Pokemon.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.EntityFrameworkCore.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private static List<PokemonEntity> pokemons = new List<PokemonEntity>
        {
            new PokemonEntity(),
            new PokemonEntity(){Name = "pikachu" , Description = "small pokemon with electricity"}
        };
        public async Task<PokemonEntity> FirstOrDefaultAsync(Func<PokemonEntity, bool> where)
        {
            var result = pokemons.FirstOrDefault(where);
            return result;
        }

        public Task<List<PokemonEntity>> GetAll()
        {
            return Task.FromResult(pokemons);
        }
    }
}
