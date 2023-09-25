using SocialEventPlatform.Domain.ActivityAggregate.ValueObjects;
using SocialEventPlatform.Domain.Common.Models;

namespace SocialEventPlatform.Domain.ActivityAggregate.Entities
{
    public sealed class ActivitySection : Entity<ActivitySectionId>
    {
        public readonly List<ActivityItem> _items = new();
        public string Name { get; }
        public string Description { get; }

        public IReadOnlyList<ActivityItem> Items => _items.AsReadOnly();

        private ActivitySection(ActivitySectionId activitySectionId, string name, string description, List<ActivityItem> activityItems) : base(activitySectionId)
        {
            Name = name;
            Description = description;
            _items = activityItems;
        }

        public static ActivitySection Create(string name, string description, List<ActivityItem> activityItems)
        {
            return new(ActivitySectionId.CreateUnique(), name, description, activityItems);
        }
    }
}
