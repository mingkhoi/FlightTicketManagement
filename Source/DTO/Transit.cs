using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Transit
    {
        public string FlightId { get; set; }
        public string AirportId { get; set; }
        public string AirportName { get; set; }
        public TimeSpan Duration { get; set; }
        public string Note { get; set; }
    }
}
