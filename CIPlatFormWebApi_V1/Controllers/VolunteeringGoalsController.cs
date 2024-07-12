using Business_Logic_Layer;
using Data_Logic_Layer.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CIPlatFormWebApi_V1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VolunteeringGoalsController : ControllerBase
    {
        private readonly BALVolunteeringGoals _balVolunteeringGoals;

        public VolunteeringGoalsController(BALVolunteeringGoals balVolunteeringGoals)
        {
            _balVolunteeringGoals = balVolunteeringGoals;
        }

        [HttpPost]
        [Route("AddVolunteeringGoals")]
        public async Task<ResponseResult> AddVolunteeringGoals([FromBody] VolunteeringGoals goals)
        {
            var result = new ResponseResult();
            try
            {
                result.Message = await _balVolunteeringGoals.AddVolunteeringGoals(goals);
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
        [Route("GetVolunteeringGoalsList")]
        public ResponseResult GetVolunteeringGoalsList()
        {
            var result = new ResponseResult();
            try
            {
                result.Data = _balVolunteeringGoals.GetVolunteeringGoalsList();
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
        [Route("UpdateVolunteeringGoals/{id}")]
        public async Task<ResponseResult> UpdateVolunteeringGoals(int id, [FromBody] VolunteeringGoals goals)
        {
            var result = new ResponseResult();
            try
            {
                result.Message = await _balVolunteeringGoals.UpdateVolunteeringGoals(id, goals);
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
        [Route("DeleteVolunteeringGoals/{id}")]
        public async Task<ResponseResult> DeleteVolunteeringGoals(int id)
        {
            var result = new ResponseResult();
            try
            {
                result.Message = await _balVolunteeringGoals.DeleteVolunteeringGoals(id);
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
