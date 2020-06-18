
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace FlightTicketManagement.Helper
{
    public class APIHelper<T>
    {
        private AuthenticatedUser user;
        private HttpClient apiClient { get ; set ; }
        private APIHelper()
        {
            InitializeClient();
        }
        private static APIHelper<T> instance = null;
        public static APIHelper<T> Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new APIHelper<T>();
                }
                return instance;
            }
        }

        public AuthenticatedUser User { get => user; set => user = value; }

        private void InitializeClient()
        {
            string api = ConfigurationManager.AppSettings["api"];
            apiClient = new HttpClient();
            apiClient.BaseAddress = new Uri(api);
            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
      
        public async Task<T> Get (string route)
        {
            using (HttpResponseMessage response = await apiClient.GetAsync(route))
            {

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsAsync<T>();
                    if(data != null)
                        return data;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
                return default;
            }
        }
        public async Task<List<T>> GetAll(string route)
        {
            using (HttpResponseMessage response = await apiClient.GetAsync(route))
            {

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsAsync<List<T>>();
                    if (data != null)
                        return data;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
                return default;
            }
        }

        public async Task<bool> Post(string route, object body)
        {
            using (HttpResponseMessage response = await apiClient.PostAsJsonAsync(route, body))
            {

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }

        //public async Task<bool> Update(string route, )
        //{
        //    using (HttpResponseMessage response = await apiClient.GetAsync(route))
        //    {

        //        if (response.IsSuccessStatusCode)
        //        {
        //            var data = await response.Content.ReadAsAsync<List<T>>();
        //            if (data != null)
        //                return data;
        //        }
        //        else
        //        {
        //            throw new Exception(response.ReasonPhrase);
        //        }
        //        return default;
        //    }
        //}

    }
}
