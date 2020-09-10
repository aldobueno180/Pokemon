using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pokemon.Application.Shared.Pokemons;

namespace Pokemon.Web.Mvc.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonAppService _pokemonAppService;
        public PokemonController(IPokemonAppService pokemonAppService)
        {
            _pokemonAppService = pokemonAppService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _pokemonAppService.GetAllPokemons());
        }
        [HttpGet("{name}")]
        public async Task<IActionResult> GetSingle(string name)
        {
            var response = await _pokemonAppService.GetPokemonByName(name);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

    }
}
