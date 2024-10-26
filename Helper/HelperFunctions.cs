using PokemonReviewApp.Controllers;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Repository;

namespace PokemonReviewApp.Helper
{
    public static class HelperFunctions
    {
        public static void AddTransientRepositories(IServiceCollection services)
        {
            services.AddTransient<IPokemonRepository, PokemonRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<Seed>();
        }
    }
}
