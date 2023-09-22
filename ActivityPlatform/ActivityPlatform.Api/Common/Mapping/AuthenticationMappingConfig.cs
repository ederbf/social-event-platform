using ActivityPlatform.Application.Authentication.Commands.Register;
using ActivityPlatform.Application.Authentication.Common;
using ActivityPlatform.Application.Authentication.Queries.Login;
using ActivityPlatform.Contracts.Authentication;
using Mapster;

namespace ActivityPlatform.Api.Common.Mapping
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
