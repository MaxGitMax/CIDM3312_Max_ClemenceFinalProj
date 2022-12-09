using System;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
public class Recipe
{
        public int RecipeId {get; set;}
        [Required]
        public string Name {get; set;} = string.Empty; 
        [Required]
        public string Description {get; set;} = string.Empty;
        public List<RecipeIngredient> RecipeIngredients {get; set;} = default!;
        [Required]
        public int UserId {get; set;} //foreign key
        public User User {get; set;}  = default!; //Nav prop 
}
}