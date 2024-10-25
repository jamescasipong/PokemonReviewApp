using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetAll();
        Pokemon GetPokemon(string id);
        Pokemon GetPokemonById(int id);
        bool PokemonExists(int id);
        bool PokemonExists(string id);

        bool Delete(int id);
        int Rating(int id);
        
        Pokemon Add(Pokemon pokemon);
    }
}
