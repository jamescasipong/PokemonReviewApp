using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class PokemonRepository: IPokemonRepository
    {
        private readonly DataContext _context;
        public PokemonRepository(DataContext context) { 
            _context = context;
        }

        public ICollection<Pokemon> GetAll()
        {
            return _context.Pokemon.OrderBy(p => p.Id).ToList();
        }

        public Pokemon GetPokemonById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID must be greater than zero.", nameof(id));
            }

            var pokemon = _context.Pokemon.Where(p => p.Id == id).FirstOrDefault();


            return pokemon;
        }


        public Pokemon GetPokemon(string name)
        {

            return _context.Pokemon.Where(p => p.Name == name).FirstOrDefault();
        }


        public int Rating(int rating)
        {
            if (rating <= 0)
            {
                throw new ArgumentException();
            }

            var review = _context.Reviews.Where(p => p.Rating == rating);

            if (review.Count() <= 0)
            {
                return 0;
            }

            return review.Sum(p => p.Rating / review.Count());
        }

        public bool Delete(int id)
        {
            var pokemon = _context.Pokemon.Find(id);
            
            if (pokemon == null)
            {
                return false;
            }

            _context.Pokemon.Remove(pokemon);
            _context.SaveChanges();

            return true;

        }

        public Pokemon Add(Pokemon pokemon)
        {
            if (pokemon == null)
            {
                throw new ArgumentNullException(nameof(pokemon));
            }

            _context.Pokemon.Add(pokemon);
            _context.SaveChanges();

            return pokemon;
        }



        public bool PokemonExists(int id)
        {
            return _context.Pokemon.Any(p => p.Id == id);
        }

        public bool PokemonExists(string name)
        {
            return _context.Pokemon.Any(p => p.Name == name);
        }
    }
}
