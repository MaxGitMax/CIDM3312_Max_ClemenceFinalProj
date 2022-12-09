using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;

namespace FinalProject.Pages.Recipes
{
    public class IndexModel : PageModel
    {
        private readonly FinalProject.Models.DatabaseDbContext _context;

        public IndexModel(FinalProject.Models.DatabaseDbContext context)
        {
            _context = context;
        }

        public IList<Recipe> Recipe { get;set; }

        public async Task OnGetAsync()
        {
            Recipe = await _context.Recipes
                .Include(r => r.User).ToListAsync();
        }
    }
}
