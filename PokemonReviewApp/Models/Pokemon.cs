namespace PokemonReviewApp.Models
{
    public class Pokemon
    {
        public int id { get; set; }

        public string name { get; set; }

        public DateTime birthDate { get; set; }

        public ICollection<Review> reviews { get; set; }        //one-to-many relationship

        public ICollection<PokemonOwner> pokemonOwners { get; set; }        //many-to-many relationship

        public ICollection<PokemonCategory> pokemonCategories { get; set; }         //many-to-many relationship

    }
}
