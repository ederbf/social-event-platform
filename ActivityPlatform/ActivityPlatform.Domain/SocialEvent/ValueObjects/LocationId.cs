using SocialEventPlatform.Domain.Common.Models;

namespace SocialEventPlatform.Domain.SocialEvent.ValueObjects
{
    public sealed class LocationId : ValueObject
    {
        public Guid Value { get; }

        private LocationId(Guid value)
        {
            Value = value;
        }

        public static LocationId CreateUnique()
        {
            return new LocationId(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
