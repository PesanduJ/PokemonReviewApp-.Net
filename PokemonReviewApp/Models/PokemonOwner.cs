namespace PokemonReviewApp.Models
{
    public class PokemonOwner
    {
        //many-to-many relationship

        public int pokemonId { get; set; }

        public int ownerId { get; set; }

        public Pokemon pokemon { get; set; }

        public Owner owner { get; set; }


    }
}
