using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Class
    {
        public string Id { get; set; }
        public double Price { get; set; }
        public string OriginAP { get; set; }
        public string DestAP { get; set; }
        public DateTime DateTime { get; set; }
        public TimeSpan Time { get; set; }
        public int SeatsLeft { get; set; }

        public int TransitTime { get; set; }
    }
}
