using ActivityPlatform.Application.Common.Interfaces.Authentication;

namespace ActivityPlatform.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }
        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            //Check if user exists

            // create user (generate unique id

            // create jwt token
            Guid userId = Guid.NewGuid();
            var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);
            
            return new AuthenticationResult(
                userId,
                firstName,
                lastName,
                email,
                token);
        }

        public AuthenticationResult Login(string firstName, string lastName, string email, string password)
        {
            return new AuthenticationResult(
                Guid.NewGuid(),
                firstName,
                lastName,
                email,
                "token");
        }
        
    }
}