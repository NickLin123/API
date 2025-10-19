using API1.DTO.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpPost("Login")]

        public UserLoginRes UserLogin(UserLoginReq rqObj)
        {

            UserLoginRes resObj = new UserLoginRes();
            
            //將帳號加入List中
            List<string> userList = new List<string>();
            userList.Add("Bill");
            userList.Add("Nick");
            userList.Add("Lisa");

           

            for (int i=0; i<userList.Count; i++)
            {
                _logger.LogInformation("使用者列表：{Users}", userList[i]);
                if (rqObj.UserEnterAccount == userList[i])
                {
                    resObj.Action = "登入成功";
                    return resObj;
                }
                else
                {
                    resObj.Action = "登入失敗";
                }
            }


            //使用者的帳密 todo 須連db 先做假資料
            //string Account = "Nic";
            //string Password = "123";

            //驗證是否成功
            //Boolean LoginState = false;

            //if (Account != rqObj.UserEnterAccount || Password != rqObj.UserPassword)
            //{

            //    LoginState = false;
            //    _logger.LogInformation("登入失敗", LoginState);
            //    resObj.Action = "登入失敗";
            //}
            //else
            //{
            //    _logger.LogWarning("登入成功", LoginState);
            //    resObj.Action = "登入成功";
            //}
            return resObj;
            
        }
    }
}