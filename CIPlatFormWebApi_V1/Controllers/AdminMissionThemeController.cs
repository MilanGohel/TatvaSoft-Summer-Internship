using Business_Logic_Layer;
using Data_Logic_Layer.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CIPlatFormWebApi_V1.Controllers
{
    
    [ApiController]
    public class AdminMissionThemeController : ControllerBase
    {
        BALAdminMissionTheme _bALAdminMissionTheme;
        public AdminMissionThemeController(BALAdminMissionTheme bALAdminMissionTheme)
        {
            _bALAdminMissionTheme = bALAdminMissionTheme;
        }

        
        [HttpGet]
        [Route("/Mission/GetMissionThemeList")]
        [Route("/Common/MissionThemeList")]
        public ResponseResult GetMissionThemes()
        {
            ResponseResult result = new ResponseResult();
            try
            {
                result.Data = _bALAdminMissionTheme.GetMissionThemes();
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
        [Route("/MissionTheme/GetMissionThemeById/{id}")]
        public ResponseResult GetMissionThemeById(int id)
        {
            ResponseResult result = new ResponseResult();
            try
            {

                result.Data = _bALAdminMissionTheme.GetMissionThemeById(id);                
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
        [Route("/MissionTheme/DeleteMissionTheme/{data}")]
        public async Task<ResponseResult> DeleteMissionTheme(int data)
        {
            ResponseResult result = new ResponseResult();
            try
            {
                result.Data = await _bALAdminMissionTheme.DeleteMissionTheme(data);
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
        [Route("/MissionTheme/UpdateMissionTheme")]
        public async Task<ResponseResult> UpdateMissionTheme(int missionThemeId, MissionTheme theme)
        {
            ResponseResult result = new ResponseResult();
            try
            {
                result.Data = await _bALAdminMissionTheme.UpdateMissionTheme(missionThemeId, theme);
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
        [Route("/MissionTheme/AddMissionTheme")]
        public ResponseResult AddMissionTheme(MissionTheme theme)
        {

            ResponseResult result = new ResponseResult();
            try
            {
                result.Data = _bALAdminMissionTheme.AddMissionTheme(theme);
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
