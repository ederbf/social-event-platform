﻿using SocialEventPlatform.Domain.Common.Models;
using SocialEventPlatform.Domain.SocialEventAggregate.ValueObjects;

namespace SocialEventPlatform.Domain.SocialEventAggregate.Entities
{
    public sealed class Location : Entity<LocationId>
    {
        public string Name { get; }
        public string Address { get; }
        public double Latitude { get; }
        public double Longitude { get; }

        private Location(LocationId locationId, string name, string address, double latitude, double longitude) : base(locationId)
        {
            Name = name;
            Address = address;
            Latitude = latitude;
            Longitude = longitude;
        }

        public static Location Create(string name, string address, double latitude, double longitude)
        {
            return new(LocationId.CreateUnique(), name, address, latitude, longitude);
        }
    }
}
