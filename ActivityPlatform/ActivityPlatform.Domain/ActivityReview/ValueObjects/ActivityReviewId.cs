using SocialEventPlatform.Domain.Common.Models;

namespace SocialEventPlatform.Domain.ActivityReview.ValueObjects
{
    public sealed class ActivityReviewId : ValueObject
    {
        public Guid Value { get; }

        private ActivityReviewId(Guid value)
        {
            Value = value;
        }

        public static ActivityReviewId CreateUnique()
        {
            return new ActivityReviewId(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
