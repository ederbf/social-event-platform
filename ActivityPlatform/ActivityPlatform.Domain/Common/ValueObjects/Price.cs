using SocialEventPlatform.Domain.Common.Models;

namespace SocialEventPlatform.Domain.Common.ValueObjects
{
    public sealed class Price : ValueObject
    {
        private Price(double amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public double Amount { get; private set; }
        public string Currency { get; private set; }

        public static Price CreateNew(double amount = 0, string currency = "EUR")
        {
            return new Price(amount, currency);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
            yield return Currency;
        }
    }
}
