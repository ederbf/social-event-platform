using SocialEventPlatform.Api.Common.Errors;
using SocialEventPlatform.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace SocialEventPlatform.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton<ProblemDetailsFactory, SocialEventPlatformProblemDetailsFactory>();

            services.AddMappings();

            return services;
        }
    }
}
