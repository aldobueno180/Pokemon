using Microsoft.Extensions.DependencyInjection;
using Pokemon.Application.PokemonModule;
using Pokemon.Application.Shared.Pokemons;
using System;
using Xunit;

namespace Pokemon.Tests
{
    public class PokemonAppService_Test : IClassFixture<TestServiceProvider>
    {
        private readonly IPokemonAppService _pokemonAppService;
        public PokemonAppService_Test(TestServiceProvider testServiceProvider)
        {
            var serviceProvide = testServiceProvider.GetServiceProvider();
            _pokemonAppService = serviceProvide.GetService<IPokemonAppService>();
        }
        [Fact]
        public void GettingPokemonByName()
        {
            Assert.ThrowsAsync<Exception>(() => _pokemonAppService.GetPokemonByName("abcde"));
        }
    }
}
