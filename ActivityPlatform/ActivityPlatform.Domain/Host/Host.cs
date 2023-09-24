using SocialEventPlatform.Domain.Activity.ValueObjects;
using SocialEventPlatform.Domain.Common.Models;
using SocialEventPlatform.Domain.Common.ValueObjects;
using SocialEventPlatform.Domain.Host.ValueObjects;
using SocialEventPlatform.Domain.SocialEvent.ValueObjects;
using SocialEventPlatform.Domain.User.ValueObjects;

namespace SocialEventPlatform.Domain.Guest
{
    public sealed class Host : AggregateRoot<HostId>
    {
        private readonly List<SocialEventId> _socialEventIds = new();
        private readonly List<ActivityId> _activityIds = new();

        public IReadOnlyList<SocialEventId> SocialEventIds => _socialEventIds.AsReadOnly();
        public IReadOnlyList<ActivityId> ActivityIds => _activityIds.AsReadOnly();
        public string FirstName { get; }
        public string LastName { get; }
        public string ProfileImage { get; }
        public AverageRating AverageRating { get; }
        public UserId UserId { get; }

        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        private Host(
            HostId hostId,
            string firstName,
            string lastName,
            string profileImage,
            AverageRating averageRating,
            UserId userId,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(hostId)
        {
            FirstName = firstName;
            LastName = lastName;
            ProfileImage = profileImage;
            AverageRating = averageRating;
            UserId = userId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Host Create(
            string firstName,
            string lastName,
            string profileImage,
            AverageRating averageRating,
            UserId userId)
        {
            return new(
                HostId.CreateUnique(),
                firstName,
                lastName,
                profileImage,
                averageRating,
                userId,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }
    }
}
