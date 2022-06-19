// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

using System;

namespace GottaGo.Core.Api.Models.Bathrooms
{
    public class Bathroom
    {
        public Guid Id { get; set; }
        public BathroomAddress Address { get; set; }
        public BathroomHours Hours { get; set; }
        public BathroomCategory Category { get; set; }
        public BathroomVerificationStatus VerificationStatus { get; set; }
        public double Rating { get; set; }
        public BathroomAccessType AccessType { get; set; }
        public string EntryCode { get; set; }
        public string Details { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public DateTimeOffset LastUpdatedDateTime { get; set; }
    }
}
