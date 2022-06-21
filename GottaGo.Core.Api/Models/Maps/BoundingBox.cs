// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

namespace GottaGo.Core.Api.Models.Maps
{
    public class BoundingBox
    {
        public Coordinates TopLeftPoint { get; set; }
        public Coordinates BottomRightPoint { get; set; }
    }
}