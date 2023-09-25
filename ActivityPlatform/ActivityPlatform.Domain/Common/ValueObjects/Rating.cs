using SocialEventPlatform.Domain.Common.Models;

namespace SocialEventPlatform.Domain.Common.ValueObjects
{
    public sealed class Rating : ValueObject
    {
        private Rating(float value)
        {
            Value = value;
        }

        public float Value { get; private set; }

        public static Rating CreateNew(float rating = 0)
        {
            return new Rating(rating);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
