using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace FlightTicketManagement.Helper
{
    class Authenticater
    {

        private static Authenticater instance = null;
        public static Authenticater Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Authenticater();
                }
                return instance;
            }
        }
        AuthenticatedUser user { get; set; }

        public async Task<bool> Authenticate(string userName, string passWord)
        {
            User userLogin = new User { username = userName, password = passWord };
            return await APIHelper<User>.Instance.Post(ApiRoutes.Account.LogIn, userLogin);
        }
    }
}
