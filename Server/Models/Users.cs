namespace Server.Models;

public class Users
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public char Sex { get; set; }
    public int Age { get; set; }
    public float HeightCM { get; set; }
    public float WeightKG { get; set; }
}
