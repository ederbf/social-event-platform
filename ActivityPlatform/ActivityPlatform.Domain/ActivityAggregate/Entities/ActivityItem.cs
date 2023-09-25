using SocialEventPlatform.Domain.ActivityAggregate.ValueObjects;
using SocialEventPlatform.Domain.Common.Models;

namespace SocialEventPlatform.Domain.ActivityAggregate.Entities
{
    public sealed class ActivityItem : Entity<ActivityItemId>
    {
        public string Name { get; }
        public string Description { get; }

        private ActivityItem(ActivityItemId id, string name, string description) : base(id)
        {
            Name = name;
            Description = description;
        }

        public static ActivityItem Create(string name, string description)
        {
            return new ActivityItem(ActivityItemId.CreateUnique(), name, description);
        }
    }
}
