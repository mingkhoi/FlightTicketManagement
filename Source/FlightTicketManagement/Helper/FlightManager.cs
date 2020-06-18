using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace FlightTicketManagement.Helper
{
    class FlightManager : IManager
    {
        List<Flight> flights;
        private static FlightManager instance = null;
        public static FlightManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FlightManager();
                }
                return instance;
            }
        }


        public async Task GetAllFlight()
        {
            flights = await APIHelper<Flight>.Instance.GetAll(ApiRoutes.Flight.GetAll);
        }
        public List<Flight> GetFlightList()
        {
            return flights;
        }

        public Flight GetFromList(string id)
        {
            return flights.SingleOrDefault(x => x.Id == id);
        }

        public async Task<Flight> Get(string id)
        {
            return await APIHelper<Flight>.Instance.Get(ApiRoutes.Flight.Get.Replace(ApiRoutes.Key, id));
        }
        public async Task<bool> Update(Flight flight)
        {
            return await APIHelper<Flight>.Instance.Update(ApiRoutes.Flight.Update.Replace(ApiRoutes.Key, flight.Id), flight);
        }
        public async Task<bool> Delete(Flight flight)
        {
            return await APIHelper<Flight>.Instance.Delete(ApiRoutes.Flight.Delete.Replace(ApiRoutes.Key, flight.Id));
        }
        public async Task<bool> Create(Flight flight)
        {
            return await APIHelper<Flight>.Instance.Post(ApiRoutes.Flight.Create, flight);
        }



    }
}
