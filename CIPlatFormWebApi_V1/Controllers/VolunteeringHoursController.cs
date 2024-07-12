using Business_Logic_Layer;
using Data_Logic_Layer.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CIPlatFormWebApi_V1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VolunteeringHoursController : ControllerBase
    {
        private readonly BALVolunteeringHours _balVolunteeringHours;

        public VolunteeringHoursController(BALVolunteeringHours balVolunteeringHours)
        {
            _balVolunteeringHours = balVolunteeringHours;
        }

        [HttpPost]
        [Route("AddVolunteeringHours")]
        public async Task<ResponseResult> AddVolunteeringHours([FromBody] VolunteeringHours hours)
        {
            var result = new ResponseResult();
            try
            {
                result.Message = await _balVolunteeringHours.AddVolunteeringHours(hours);
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
        [Route("GetVolunteeringHoursList")]
        public ResponseResult GetVolunteeringHoursList()
        {
            var result = new ResponseResult();
            try
            {
                result.Data = _balVolunteeringHours.GetVolunteeringHoursList();
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }

        [HttpPut]
        [Route("UpdateVolunteeringHours/{id}")]
        public async Task<ResponseResult> UpdateVolunteeringHours(int id, [FromBody] VolunteeringHours hours)
        {
            var result = new ResponseResult();
            try
            {
                result.Message = await _balVolunteeringHours.UpdateVolunteeringHours(id, hours);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }

        [HttpDelete]
        [Route("DeleteVolunteeringHours/{id}")]
        public async Task<ResponseResult> DeleteVolunteeringHours(int id)
        {
            var result = new ResponseResult();
            try
            {
                result.Message = await _balVolunteeringHours.DeleteVolunteeringHours(id);
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
