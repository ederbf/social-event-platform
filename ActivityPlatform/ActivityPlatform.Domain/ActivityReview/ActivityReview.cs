using SocialEventPlatform.Domain.Activity.ValueObjects;
using SocialEventPlatform.Domain.ActivityReview.ValueObjects;
using SocialEventPlatform.Domain.Common.Models;
using SocialEventPlatform.Domain.Common.ValueObjects;
using SocialEventPlatform.Domain.Host.ValueObjects;
using SocialEventPlatform.Domain.SocialEvent.ValueObjects;

namespace SocialEventPlatform.Domain.ActivityReview
{
    public sealed class ActivityReview : AggregateRoot<ActivityReviewId>
    {
        public Rating Rating { get; }
        public string Comment { get; }
        public HostId HostId { get; }
        public ActivityId ActivityId { get; }
        public GuestId GuestId { get; }
        public SocialEventId SocialEventId { get; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        private ActivityReview(
            ActivityReviewId activityReviewId,
            Rating rating,
            string comment,
            HostId hostId,
            ActivityId activityId,
            GuestId guestId,
            SocialEventId socialEventId,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(activityReviewId)
        {
            Rating = rating;
            Comment = comment;
            HostId = hostId;
            ActivityId = activityId;
            GuestId = guestId;
            SocialEventId = socialEventId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static ActivityReview Create(
            Rating rating,
            string comment,
            HostId hostId,
            ActivityId activityId,
            GuestId guestId,
            SocialEventId socialEventId)
        {
            return new(
                ActivityReviewId.CreateUnique(),
                rating,
                comment,
                hostId,
                activityId,
                guestId,
                socialEventId,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }
    }
}
