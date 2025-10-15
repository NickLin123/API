using Microsoft.AspNetCore.Mvc;

namespace API1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private static readonly string[] Info = new[]
        {
            "登入",
            "登出成功"
        };

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetUserLog")]
        public IEnumerable<UserInfo> Get()
        {
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