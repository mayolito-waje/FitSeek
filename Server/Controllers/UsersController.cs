using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;

namespace Server.Controllers;

public class UsersController(DataContext context) : ControllerProvider
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
    {
        var users = await context.Users.ToListAsync();

        return users;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Users>> GetUser(int id)
    {
        var user = await context.Users.FindAsync(id);

        if (user is null)
            return NotFound();

        return user;
    }
}
