namespace PokemonReviewApp.Models
{
    public class PokemonCategory
    {

        //many-to-many relationship

        public int pokemonId { get; set; }

        public int categoryId { get; set; }

        public Pokemon pokemon { get; set; }

        public Category category { get; set; }
    }
}
