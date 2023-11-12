using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APS8_CSHARP_API.Domain.Objects
{
    public class GeoEncondinsObjects
    {
        public class Coordenadas
        {
            public double Latitude { get; set; }
            public double Longitude { get; set; }
        }

        public class GeocodingResult
        {
            public List<Result> results { get; set; }
        }

        public class Result
        {
            public Geometry geometry { get; set; }
        }

        public class Geometry
        {
            public Location location { get; set; }
        }

        public class Location
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }
    }
}