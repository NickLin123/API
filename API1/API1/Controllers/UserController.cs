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
            
            //�N�b���[�JList��
            List<string> userList = new List<string>();
            userList.Add("Bill");
            userList.Add("Nick");
            userList.Add("Lisa");

           

            for (int i=0; i<userList.Count; i++)
            {
                _logger.LogInformation("�ϥΪ̦C��G{Users}", userList[i]);
                if (rqObj.UserEnterAccount == userList[i])
                {
                    resObj.Action = "�n�J���\";
                    return resObj;
                }
                else
                {
                    resObj.Action = "�n�J����";
                }
            }


            //�ϥΪ̪��b�K todo ���sdb ���������
            //string Account = "Nic";
            //string Password = "123";

            //���ҬO�_���\
            //Boolean LoginState = false;

            //if (Account != rqObj.UserEnterAccount || Password != rqObj.UserPassword)
            //{

            //    LoginState = false;
            //    _logger.LogInformation("�n�J����", LoginState);
            //    resObj.Action = "�n�J����";
            //}
            //else
            //{
            //    _logger.LogWarning("�n�J���\", LoginState);
            //    resObj.Action = "�n�J���\";
            //}
            return resObj;
            
        }
    }
}