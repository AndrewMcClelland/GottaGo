// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

namespace GottaGo.Core.Api.Models.Maps
{
    public class Address
    {
        public string Type { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string MunicipalitySubdivision { get; set; }
        public string Municipality { get; set; }
        public string CountrySubdivisionName { get; set; }
        public string CountrySubdivision { get; set; }
        public string CountrySecondarySubdivision { get; set; }
        public string CountryTertiarySubdivision { get; set; }
        public string PostalCode { get; set; }
        public string ExtendedPostalCode { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string CountryCodeISO3 { get; set; }
        public string FreeformAddress { get; set; }
        public Coordinates Coordinates { get; set; }
        public BoundingBox BoundingBox { get; set; }
    }
}
