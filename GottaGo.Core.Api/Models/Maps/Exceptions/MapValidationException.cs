// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

using Xeptions;

namespace GottaGo.Core.Api.Models.Maps.Exceptions
{
    public class MapValidationException : Xeption
    {
        public MapValidationException(Xeption innerException) :
            base(message: "Map validation error occurred, please contact support.",
                innerException)
        { }
    }
}
