// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

using System.Collections.Generic;

namespace GottaGo.Core.Api.Models.Maps
{
    public class AddressSearch
    {
        public string Query { get; set; }
        public Coordinates CurrentLocation { get; set; }
        public string Language { get; set; }
        public List<string> Countries { get; set; }
    }
}
