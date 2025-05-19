namespace Server.DTOs;

public class UserRegisterDto
{
    public required string Username { get; set; }
    public required int Age { get; set; }
    public required char Sex { get; set; }
    public required float HeightCM { get; set; }
    public required float WeightKG { get; set; }
    public required string Password { get; set; }
}
