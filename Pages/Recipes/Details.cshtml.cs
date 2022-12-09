using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject.Pages.Recipes
{
    public class DetailsModel : PageModel
    {
        private readonly ILogger<DetailsModel> _logger;
        private readonly FinalProject.Models.DatabaseDbContext _context;

        public DetailsModel(FinalProject.Models.DatabaseDbContext context, ILogger<DetailsModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Recipe Recipe { get; set; }
        [BindProperty]
        public int IngredientToDelete {get; set;}

        [BindProperty]
        public int IngredientToAdd {get; set;}

        public List<Ingredient> AllIngredients {get; set;} = default!;
        public List<Ingredient> CurrentIngredients {get; set;} = default!;
        public SelectList IngredientDropDown {get; set;} = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Recipe = await _context.Recipes
                .Include(r => r.User).Include(r => r.RecipeIngredients).ThenInclude(r => r.Ingredient).FirstOrDefaultAsync(m => m.RecipeId == id);
            
            
            
            //CurrentIngredients = await _context.Ingredients.Include(ci => ci.RecipeIngredients).ThenInclude(ci => ci.RecipeID == id).ToListAsync();
            
            
            
            var recipe = await _context.Recipes.Include(i => i.RecipeIngredients).ThenInclude(ri => ri.Ingredient).FirstOrDefaultAsync(m => m.RecipeId == id);
            AllIngredients = await _context.Ingredients.ToListAsync();
            IngredientDropDown = new SelectList(AllIngredients, "IngredientId", "Name");
            if (recipe == null)
            {
                return NotFound();
            }
            else
            {
                Recipe = recipe;
            }

            return Page();
        }
        public async Task<IActionResult> OnPostDeleteIngredientAsync(int? id)
        {
            _logger.LogWarning($"OnPost: RecipeId {id}, Remove Ingredient {IngredientToDelete}");
            if(id == null)
            {
                return NotFound();
            }
            var recipe = await _context.Recipes.Include(i => i.RecipeIngredients).ThenInclude(ri => ri.Ingredient).FirstOrDefaultAsync(m => m.RecipeId == id);
            if(recipe == null)
            {
                return NotFound();
            }
            else
            {
                Recipe = recipe;
            }

            RecipeIngredient ingredientToDelete = _context.RecipeIngredients.Find(IngredientToDelete, id.Value)!;
            if(ingredientToDelete != null)
            {
                _context.Remove(ingredientToDelete);
                _context.SaveChanges();
            }
            else
            {
                _logger.LogWarning("Recipe DOES NOT Have ingredients");
            }
            return RedirectToPage(new {id = id});
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
        _logger.LogWarning($"OnPost: RecipeId {id}, ADD Ingredient {IngredientToAdd}");
        if(IngredientToAdd == 0)
        {
            ModelState.AddModelError("IngredientToAdd", "This field is a required field.");
            return Page();
        }
        if(id == null)
        {
            return NotFound();
        }

            var recipe = await _context.Recipes.Include(i => i.RecipeIngredients).ThenInclude(ri => ri.Ingredient).FirstOrDefaultAsync(m => m.RecipeId == id);
            AllIngredients = await _context.Ingredients.ToListAsync();
            IngredientDropDown = new SelectList(AllIngredients, "IngredientId", "Name");
            if (recipe == null)
            {
                return NotFound();
            }
            else
            {
                Recipe = recipe;
            }

        if(!_context.RecipeIngredients.Any(ri => ri.IngredientID == IngredientToAdd && ri.RecipeID == id.Value))
        {
            RecipeIngredient ingredientToAdd = new RecipeIngredient {RecipeID = id.Value, IngredientID = IngredientToAdd};
            _context.Add(ingredientToAdd);
            _context.SaveChanges();
        }
        else
        {
            _logger.LogWarning("Recipe already has this ingredient");
        }
        return RedirectToPage(new {id = id});
        }

    }
}
