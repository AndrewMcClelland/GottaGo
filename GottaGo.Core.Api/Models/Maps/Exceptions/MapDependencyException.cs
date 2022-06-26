// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

using Xeptions;

namespace GottaGo.Core.Api.Models.Maps.Exceptions
{
    public class MapDependencyException : Xeption
    {
        public MapDependencyException(Xeption innerException)
            : base(message: "Map dependency error occurred, please contact support.",
                  innerException)
        { }
    }
}
