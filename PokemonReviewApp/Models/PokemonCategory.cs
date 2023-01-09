namespace PokemonReviewApp.Models
{
    public class PokemonCategory
    {
        //join tables

        public int pokemonId { get; set; }

        public int categoryId { get; set; }

        public Pokemon pokemon { get; set; }

        public Category category { get; set; }

    }
}
