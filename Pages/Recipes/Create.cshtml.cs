using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FinalProject.Models;

namespace FinalProject.Pages.Recipes
{
    public class CreateModel : PageModel
    {
        private readonly FinalProject.Models.DatabaseDbContext _context;

        public CreateModel(FinalProject.Models.DatabaseDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Name");
            return Page();
        }

        [BindProperty]
        public Recipe Recipe { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Recipes.Add(Recipe);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
