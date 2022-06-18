// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

using System;

namespace GottaGo.Core.Api.Models.Bathrooms
{
    public class BathroomAddress
    {
        public Guid Id { get; set; }
        public string StreetAddress { get; set; }
        public string ExtendedAddress { get; set; }
        public string Locality { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string PostalCode { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}