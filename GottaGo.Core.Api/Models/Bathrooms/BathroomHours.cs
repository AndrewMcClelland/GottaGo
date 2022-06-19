// -----------------------------------
// Copyright (c) Andrew McClelland.
// -----------------------------------

using System;

namespace GottaGo.Core.Api.Models.Bathrooms
{
    public class BathroomHours
    {
        public DayOfWeek Day { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
    }
}