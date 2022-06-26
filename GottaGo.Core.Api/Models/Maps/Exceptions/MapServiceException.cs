// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

using Xeptions;

namespace GottaGo.Core.Api.Models.Maps.Exceptions
{
    public class MapServiceException : Xeption
    {
        public MapServiceException(Xeption innerException)
            : base(message: "Map service error occurred, please contact support.",
                  innerException)
        { }
    }
}
