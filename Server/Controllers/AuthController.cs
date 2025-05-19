using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.DTOs;
using Server.Models;
using Server.Utils;

namespace Server.Controllers;

public class AuthController(DataContext context) : ControllerProvider
{
    [HttpPost("register")]
    public async Task<ActionResult<Users>> Register(UserRegisterDto userRegisterDto)
    {
        if (await UserExists(userRegisterDto.Username)) return BadRequest("Username is taken.");

        if (!userRegisterDto.Sex.ToString().Equals("m", StringComparison.CurrentCultureIgnoreCase)
            && !userRegisterDto.Sex.ToString().Equals("f", StringComparison.CurrentCultureIgnoreCase))
            return BadRequest("Sex should be m or f");

        byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
        byte[] passwordHash = PasswordHasher.Hash(userRegisterDto.Password, salt);

        var registeredUser = new Users
        {
            Username = userRegisterDto.Username,
            Age = userRegisterDto.Age,
            Sex = userRegisterDto.Sex,
            HeightCM = userRegisterDto.HeightCM,
            WeightKG = userRegisterDto.WeightKG,
            Password = passwordHash,
            PasswordSalt = salt
        };

        context.Users.Add(registeredUser);
        await context.SaveChangesAsync();

        return registeredUser;
    }

    [HttpPost("login")]
    public async Task<ActionResult<Users>> Login(LoginDto loginDto)
    {
        var user = await context.Users.FirstOrDefaultAsync(x => x.Username == loginDto.Username);

        if (user == null) return Unauthorized("Invalid username.");

        byte[] salt = user.PasswordSalt;
        byte[] passwordHash = PasswordHasher.Hash(loginDto.Password, salt);

        for (int i = 0; i < passwordHash.Length; i++)
        {
            if (passwordHash[i] != user.Password[i])
                return Unauthorized("Password doesn't match.");
        }

        return user;
    }

    private async Task<bool> UserExists(string username)
    {
        var userExists = await context.Users.AnyAsync(x => x.Username == username);
        return userExists;
    }
}
