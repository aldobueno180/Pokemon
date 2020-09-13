using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Pokemon.Application.PokemonModule;
using Pokemon.Application.Shared.Pokemons;
using Pokemon.Core;
using Pokemon.Core.Repositories;
using Pokemon.EntityFrameworkCore.Repositories;
using Pokemon.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon.Tests
{
    public class TestServiceProvider
    {
        public TestServiceProvider()
        {
            var services = new ServiceCollection();
            services.AddAutoMapper(typeof(Startup));
            services.AddTransient<IPokemonAppService, PokemonAppService>();
            services.AddTransient<IPokemonManager, PokemonManager>();
            services.AddTransient<IPokemonRepository, PokemonRepository>();
            services.AddTransient<IPokeAPIRepository, PokeAPIRepository>();
            services.AddTransient<IShakespeareWebAppRepository, ShakespeareWebAppRepository>();
            _serviceProvider = services.BuildServiceProvider();
        }
        private ServiceProvider _serviceProvider { get; set; }
        public ServiceProvider GetServiceProvider()
        {
            return _serviceProvider;
        }
    }
}
