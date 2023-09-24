using SocialEventPlatform.Domain.Models;

namespace SocialEventPlatform.Domain.Activity.ValueObjects
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
