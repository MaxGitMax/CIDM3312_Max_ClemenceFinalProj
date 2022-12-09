using Microsoft.EntityFrameworkCore;

namespace FinalProject.Models
{
    public class DatabaseDbContext : DbContext
    {
        public DatabaseDbContext (DbContextOptions<DatabaseDbContext> options)
            : base(options)
            {

            }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecipeIngredient>().HasKey(r => new {r.IngredientID, r.RecipeID});
        }
            public DbSet<Recipe> Recipes {get; set;} = default!;
            public DbSet<User> Users {get; set;} = default!;
            public DbSet<Ingredient> Ingredients {get; set;} = default!;
            public DbSet<RecipeIngredient> RecipeIngredients {get; set;} = default!;
    }
}