using System;
using System.ComponentModel.DataAnnotations;
//User:
namespace FinalProject.Models
{
public class User
{
        public int UserId {get; set;} 
        [Required]
        public string Name {get; set;} = string.Empty; 
        public List<Recipe> Recipes {get; set;} = new List<Recipe>(); //Nav Prop
        

}
}