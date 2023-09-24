using SocialEventPlatform.Domain.User;

namespace SocialEventPlatform.Application.Authentication.Common
{
    public record AuthenticationResult(
        User User,
        string Token
    );
}
