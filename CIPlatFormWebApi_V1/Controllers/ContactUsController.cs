using Business_Logic_Layer;
using Data_Logic_Layer.Entity;
using Data_Logic_Layer;
using Microsoft.AspNetCore.Mvc;

namespace CIPlatFormWebApi_V1.Controllers
{
    [ApiController]
    public class ContactUsController : Controller
    {
        BALContactUs _bALContactUs;
        public ContactUsController(BALContactUs bALContactUs)
        {
            _bALContactUs = bALContactUs;
        }

        [HttpPost]
        [Route("/ContactUs")]
        public ResponseResult AddMission(ContactUs contactUs)
        {

            ResponseResult result = new ResponseResult();
            try
            {
                result.Data = _bALContactUs.AddContactUs(contactUs);
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
