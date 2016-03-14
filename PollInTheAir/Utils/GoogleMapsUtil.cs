using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PollInTheAir.Web.Utils
{
    public static class GoogleMapsUtil
    {
        public static void CreatePolyline(double latitude, double longitude, long radius)
        {
            var r = 6371;

            var pi = Math.PI;

            latitude = (latitude * pi) / 180;
            longitude = (longitude * pi) / 180;

            var d = radius / r;

            var points = new List<double>();

            for (int i = 0; i <= 360; i += 8)
            {
                var brng = i * pi / 180;
                var pLat = Math.Asin((Math.Sin(latitude) * Math.Cos(d)) + (Math.Cos(latitude) * Math.Sin(d) * Math.Cos(brng)));
                var pLng = ((longitude + Math.Atan2(Math.Sin(brng) * Math.Sin(d) * Math.Cos(latitude), Math.Cos(d) - (Math.Sin(latitude) * Math.Sin(pLat)))) * 180) / pi;
                pLat = (pLat * 180) / pi;
            }
        }
    }
}