using Pokemon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Core.Repositories
{
    public interface IPokemonRepository
    {
        Task<List<PokemonEntity>> GetAll();
        Task<PokemonEntity> FirstOrDefaultAsync(Func<PokemonEntity, bool> where);
    }
}
