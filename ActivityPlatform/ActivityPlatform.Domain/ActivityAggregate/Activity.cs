using SocialEventPlatform.Domain.ActivityAggregate.Entities;
using SocialEventPlatform.Domain.ActivityAggregate.ValueObjects;
using SocialEventPlatform.Domain.ActivityReviewAggregate.ValueObjects;
using SocialEventPlatform.Domain.Common.Models;
using SocialEventPlatform.Domain.Common.ValueObjects;
using SocialEventPlatform.Domain.GuestAggregate.ValueObjects;
using SocialEventPlatform.Domain.SocialEventAggregate.ValueObjects;

namespace SocialEventPlatform.Domain.ActivityAggregate
{
    public sealed class Activity : AggregateRoot<ActivityId>
    {
        private readonly List<ActivitySection> _sections = new();
        private readonly List<SocialEventId> _socialEventIds = new();
        private readonly List<ActivityReviewId> _activityReviewIds = new();

        public string Name { get; }
        public string Description { get; }
        public AverageRating AverageRating { get; }

        public IReadOnlyList<ActivitySection> Sections => _sections.AsReadOnly();

        public GuestId HostId { get; }
        public IReadOnlyList<SocialEventId> SocialEventIds => _socialEventIds.AsReadOnly();
        public IReadOnlyList<ActivityReviewId> ActivityReviewIds => _activityReviewIds.AsReadOnly();

        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        private Activity(
            ActivityId activityId,
            string name,
            string description,
            GuestId hostId,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(activityId)
        {
            Name = name;
            Description = description;
            HostId = hostId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Activity Create(
            string name,
            string description,
            GuestId hostId)
        {
            return new(
                ActivityId.CreateUnique(),
                name,
                description,
                hostId,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }
    }
}
