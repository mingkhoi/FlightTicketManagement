using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightTicketManagement.DTO
{
    public class AuthenticatedUser
    {
        public string Access_Token { get; set; }
        public string Username { get; set; }
    }
}
