using Data_Logic_Layer;
using Data_Logic_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public class BALCountry
    {
        private readonly DALCountry _dalCountry;

        public BALCountry(DALCountry dalCountry)
        {
            _dalCountry = dalCountry;
        }

        public List<Countries> GetCountries()
        {
            return _dalCountry.GetCountries();
        }

        public List<Countries> GetCountryById(int countryId)
        {
            return _dalCountry.GetCountryById(countryId);
        }

        public async Task<string> UpdateCountry(int countryId, Countries country)
        {
            return await _dalCountry.UpdateCountry(countryId, country);
        }

        public async Task<string> DeleteCountry(int countryId)
        {
            return await _dalCountry.DeleteCountry(countryId);
        }

        public string AddCountry(Countries country)
        {
            return _dalCountry.AddCountry(country);
        }
    }
}
