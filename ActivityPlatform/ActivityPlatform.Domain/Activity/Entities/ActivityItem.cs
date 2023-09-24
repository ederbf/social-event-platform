using SocialEventPlatform.Domain.Activity.ValueObjects;
using SocialEventPlatform.Domain.Models;

namespace SocialEventPlatform.Domain.Activity.Entities
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
