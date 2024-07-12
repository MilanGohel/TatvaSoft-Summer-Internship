using Business_Logic_Layer;
using Data_Logic_Layer.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CIPlatFormWebApi_V1.Controllers
{
    [ApiController]
    public class CityController : ControllerBase
    {
        BALCity _balCity;
        public CityController(BALCity bALCity)
        {
            _balCity = bALCity;
            //_balCity = bALCity;
        }


        [HttpGet]
        [Route("/City/GetCityList")]
        public ResponseResult GetCities()
        {
            ResponseResult result = new ResponseResult();
            try
            {
                result.Data = _balCity.GetCities();
                result.Result = ResponseStatus.Success;

            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }
        [HttpGet]
        [Route("/Common/CityList/{countryId}")]
        public ResponseResult GetCityByCountryId(int countryId)
        {
            ResponseResult result = new ResponseResult();
            try
            {
                result.Data = _balCity.GetCityByCountryId(countryId);
                result.Result = ResponseStatus.Success;

            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }

    }
}
