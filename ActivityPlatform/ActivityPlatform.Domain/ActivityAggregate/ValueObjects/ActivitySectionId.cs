using SocialEventPlatform.Domain.Common.Models;

namespace SocialEventPlatform.Domain.ActivityAggregate.ValueObjects
{
    public sealed class ActivitySectionId : ValueObject
    {
        public Guid Value { get; }

        private ActivitySectionId(Guid value)
        {
            Value = value;
        }

        public static ActivitySectionId CreateUnique()
        {
            return new ActivitySectionId(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
