using SocialEventPlatform.Domain.UserAggregate;

namespace SocialEventPlatform.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
