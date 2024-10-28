using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        ICollection<Pokemon> GetPokemonCategories(int id);
        Category GetCategory(int id);
        bool CategoryExists(int id);
        bool CreateCategory(Category category);
    }
}
