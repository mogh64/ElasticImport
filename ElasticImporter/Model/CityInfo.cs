using System;
using System.Collections.Generic;
using System.Text;

namespace ElasticImporter.Model
{
    public class CityInfo
    {
        public string City { get; set; }
        public string Admin { get; set; }
        public string Country { get; set; }
        public string Iso2 { get; set; }
        public string Capital { get; set; }
        public int? Population { get; set; }        
        public float? Lat { get; set; }
        public float? Lng { get; set; }
    }
}
