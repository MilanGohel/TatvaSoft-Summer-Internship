using Business_Logic_Layer;
using Data_Logic_Layer.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CIPlatFormWebApi_V1.Controllers
{
    [ApiController]
    public class MissionController : ControllerBase
    {
        BALMission _balMission;
        public MissionController(BALMission bALMission)
        {
            _balMission = bALMission;
        }


        [HttpGet]
        [Route("/Mission/MissionList")]
        public ResponseResult GetMissions()
        {
            ResponseResult result = new ResponseResult();
            try
            {
                result.Data = _balMission.GetMissions();
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
        [Route("/Mission/GetMissionById/{id}")]
        public ResponseResult GetMissionById(int id)
        {
            ResponseResult result = new ResponseResult();
            try
            {
                result.Data = _balMission.GetMissionById(id);
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
        [Route("/Mission/DeleteMission/{data}")]
        public async Task<ResponseResult> DeleteMission(int data)
        {
            ResponseResult result = new ResponseResult();
            try
            {
                result.Data = await _balMission.DeleteMission(data);
                result.Result = ResponseStatus.Success;

            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("/Mission/UpdateMission")]
        public async Task<ResponseResult> UpdateMission(int missionAppId, Mission application)
        {
            ResponseResult result = new ResponseResult();
            try
            {
                result.Data = await _balMission.UpdateMission(missionAppId, application);
                result.Result = ResponseStatus.Success;

            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("/Mission/AddMission")]
        public ResponseResult AddMission(Mission application)
        {

            ResponseResult result = new ResponseResult();
            try
            {
                result.Data = _balMission.AddMission(application);
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
