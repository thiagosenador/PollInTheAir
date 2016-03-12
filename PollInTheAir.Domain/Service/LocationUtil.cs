using System.Data.Entity.Spatial;
using PollInTheAir.Domain.Models;

namespace PollInTheAir.Domain.Service
{
    public static class LocationUtil
    {
        public static DbGeography ParseLocation(Location location)
        {
            return DbGeography.PointFromText(string.Format("POINT({0} {1})", location.Longitude, location.Latitude), 4326);
        }
    }
}
