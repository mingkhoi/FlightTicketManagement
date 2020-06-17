using FlightTicketManagement.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FlightTicketManagement.Helper
{
    public class APIHelper 
    {
        private AuthenticatedUser user { get; set; }
        private HttpClient apiClient { get ; set ; }
        private APIHelper()
        {
            InitializeClient();
        }
        private static APIHelper instance = null;
        public static APIHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new APIHelper();
                }
                return instance;
            }
        }

        private void InitializeClient()
        {
            string api = ConfigurationManager.AppSettings["api"];
            apiClient = new HttpClient();
            apiClient.BaseAddress = new Uri(api);
            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<bool> Authenticate(string userName, string passWord)
        {
            //var data = new FormUrlEncodedContent(new[]
            //{
            //    new KeyValuePair<string,string>("username",username),
            //    new KeyValuePair<string,string>("password",password)

            //});
            var userLogin = new User { username = userName, password = passWord };
            using (HttpResponseMessage response = await apiClient.PostAsJsonAsync(ApiRoutes.Account.LogIn,userLogin))
            {
                Console.WriteLine(response.Content);
                if (response.IsSuccessStatusCode)
                {
                    user = await response.Content.ReadAsAsync<AuthenticatedUser>();
                    return true;
                }
                    return false;

              
               
            }
        }
    }
}
