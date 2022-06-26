// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

using Xeptions;

namespace GottaGo.Core.Api.Models.ExternalMaps.Search.Exceptions
{
    public class MapDependencyException : Xeption
    {
        public MapDependencyException(Xeption innerException)
            : base(message: "Map dependency error occurred, please try again.",
                  innerException)
        { }
    }
}
