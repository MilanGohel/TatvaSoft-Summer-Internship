using Business_Logic_Layer;
using Data_Logic_Layer.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CIPlatFormWebApi_V1.Controllers
{
    [ApiController]
    public class CMSController : ControllerBase
    {
        private readonly BALCMS _balCMS;

        public CMSController(BALCMS balCMS)
        {
            _balCMS = balCMS;
        }

        [HttpGet]
        [Route("/CMS/GetCMSList")]
        public ResponseResult GetCMSList()
        {
            ResponseResult result = new ResponseResult();
            try
            {
                result.Data = _balCMS.GetCMSList();
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
        [Route("/CMS/GetCMSById/{id}")]
        public ResponseResult GetCMSById(int id)
        {
            ResponseResult result = new ResponseResult();
            try
            {
                result.Data = _balCMS.GetCMSById(id);
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
        [Route("/CMS/AddCMS")]
        public async Task<ResponseResult> AddCMS([FromBody] CMS cms)
        {
            ResponseResult result = new ResponseResult();
            try
            {
                result.Message = await _balCMS.AddCMS(cms);
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
        [Route("/CMS/UpdateCMS/{id}")]
        public async Task<ResponseResult> UpdateCMS(int id, [FromBody] CMS cms)
        {
            ResponseResult result = new ResponseResult();
            try
            {
                result.Message = await _balCMS.UpdateCMS(id, cms);
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
        [Route("/CMS/DeleteCMS/{id}")]
        public async Task<ResponseResult> DeleteCMS(int id)
        {
            ResponseResult result = new ResponseResult();
            try
            {
                result.Message = await _balCMS.DeleteCMS(id);
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
