using ActivityPlatform.Application.Authentication.Common;
using ActivityPlatform.Application.Authentication.Queries.Login;
using ActivityPlatform.Application.Common.Interfaces.Authentication;
using ActivityPlatform.Application.Common.Interfaces.Persistence;
using ActivityPlatform.Domain;
using ActivityPlatform.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace ActivityPlatform.Application.Authentication.Commands.Register
{
    public class LoginQueryHandler :
        IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask; //Without this line we get a warning because we aren't doing anything async. Will get rid of it when we do have async logic.

            //1. Validate the user exists
            if (_userRepository.GetUserByEmail(query.Email) is not User user)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            //2. Validate the password is correct
            if (user.Password != query.Password)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            //3. Create jwt token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}
