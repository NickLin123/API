using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private static readonly string[] Info = new[]
        {
            "登入成功",
            "登出成功"
        };

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet("Login",Name = "GetUserLog")]
        public IEnumerable<UserInfo> Get()
        {
            string UserEnterAccount = "Nick";
            string UserPassword = "1234";
            string Account = "Nic";
            string Password = "123";
            Boolean LoginState = false;

            if (UserEnterAccount == Account && UserPassword == Password)
            {

                LoginState = true;
                _logger.LogInformation("登入成功",LoginState);
            }
            else
            {
                _logger.LogWarning("登入失敗", LoginState);
            }
            return Enumerable.Range(0, Info.Length).Select(index => new UserInfo
            {
                Action = Info[index]
            })
          .ToArray();
        }
}


    public class UserInfo
    {
        public string Action { get; set; } = string.Empty;
    }
}