using ActivityPlatform.Application.Services.Authentication.Common;
using ErrorOr;

namespace ActivityPlatform.Application.Services.Authentication.Queries
{
    public interface IAuthenticationQueryService
    {
        ErrorOr<AuthenticationResult> Login(string email, string password);
    }
}