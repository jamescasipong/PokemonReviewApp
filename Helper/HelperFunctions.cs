using AutoMapper;
using PokemonReviewApp.Controllers;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;
using PokemonReviewApp.Repository;
using System.Reflection.Metadata.Ecma335;

namespace PokemonReviewApp.Helper
{
    public static class HelperFunctions
    {
        public static void AddTransientRepositories(IServiceCollection services)
        {
            services.AddTransient<IPokemonRepository, PokemonRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<IOwnerRepository, OwnerRepository>();
            services.AddTransient<IReviewRepository, ReviewRepository>();
            services.AddTransient<IReviewerRepository, ReviewerRepository>();
            services.AddTransient<Seed>();
        }       
    }
}
