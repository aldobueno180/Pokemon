using AutoMapper;
using Pokemon.Application.Shared.Pokemons.Dtos;
using Pokemon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokemon.Web.Mvc
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PokemonEntity, GetPokemonDto>();
        }
    }
}
