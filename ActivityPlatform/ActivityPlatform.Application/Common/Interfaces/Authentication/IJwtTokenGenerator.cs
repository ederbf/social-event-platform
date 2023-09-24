using SocialEventPlatform.Domain.User;

namespace SocialEventPlatform.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
