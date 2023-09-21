using ActivityPlatform.Domain;

namespace ActivityPlatform.Application.Services.Authentication.Common
{
    public record AuthenticationResult(
        User User,
        string Token
    );
}
