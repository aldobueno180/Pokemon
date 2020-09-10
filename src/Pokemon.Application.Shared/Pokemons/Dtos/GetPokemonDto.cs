using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon.Application.Shared.Pokemons.Dtos
{
    public class GetPokemonDto
    {
        public string Name { get; set; } = "Charizard";
        public string Description { get; set; } = "Big pokemon with flames from its mouth";
    }
}
