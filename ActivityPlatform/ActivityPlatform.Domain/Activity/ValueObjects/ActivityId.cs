using SocialEventPlatform.Domain.Models;

namespace SocialEventPlatform.Domain.Activity.ValueObjects
{
    public sealed class ActivityId : ValueObject
    {
        public Guid Value { get; }

        private ActivityId(Guid value)
        {
            Value = value;
        }

        public static ActivityId CreateUnique()
        {
            return new ActivityId(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
