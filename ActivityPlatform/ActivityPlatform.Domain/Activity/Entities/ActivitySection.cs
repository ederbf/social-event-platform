using SocialEventPlatform.Domain.Activity.ValueObjects;
using SocialEventPlatform.Domain.Models;

namespace SocialEventPlatform.Domain.Activity.Entities
{
    public sealed class ActivitySection : Entity<ActivitySectionId>
    {
        public readonly List<ActivityItem> _items = new();
        public string Name { get; }
        public string Description { get; }

        public IReadOnlyList<ActivityItem> Items => _items.AsReadOnly();

        private ActivitySection(ActivitySectionId activitySectionId, string name, string description) : base(activitySectionId)
        {
            Name = name;
            Description = description;
        }

        public static ActivitySection Create(string name, string description)
        {
            return new (ActivitySectionId.CreateUnique(), name, description);
        }
    }
}
