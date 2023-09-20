using ActivityPlatform.Domain;

namespace ActivityPlatform.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
