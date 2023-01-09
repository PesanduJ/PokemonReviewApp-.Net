using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DataContext _context;

        public PokemonRepository(DataContext context)
        {
            this._context = context;
        }

        public Pokemon GetPokemon(int id)
        {
            return _context.pokemons.Where(p => p.id == id).FirstOrDefault();
        }

        public Pokemon GetPokemon(string name)
        {
            return _context.pokemons.Where(p => p.name == name).FirstOrDefault();
        }

        public ICollection<Pokemon> GetPokemons()
        {
            return _context.pokemons.OrderBy(p => p.id).ToList();
        }

        public bool PokemonExists(int pokeId)
        { 
            return _context.pokemons.Any(p=>p.id == pokeId);
        }
    }
}
