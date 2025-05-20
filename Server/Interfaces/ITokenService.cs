using Server.Models;

namespace Server.Interfaces;

public interface ITokenService
{
    string GenerateToken(User user);
}
