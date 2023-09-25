using SocialEventPlatform.Domain.UserAggregate;

namespace SocialEventPlatform.Application.Authentication.Common
{
    public record AuthenticationResult(
        User User,
        string Token
    );
}
