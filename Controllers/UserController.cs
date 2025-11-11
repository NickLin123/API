using API1.DataContext;
using API1.DTO.DataModel;
using API1.DTO.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly Test_dbContext _dbContext;

        public UserController(ILogger<UserController> logger,Test_dbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }


        [HttpPost("Login")]
        public UserLoginRes UserLogin(UserLoginReq rqObj)
        {
            //實例化
            UserLoginRes resObj = new UserLoginRes();
            var user = _dbContext.Users.Where(x => x.Account == rqObj.UserEnterAccount).FirstOrDefault();
      
            if (user == null)
            {
                resObj.Action = "登入失敗";
                return resObj;
            }
            //驗證密碼是否成功
            if (user.Password != rqObj.UserEnterPassword)
            {
                resObj.Action = "登入失敗";
                return resObj;
            }
 
            resObj.Uid = user.Uid;
            resObj.Action = "登入成功";
            return resObj;
            

            //資訊顯示完整(加欄位)
            
        }
        [HttpPost("UserAddAccount")]
        //複習一次方法
        public UserAddAccountRes UserAddAccount(UserAddAccountReq rqObj) //res=給你甚麼、黃色方法名稱、()方法需要的東西 
        {
            UserAddAccountRes resObj = new UserAddAccountRes();

            //使用者輸入姓名

            //使用者輸入帳號

            //使用者輸入密碼

            //檢查帳號是否重複
            var user = _dbContext.Users.Where(x => x.Account == rqObj.UserEnterAccount).FirstOrDefault();

            //如果有重複，回傳錯誤訊息
            if (user != null)
            {
                resObj.Action = "註冊失敗，帳號重複";
                return resObj;
            }
            else
            {
                //如果沒有重複程式產生GUID，新增在資料表中，回傳註冊成功
                string GUID = Guid.NewGuid().ToString().ToUpper();
                user = new User();
                user.Account = rqObj.UserEnterAccount;
                user.Password = rqObj.UserEnterPassword;
                user.Name = rqObj.UserEnterName;
                user.Uid = GUID;
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
                resObj.Action = "註冊成功!";
                resObj.Uid = user.Uid;
                resObj.Name = user.Name;
                resObj.Account = user.Account;
            }
            return resObj;

            //思考前端註冊後需要顯示的資料(回傳res前端需要的資料)

            //直接刪除資料庫資料(問gpt 刪除語法)

            //修改使用者
        }

        //!刪除使用者api
        [HttpPost("UserDelete")]
        public UserDeleteAccountRes UserDelete(UserDeleteAccountReq rqObj) //res=給你甚麼、黃色方法名稱、()方法需要的東西 
        {
            UserDeleteAccountRes resObj = new UserDeleteAccountRes();

            //var user = _dbContext.Users.Where(x => x.Account == rqObj.UserEnterAccount).FirstOrDefault();
            var user = _dbContext.Users.Where(x => x.Account == rqObj.UserEnterAccount).FirstOrDefault();
            if (user == null)
            {
                resObj.Action = "刪除失敗，找不到該帳號";
                return resObj;
            }
            else
            {
                //禁用
                //user.Banned = true;

                //如果找到帳號sql直接刪除
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
                resObj.Action = "刪除成功";
            }

            return resObj;

        
        }
    }
}