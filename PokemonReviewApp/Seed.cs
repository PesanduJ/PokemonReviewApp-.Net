using PokemonReviewApp.Data;
using PokemonReviewApp.Models;

namespace PokemonReviewApp
{
    public class Seed
    {

        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.pokemonOwners.Any())
            {
                var pokemonOwners = new List<PokemonOwner>()
                {
                    new PokemonOwner()
                    {
                        pokemon = new Pokemon()
                        {
                            name = "Pikachu",
                            birthDate = new DateTime(1903,1,1),
                            pokemonCategories = new List<PokemonCategory>()
                            {
                                new PokemonCategory { category = new Category() { name = "Electric"}}
                            },
                            reviews = new List<Review>()
                            {
                                new Review { title="Pikachu",text = "Pickahu is the best pokemon, because it is electric",
                                reviewer = new Reviewer(){ firstName = "Teddy", lastName = "Smith" } },
                                new Review { title="Pikachu", text = "Pickachu is the best a killing rocks",
                                reviewer = new Reviewer(){ firstName = "Taylor", lastName = "Jones" } },
                                new Review { title="Pikachu",text = "Pickchu, pickachu, pikachu",
                                reviewer = new Reviewer(){ firstName = "Jessica", lastName = "McGregor" } },
                            }
                        },
                        owner = new Owner()
                        {
                            name = "Jack London",
                            gym = "Brocks Gym",
                            country = new Country()
                            {
                                name = "Kanto"
                            }
                        }
                    },
                    new PokemonOwner()
                    {
                        pokemon = new Pokemon()
                        {
                            name = "Squirtle",
                            birthDate = new DateTime(1903,1,1),
                            pokemonCategories = new List<PokemonCategory>()
                            {
                                new PokemonCategory { category = new Category() { name = "Water"}}
                            },
                            reviews = new List<Review>()
                            {
                                new Review { title= "Squirtle", text = "squirtle is the best pokemon, because it is electric",
                                reviewer = new Reviewer(){ firstName = "Teddy", lastName = "Smith" } },
                                new Review { title= "Squirtle",text = "Squirtle is the best a killing rocks",
                                reviewer = new Reviewer(){ firstName = "Taylor", lastName = "Jones" } },
                                new Review { title= "Squirtle", text = "squirtle, squirtle, squirtle",
                                reviewer = new Reviewer(){ firstName = "Jessica", lastName = "McGregor" } },
                            }
                        },
                        owner = new Owner()
                        {
                            name = "Harry Potter",
                            gym = "Mistys Gym",
                            country = new Country()
                            {
                                name = "Saffron City"
                            }
                        }
                    },
                    new PokemonOwner()
                    {
                        pokemon = new Pokemon()
                        {
                            name = "Venasuar",
                            birthDate = new DateTime(1903,1,1),
                            pokemonCategories = new List<PokemonCategory>()
                            {
                                new PokemonCategory { category = new Category() { name = "Leaf"}}
                            },
                            reviews = new List<Review>()
                            {
                                new Review { title="Veasaur",text = "Venasuar is the best pokemon, because it is electric",
                                reviewer = new Reviewer(){ firstName = "Teddy", lastName = "Smith" } },
                                new Review { title="Veasaur",text = "Venasuar is the best a killing rocks",
                                reviewer = new Reviewer(){ firstName = "Taylor", lastName = "Jones" } },
                                new Review { title="Veasaur",text = "Venasuar, Venasuar, Venasuar",
                                reviewer = new Reviewer(){ firstName = "Jessica", lastName = "McGregor" } },
                            }
                        },
                        owner = new Owner()
                        {
                            name = "Ash Ketchum",
                            gym = "Ashs Gym",
                            country = new Country()
                            {
                                name = "Millet Town"
                            }
                        }
                    }
                };
                dataContext.pokemonOwners.AddRange(pokemonOwners);
                dataContext.SaveChanges();
            }
        }

    }
}
