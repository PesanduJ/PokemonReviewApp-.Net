using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : Controller
    {
        private readonly IPokemonRepository _pokemonRepository;

        public PokemonController(IPokemonRepository pokemonRepository)
        {
            this._pokemonRepository = pokemonRepository;
        }


        //Get all pokemons
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        public IActionResult GetPokemons()
        {
            var pokemons = _pokemonRepository.GetPokemons();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(pokemons);
        }


        //Get pokemon by id
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Pokemon))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemon(int id)
        {
            if (!_pokemonRepository.PokemonExists(id))
            {
                return NotFound();
            }

            var pokemon = _pokemonRepository.GetPokemon(id);

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(pokemon);
        }


        [HttpGet("{name}")]
        [ProducesResponseType(200, Type = typeof(Pokemon))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemon(string name)
        {

            var pokemon = _pokemonRepository.GetPokemon(name);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(pokemon);
        }


    }
}
