using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;
using System.Linq;
using System.Collections.Generic;


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
            return _context.Pokemons.OrderBy(p => p.Id).ToList();
        }

        public Pokemon GetPokemonById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID must be greater than zero.", nameof(id));
            }

            var pokemon = _context.Pokemons.Where(p => p.Id == id).FirstOrDefault();


            return pokemon;
        }


        public Pokemon GetPokemon(string name)
        {

            return _context.Pokemons.Where(p => p.Name == name).FirstOrDefault();
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
            var pokemon = _context.Pokemons.Find(id);
            
            if (pokemon == null)
            {
                return false;
            }

            _context.Pokemons.Remove(pokemon);
            _context.SaveChanges();

            return true;

        }

        public Pokemon Add(Pokemon pokemon)
        {
            if (pokemon == null)
            {
                throw new ArgumentNullException(nameof(pokemon));
            }

            _context.Pokemons.Add(pokemon);
            _context.SaveChanges();

            return pokemon;
        }



        public bool PokemonExists(int id)
        {
            return _context.Pokemons.Any(p => p.Id == id);
        }

        public bool PokemonExists(string name)
        {
            return _context.Pokemons.Any(p => p.Name == name);
        }
    }
}
