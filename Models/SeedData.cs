using Microsoft.EntityFrameworkCore;
//Seed Database:
namespace FinalProject.Models
{
public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using(var context = new DatabaseDbContext(serviceProvider.GetRequiredService<DbContextOptions<DatabaseDbContext>>()))
            {
                //look for Users
                if(context.Users.Any())
                {
                    return; //database is seeded.
                }
                
                List<User> users = new List<User> {
                    new User {Name = "Maddie23"},
                    new User {Name = "Samson99"},
                    new User {Name = "ChefWon"},
                    new User {Name = "Carl98"},
                    new User {Name = "FreedomCookin909"},

                };
                context.AddRange(users);
                context.SaveChanges();
                List<Recipe> recipes = new List<Recipe> {
                    new Recipe {UserId = 1, Name = "Peperoni Pizza", Description = "Flaten dough out drizzle sauce add peperoni and cheese bake on 575 degrees fahrenheit for 15-20 mins"},
                    new Recipe {UserId = 2, Name = "Mint Salmon", Description = "bring vegtable oil to a simmer and fry your salmon fillet, squeze half a lemon and dash a bit of crushed up mint."},
                    new Recipe {UserId = 3, Name = "Chef Omelette", Description = "Fry the bacon, mix cooked bacon in with eggs along with cheese, fry egg like a pancake add a dash of salt."},
                    new Recipe {UserId = 4, Name = "Carl's Chili", Description = "Mix all the ingredients in a pot and bring it to a boil!"},
                    new Recipe {UserId = 5, Name = "Sandwhich-extra", Description = "get two slices of bread slap on the cheese, ham, tomato, and lettuce"},
                    new Recipe {UserId = 1, Name = "Super Soup", Description = "Mix all the ingredients in a pot and bring it to a boil!"},
                };
                context.AddRange(recipes);
                context.SaveChanges();
                List<Ingredient> ingredients = new List<Ingredient> {
                    new Ingredient {Name = "Dough"},
                    new Ingredient {Name = "Tomato sauce"},
                    new Ingredient {Name = "pepperoni"},
                    new Ingredient {Name = "Motzerella cheese"},
                    new Ingredient {Name = "Vegtable oil"},
                    new Ingredient {Name = "Salmon fillet"},
                    new Ingredient {Name = "Lemon"},
                    new Ingredient {Name = "Mint"},
                    new Ingredient {Name = "Egg"},
                    new Ingredient {Name = "Bacon"},
                    new Ingredient {Name = "Chedder cheese"},
                    new Ingredient {Name = "Salt"},
                    new Ingredient {Name = "Beans"},
                    new Ingredient {Name = "Ground beef"},
                    new Ingredient {Name = "Jalapeno peppers"},
                    new Ingredient {Name = "Rotel(HOT)"},
                    new Ingredient {Name = "Bread"},
                    new Ingredient {Name = "Smoked gouda"},
                    new Ingredient {Name = "Lettuce"},
                    new Ingredient {Name = "Tomato"},
                    new Ingredient {Name = "Ham"},
                    new Ingredient {Name = "Chicken broth"},
                    new Ingredient {Name = "Noodles"},
                    new Ingredient {Name = "Chicken chunks"},
                    new Ingredient {Name = "Corn"},
                    new Ingredient {Name = "Rice"},
                    

                };
                context.AddRange(ingredients);
                context.SaveChanges();
                List<RecipeIngredient> assignedIngredients = new List<RecipeIngredient> {
                    new RecipeIngredient {RecipeID = 1, IngredientID = 1},
                    new RecipeIngredient {RecipeID = 1, IngredientID = 2},
                    new RecipeIngredient {RecipeID = 1, IngredientID = 3},
                    new RecipeIngredient {RecipeID = 1, IngredientID = 4},
                    new RecipeIngredient {RecipeID = 2, IngredientID = 5},
                    new RecipeIngredient {RecipeID = 2, IngredientID = 6},
                    new RecipeIngredient {RecipeID = 2, IngredientID = 7},
                    new RecipeIngredient {RecipeID = 2, IngredientID = 8},
                    new RecipeIngredient {RecipeID = 3, IngredientID = 9},
                    new RecipeIngredient {RecipeID = 3, IngredientID = 10},
                    new RecipeIngredient {RecipeID = 3, IngredientID = 11},
                    new RecipeIngredient {RecipeID = 3, IngredientID = 12},
                    new RecipeIngredient {RecipeID = 4, IngredientID = 13},
                    new RecipeIngredient {RecipeID = 4, IngredientID = 14},
                    new RecipeIngredient {RecipeID = 4, IngredientID = 15},
                    new RecipeIngredient {RecipeID = 4, IngredientID = 16},
                    new RecipeIngredient {RecipeID = 5, IngredientID = 17},
                    new RecipeIngredient {RecipeID = 5, IngredientID = 18},
                    new RecipeIngredient {RecipeID = 5, IngredientID = 19},
                    new RecipeIngredient {RecipeID = 5, IngredientID = 20},
                    new RecipeIngredient {RecipeID = 5, IngredientID = 21},
                    new RecipeIngredient {RecipeID = 6, IngredientID = 22},
                    new RecipeIngredient {RecipeID = 6, IngredientID = 23},
                    new RecipeIngredient {RecipeID = 6, IngredientID = 24},
                    new RecipeIngredient {RecipeID = 6, IngredientID = 25},
                    new RecipeIngredient {RecipeID = 6, IngredientID = 26}, 
                };
                context.AddRange(assignedIngredients);
                context.SaveChanges();
            }
    }
}
}
