using SocialEventPlatform.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace SocialEventPlatform.Application.Authentication.Queries.Login
{
    public record LoginQuery(
        string Email,
        string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
