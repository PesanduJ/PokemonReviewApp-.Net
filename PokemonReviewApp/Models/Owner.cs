namespace PokemonReviewApp.Models
{
    public class Owner
    {

        public int id { get; set; }

        public string name { get; set; }

        public string gym { get; set; }

        public Country country { get; set; }        //one-to-one relationship

    }
}
