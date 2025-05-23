namespace Server.Models;

public class User
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public char Sex { get; set; }
    public int Age { get; set; }
    public float HeightCM { get; set; }
    public float WeightKG { get; set; }
    public required byte[] Password { get; set; }
    public required byte[] PasswordSalt { get; set; }
}
