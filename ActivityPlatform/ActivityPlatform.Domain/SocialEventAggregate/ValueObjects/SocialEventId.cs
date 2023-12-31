﻿using SocialEventPlatform.Domain.Common.Models;

namespace SocialEventPlatform.Domain.SocialEventAggregate.ValueObjects
{
    public sealed class SocialEventId : ValueObject
    {
        public Guid Value { get; }

        private SocialEventId(Guid value)
        {
            Value = value;
        }

        public static SocialEventId CreateUnique()
        {
            return new SocialEventId(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
