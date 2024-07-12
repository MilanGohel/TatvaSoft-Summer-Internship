using Business_Logic_Layer;
using Data_Logic_Layer.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CIPlatFormWebApi_V1.Controllers
{

    [ApiController]
    public class MissionApplicationController : Controller
    {
        BALMissionApplication _bALMissionApplication;
        public MissionApplicationController(BALMissionApplication balApplication)
        {
            _bALMissionApplication = balApplication;
        }


        [HttpGet]
        [Route("/Mission/MissionApplicationList")]
        public ResponseResult GetMissionApplications()
        {
            ResponseResult result = new ResponseResult();
            try
            {
                result.Data = _bALMissionApplication.GetMissionApplications();
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
        [Route("/Mission/DeleteMissionApplication/{data}")]
        public async Task<ResponseResult> DeleteMissionApplication(int data)
        {
            ResponseResult result = new ResponseResult();
            try
            {
                result.Data = await _bALMissionApplication.DeleteMissionApplication(data);
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
        [Route("/Mission/MissionApplicationApprove")]
        public async Task<ResponseResult> UpdateMissionApplication(int missionAppId, MissionApplication application)
        {
            ResponseResult result = new ResponseResult();
            try
            {
                result.Data = await _bALMissionApplication.UpdateMissionApplication(missionAppId, application);
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
        [Route("/Mission/AddMissionApplication")]
        public ResponseResult AddMissionApplication(MissionApplication application)
        {

            ResponseResult result = new ResponseResult();
            try
            {
                result.Data = _bALMissionApplication.AddMissionApplication(application);
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
