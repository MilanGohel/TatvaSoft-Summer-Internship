using Data_Logic_Layer;
using Data_Logic_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public class BALCity
    {
        private readonly DALCity _dalCity;
        public BALCity(DALCity dalCity)
        {
            _dalCity = dalCity;
        }

        public List<Cities> GetCities()
        {
            return _dalCity.GetCities();
        }
        public List<Cities> GetCityByCountryId(int countryId)
        {
            return _dalCity.GetCityByCountryId(countryId);
        }

        public async Task<string> UpdateCity(int cityId, Cities city)
        {
            return await _dalCity.UpdateCity(cityId, city);
        }
        public async Task<string> DeleteCity(int cityId)
        {
            return await _dalCity.DeleteCity(cityId);
        }

        public  string AddCity(Cities city)
        {
            return  _dalCity.AddCity(city);
        }

    }
}
