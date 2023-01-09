namespace PokemonReviewApp.Models
{
    public class Category
    {

        public int id { get; set; }

        public string name { get; set; }

        public ICollection<PokemonCategory> pokemonCategories { get; set; }         //many-to-many relationship

    }
}
