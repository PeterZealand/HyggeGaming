using HyggeGaming.Models;
using HyggeGaming.Services.Interfaces;

namespace HyggeGaming.Services.EFService
{
    public class EFCityService: ICityService
    {
        private HGDBContext context;
        public EFCityService(HGDBContext service)
        {
            context = service;
        }


        public IEnumerable<City> GetCities()
        {
            throw new NotImplementedException();
        }
    }
}
