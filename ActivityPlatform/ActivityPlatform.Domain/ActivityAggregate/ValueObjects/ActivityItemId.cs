using SocialEventPlatform.Domain.Common.Models;

namespace SocialEventPlatform.Domain.ActivityAggregate.ValueObjects
{
    public sealed class ActivityItemId : ValueObject
    {
        public Guid Value { get; }

        private ActivityItemId(Guid value)
        {
            Value = value;
        }

        public static ActivityItemId CreateUnique()
        {
            return new ActivityItemId(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
