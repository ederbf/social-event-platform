using SocialEventPlatform.Application.Common.Interfaces.Persistence;
using SocialEventPlatform.Domain.ActivityAggregate;

namespace SocialEventPlatform.Infrastructure.Persistence
{
    public class ActivityRepository : IActivityRepository
    {
        private static readonly List<Activity> _activities = new();
        public void Add(Activity activity)
        {
            _activities.Add(activity);
        }
    }
}
