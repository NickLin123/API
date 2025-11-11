using API1.DTO.Test;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        [HttpPost("Accacalate")]

        public TestRes Test(TestReq rqObj)
        {

            TestRes resObj = new TestRes();

            resObj.Number1 = rqObj.UserEnterNum1;
            resObj.Number2 = rqObj.UserEnterNum2;
            resObj.AnsAdd = rqObj.UserEnterNum1 + rqObj.UserEnterNum2;
            resObj.AnsSub = rqObj.UserEnterNum1 - rqObj.UserEnterNum2;

            return resObj;
            
        }
    }
}