using ActivityPlatform.Api.Common.Errors;
using ActivityPlatform.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace ActivityPlatform.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton<ProblemDetailsFactory, ActivityPlatformProblemDetailsFactory>();

            services.AddMappings();

            return services;
        }
    }
}
