namespace PokemonReviewApp.Models
{
    public class PokemonOwner
    {
        //join tables

        public int pokemonId { get; set; }

        public int ownerId { get; set; }

        public Pokemon pokemon { get; set; }

        public Owner owner { get; set; }

    }
}
