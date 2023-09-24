﻿using SocialEventPlatform.Domain.Activity.ValueObjects;
using SocialEventPlatform.Domain.Common.Models;
using SocialEventPlatform.Domain.Common.ValueObjects;
using SocialEventPlatform.Domain.Host.ValueObjects;
using SocialEventPlatform.Domain.SocialEvent.Entities;
using SocialEventPlatform.Domain.SocialEvent.Enums;
using SocialEventPlatform.Domain.SocialEvent.ValueObjects;

namespace SocialEventPlatform.Domain.SocialEvent
{
    public sealed class SocialEvent : AggregateRoot<SocialEventId>
    {
        private readonly List<Reservation> _reservations = new();

        public string Name { get; }
        public string Description { get; }
        public DateTime StartDateTime { get; }
        public DateTime EndDateTime { get; }
        public SocialEventStatus Status { get; }
        public bool IsPublic { get; }
        public int MaxGuests { get; }
        public Price Price { get; }
        public HostId HostId { get; }
        public ActivityId ActivityId { get; }
        public string ImageUrl { get; }
        public Location Location { get; }

        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        private SocialEvent(
            SocialEventId socialEventId,
            string name,
            string description,
            DateTime startDateTime,
            DateTime endDateTime,
            SocialEventStatus status,
            bool isPublic,
            int maxGuests,
            Price price,
            HostId hostId,
            ActivityId activityId,
            string imageUrl,
            Location location,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(socialEventId)
        {
            Name = name;
            Description = description;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            Status = status;
            IsPublic = isPublic;
            MaxGuests = maxGuests;
            Price = price;
            HostId = hostId;
            ActivityId = activityId;
            ImageUrl = imageUrl;
            Location = location;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static SocialEvent Create(
            string name,
            string description,
            DateTime startDateTime,
            DateTime endDateTime,
            SocialEventStatus status,
            bool isPublic,
            int maxGuests,
            Price price,
            HostId hostId,
            ActivityId activityId,
            string imageUrl,
            Location location)
        {
            return new(
                SocialEventId.CreateUnique(),
                name,
                description,
                startDateTime,
                endDateTime,
                status,
                isPublic,
                maxGuests,
                price,
                hostId, 
                activityId,
                imageUrl,
                location,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }
    }
}
