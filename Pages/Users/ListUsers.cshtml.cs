using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;

namespace FinalProject.Users;

public class UserModel : PageModel
{
    private readonly DatabaseDbContext _context;
    private readonly ILogger<UserModel> _logger;
    public List<User> Users {get; set;} = default!;
    public List<Recipe> Recipes {get; set;} = default!;

    
    public UserModel(DatabaseDbContext context, ILogger<UserModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    public void OnGet()
    {
        Users = _context.Users.ToList();
        Recipes = _context.Recipes.ToList();
    }
}