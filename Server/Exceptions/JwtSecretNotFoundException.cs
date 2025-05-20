namespace Server.Exceptions;

public class JwtSecretNotFoundException : Exception
{
    public JwtSecretNotFoundException()
    {
    }

    public JwtSecretNotFoundException(string message) : base(message)
    {
    }

    public JwtSecretNotFoundException(string message, Exception inner)
        : base(message, inner)
    {        
    }
}
