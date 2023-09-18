using ActivityPlatform.Application.Common.Interfaces.Authentication;
using ActivityPlatform.Application.Common.Interfaces.Services;
using ActivityPlatform.Infrastructure.Authentication;
using ActivityPlatform.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ActivityPlatform.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            return services;
        }
    }
}
