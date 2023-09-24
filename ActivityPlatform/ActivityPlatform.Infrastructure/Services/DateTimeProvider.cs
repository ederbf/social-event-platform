using SocialEventPlatform.Application.Common.Interfaces.Services;

namespace SocialEventPlatform.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
