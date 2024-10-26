using PokemonReviewApp.Models;

namespace PokemonReviewApp.Dto
{
    public class PokemonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

       
    }

    public static class PokemonMappers
    {

        public static ICollection<PokemonDto> toDto (ICollection<Pokemon> pokemons)
        {

            if (pokemons == null)
                return null;

            return pokemons.Select(p => new PokemonDto
            {
                // Map properties from Pokemon to PokemonDto
                Id = p.Id,
                Name = p.Name,
                // Add other property mappings
            }).ToList();
        }
        public static PokemonDto toDto(Pokemon pokemon)
        {
            if (pokemon == null)
                return null;

            return new PokemonDto
            {
                Id = pokemon.Id,
                Name = pokemon.Name,
                BirthDate = pokemon.BirthDate,
            };
        }
    }
}
