using ActivityPlatform.Application.Common.Interfaces.Authentication;
using ActivityPlatform.Application.Common.Interfaces.Persistence;
using ActivityPlatform.Application.Services.Authentication.Common;
using ActivityPlatform.Domain;
using ActivityPlatform.Domain.Common.Errors;
using ErrorOr;

namespace ActivityPlatform.Application.Services.Authentication.Commands
{
    public class AuthenticationCommandService : IAuthenticationCommandService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationCommandService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }
        public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
        {
            //1 .Check if user exists
            if (_userRepository.GetUserByEmail(email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }

            //2. Create user (generate unique id and persist to DB
            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };

            _userRepository.Add(user);

            //3. Create jwt token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}