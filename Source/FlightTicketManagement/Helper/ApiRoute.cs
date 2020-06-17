using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightTicketManagement.Helper
{
    public class ApiRoutes
    {
        public const string Root = "api";
        //public const string Version = "v1";
        public const string Base = Root /*+ "/" + Version*/;
        public static class Account
        {
            public const string LogIn = Base + "/account/login";
            public const string SignUp = Base + "/account/signup";

        }
        public static class Flight

        {
            public const string GetAll = Base + "/posts";

            public const string Get = Base + "/posts/{postId}";

            public const string Update = Base + "/posts/{postId}";

            public const string Delete = Base + "/posts/{postId}";

            public const string Create = Base + "/posts";
        }
    }
}
