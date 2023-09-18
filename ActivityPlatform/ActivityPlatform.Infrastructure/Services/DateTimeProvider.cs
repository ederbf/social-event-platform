using ActivityPlatform.Application.Common.Interfaces.Services;

namespace ActivityPlatform.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
