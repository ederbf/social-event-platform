using SocialEventPlatform.Domain.Activity.ValueObjects;
using SocialEventPlatform.Domain.Bill.ValueObjects;
using SocialEventPlatform.Domain.Common.Models;
using SocialEventPlatform.Domain.Host.ValueObjects;
using SocialEventPlatform.Domain.SocialEvent.Enums;
using SocialEventPlatform.Domain.SocialEvent.ValueObjects;

namespace SocialEventPlatform.Domain.SocialEvent.Entities
{
    public sealed class Reservation : Entity<ReservationId>
    {
        public int GuestCount { get; }
        public ReservationStatus ReservationStatus { get; }
        public GuestId GuestId { get; }
        public BillId BillId { get; }
        public DateTime? ArrivalDateTime { get; 
        }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        private Reservation(
            ReservationId id,
            int guestCount,
            ReservationStatus reservationStatus,
            GuestId guestId,
            BillId billId,
            DateTime? arrivalDateTime,
            DateTime createdDateTime,
            DateTime updatedDateTime
            ) : base(id)
        {
            GuestCount = guestCount;
            ReservationStatus = reservationStatus;
            GuestId = guestId;
            BillId = billId;
            ArrivalDateTime = arrivalDateTime;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Reservation Create(
            int guestCount,
            ReservationStatus reservationStatus,
            GuestId guestId,
            BillId billId)
        {
            return new(
                ReservationId.CreateUnique(),
                guestCount,
                reservationStatus,
                guestId,
                billId,
                null,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }
    }
}
