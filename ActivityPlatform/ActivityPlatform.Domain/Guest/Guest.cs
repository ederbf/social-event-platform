using SocialEventPlatform.Domain.Activity.Entities;
using SocialEventPlatform.Domain.ActivityReview.ValueObjects;
using SocialEventPlatform.Domain.Bill.ValueObjects;
using SocialEventPlatform.Domain.Common.Models;
using SocialEventPlatform.Domain.Common.ValueObjects;
using SocialEventPlatform.Domain.Host.ValueObjects;
using SocialEventPlatform.Domain.SocialEvent.ValueObjects;
using SocialEventPlatform.Domain.User.ValueObjects;
using static System.Collections.Specialized.BitVector32;

namespace SocialEventPlatform.Domain.Guest
{
    public sealed class Guest : AggregateRoot<GuestId>
    {
        private readonly List<Rating> _ratings = new();
        private readonly List<SocialEventId> _upcomingSocialEventIds = new();
        private readonly List<SocialEventId> _pastSocialEventIds = new();
        private readonly List<SocialEventId> _pendingSocialEventIds = new();
        private readonly List<BillId> _upcomingBillIds = new();
        private readonly List<ActivityReviewId> _activityReviewIds = new();

        public IReadOnlyList<Rating> Ratings => _ratings.AsReadOnly();
        public IReadOnlyList<SocialEventId> UpcomingSocialEventIds => _upcomingSocialEventIds.AsReadOnly();
        public IReadOnlyList<SocialEventId> PastSocialEvenIdts => _pastSocialEventIds.AsReadOnly();
        public IReadOnlyList<SocialEventId> PendingSocialEventIds => _pendingSocialEventIds.AsReadOnly();
        public IReadOnlyList<BillId> UpcomingBillIds => _upcomingBillIds.AsReadOnly();
        public IReadOnlyList<ActivityReviewId> ActivityReviewIds => _activityReviewIds.AsReadOnly();
        public string FirstName { get; }
        public string LastName { get; }
        public string ProfileImage { get; }
        public AverageRating AverageRating { get; }
        public UserId UserId { get; }

        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        private Guest(
            GuestId guestId,
            string firstName,
            string lastName,
            string profileImage,
            AverageRating averageRating,
            UserId userId,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(guestId)
        {
            FirstName = firstName;
            LastName = lastName;
            ProfileImage = profileImage;
            AverageRating = averageRating;
            UserId = userId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Guest Create(
            string firstName,
            string lastName,
            string profileImage,
            AverageRating averageRating,
            UserId userId)
        {
            return new(
                GuestId.CreateUnique(),
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
