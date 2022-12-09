using System;
using System.ComponentModel.DataAnnotations;
//User:
namespace FinalProject.Models
{
public class Ingredient
{
        public int IngredientId {get; set;} 
        [Required]
        public string Name {get; set;} = string.Empty;
        public List<RecipeIngredient> RecipeIngredients {get; set;} = default!; //Nav
}
public class RecipeIngredient
{
        public int IngredientID {get; set;} // composite primary key and foeirn key 1
        public int RecipeID {get; set;} // composite primary key and foeirn key 2
        public Recipe Recipe {get; set;} = default!; //nav
        public Ingredient Ingredient {get; set;} = default!; //nav
}
}