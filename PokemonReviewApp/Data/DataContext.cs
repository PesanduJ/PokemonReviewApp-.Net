using Microsoft.EntityFrameworkCore;        //library for entity framework core
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Data
{
    public class DataContext : DbContext        //inherited DbContext from entity framework core
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Category> categories { get; set; }

        public DbSet<Country> countries { get; set; }

        public DbSet<Owner> owners { get; set; }

        public DbSet<Pokemon> pokemons { get; set; }

        public DbSet<PokemonOwner> pokemonOwners { get; set; }

        public DbSet<PokemonCategory> pokemonCategories { get; set; }   

        public DbSet<Review> reviews { get; set; }  

        public DbSet<Reviewer> reviewers { get; set; }


        //for many-to-many tables create onModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //for pokemonCategory
            modelBuilder.Entity<PokemonCategory>()
                .HasKey(pc => new { pc.pokemonId, pc.categoryId });

            modelBuilder.Entity<PokemonCategory>()
                .HasOne(p => p.pokemon)
                .WithMany(pc => pc.pokemonCategories)
                .HasForeignKey(c => c.pokemonId);

            modelBuilder.Entity<PokemonCategory>()
                .HasOne(p => p.category)
                .WithMany(pc=> pc.pokemonCategories)
                .HasForeignKey(c=> c.categoryId);


            //for pokemonOwner
            modelBuilder.Entity<PokemonOwner>()
                .HasKey(po => new { po.pokemonId, po.ownerId });

            modelBuilder.Entity<PokemonOwner>()
                .HasOne(p => p.pokemon)
                .WithMany(po => po.pokemonOwners)
                .HasForeignKey(c => c.pokemonId);

            modelBuilder.Entity<PokemonOwner>()
                .HasOne(p => p.owner)
                .WithMany(po => po.pokemonOwners)
                .HasForeignKey(o => o.ownerId);

        }


    }
}
