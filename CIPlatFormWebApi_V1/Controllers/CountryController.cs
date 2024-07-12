using Business_Logic_Layer;
using Data_Logic_Layer.Entity;
using Data_Logic_Layer;
using Microsoft.AspNetCore.Mvc;

namespace CIPlatFormWebApi_V1.Controllers
{
    [ApiController]
    public class CountryController : ControllerBase
    {
        BALCountry _balCountry;
        public CountryController(BALCountry balCountry)
        {
            _balCountry = balCountry;
        }   

        [HttpGet]
        [Route("/Common/CountryList")]
        [Route("/Common/MissionCountryList")]
        public ResponseResult GetCountries()
        {
            ResponseResult result = new ResponseResult();
            try
            {
                result.Data = _balCountry.GetCountries();
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Result = ResponseStatus.Error;
            }
            return result;
        }
    }
}
