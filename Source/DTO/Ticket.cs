using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Ticket
    {
        public string Id { get; set; }
        public string PassengerId { get; set; }

        public string FlightId { get; set; }
        public string Class { get; set; }
        public int Type { get; set; }

        public double Price { get; set; }
    }
}
