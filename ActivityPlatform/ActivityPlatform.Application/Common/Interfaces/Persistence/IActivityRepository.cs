using SocialEventPlatform.Domain.ActivityAggregate;

namespace SocialEventPlatform.Application.Common.Interfaces.Persistence
{
    public interface IActivityRepository
    {
        void Add(Activity activity );
    }
}
