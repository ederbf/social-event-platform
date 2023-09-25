using SocialEventPlatform.Application.Authentication.Common;
using SocialEventPlatform.Application.Common.Interfaces.Authentication;
using SocialEventPlatform.Application.Common.Interfaces.Persistence;
using SocialEventPlatform.Domain;
using SocialEventPlatform.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using SocialEventPlatform.Domain.UserAggregate;

namespace SocialEventPlatform.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : 
        IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask; //Without this line we get a warning because we aren't doing anything async. Will get rid of it when we do have async logic.

            //1 .Check if user exists
            if (_userRepository.GetUserByEmail(command.Email) is not null)
                return Errors.User.DuplicateEmail;

            //2. Create user (generate unique id and persist to DB
            var user = User.Create(
                command.FirstName,
                command.LastName,
                command.Email,
                command.Password
            );

            _userRepository.Add(user);

            //3. Create jwt token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}
