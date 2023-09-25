using SocialEventPlatform.Domain.BillAggregate.ValueObjects;
using SocialEventPlatform.Domain.Common.Models;
using SocialEventPlatform.Domain.Common.ValueObjects;
using SocialEventPlatform.Domain.GuestAggregate.ValueObjects;
using SocialEventPlatform.Domain.HostAggregate.ValueObjects;
using SocialEventPlatform.Domain.SocialEventAggregate.ValueObjects;

namespace SocialEventPlatform.Domain.BillAggregate
{
    public sealed class Bill : AggregateRoot<BillId>
    {
        public SocialEventId SocialEventId { get; }
        public GuestId GuestId { get; }
        public HostId HostId { get; }
        public Price Price { get; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        private Bill(
            BillId billId,
            SocialEventId socialEventId,
            GuestId guestId,
            HostId hostId,
            Price price,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(billId)
        {
            SocialEventId = socialEventId;
            GuestId = guestId;
            HostId = hostId;
            Price = price;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Bill Create(
            SocialEventId socialEventId,
            GuestId guestId,
            HostId hostId,
            Price price)
        {
            return new(
                BillId.CreateUnique(),
                socialEventId,
                guestId,
                hostId,
                price,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }
    }
}
