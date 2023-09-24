using SocialEventPlatform.Application.Authentication.Commands.Register;
using SocialEventPlatform.Application.Authentication.Common;
using SocialEventPlatform.Application.Authentication.Queries.Login;
using SocialEventPlatform.Contracts.Authentication;
using Mapster;

namespace SocialEventPlatform.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config) 
        {
            config.NewConfig<RegisterRequest, RegisterCommand>();
            config.NewConfig<LoginRequest, LoginQuery>();

            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest, src => src.User);
        }
    }
}
