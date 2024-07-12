using Business_Logic_Layer;
using Data_Logic_Layer.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CIPlatFormWebApi_V1.Controllers
{
    [ApiController]
    public class MissionSkillController : ControllerBase
    {
        BALMissionSkill _balMissionSkill;
        public MissionSkillController(BALMissionSkill bALMissionSkill)
        {
            _balMissionSkill = bALMissionSkill;
        }

        
        [HttpGet]
        [Route("/MissionSkill/GetMissionSkillList")]
        [Route("/Common/MissionSkillList")]
        public ResponseResult GetMissionSkills()
        {
            ResponseResult result = new ResponseResult();
            try
            {
                result.Data = _balMissionSkill.GetMissionSkills();
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
        [Route("/MissionSkill/GetMissionSkillById/{id}")]
        public ResponseResult GetMissionSkillById(int id)
        {
            ResponseResult result = new ResponseResult();
            try
            {
                result.Data = _balMissionSkill.GetMissionSkillById(id);
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
        [Route("/MissionSkill/DeleteMissionSkill/{data}")]
        public async Task<ResponseResult> DeleteMissionSkill(int data)
        {
            ResponseResult result = new ResponseResult();
            try
            {
                result.Data = await _balMissionSkill.DeleteMissionSkill(data);
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
        [Route("/MissionSkill/UpdateMissionSkill")]
        public async Task<ResponseResult> UpdateMissionSkill(int missionAppId, MissionSkill application)
        {
            ResponseResult result = new ResponseResult();
            try
            {
                result.Data = await _balMissionSkill.UpdateMissionSkill(missionAppId, application);
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
        [Route("/MissionSkill/AddMissionSkill")]
        public ResponseResult AddMissionSkill(MissionSkill application)
        {

            ResponseResult result = new ResponseResult();
            try
            {
                result.Data = _balMissionSkill.AddMissionSkill(application);
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
