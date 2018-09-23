using OA.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OA.WebApp.Controllers
{
    public class LoginController : Controller
    {
        IUserInfoService UserInfoService { get; set; }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 显示验证码
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowValidateCode() {
            Common.ValidateCode validateCode = new Common.ValidateCode();
            string code = validateCode.CreateValidateCode(4);//产生验证码
            Session["validateCode"] = code;
            var buff = validateCode.CreateValidateGraphic(code);//将验证码画在画布上

            return File(buff,"image/jpeg");
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public ActionResult UserLogin() {
            string validateCode = Session["validateCode"] != null ? Session["validateCode"].ToString
                (): string.Empty;
            if (string.IsNullOrEmpty(validateCode)) {
                return Content("no:验证码错误");
            }
            Session["validateCode"] = null;
            string txtCode = Request["vCode"];
            if (!validateCode.Equals(txtCode, StringComparison.InvariantCultureIgnoreCase)) {
                 return Content("no:验证码错误");
            }
            string userName = Request["LoginCode"];
            string userPwd = Request["LoginPwd"];
            var userInfo = UserInfoService.LoadEntities(x => x.UName == userName && x.UPwd == userPwd).FirstOrDefault();
            if (userInfo != null) {
                //在此用session储存有隐患,不支持分布式系统
                Session["userInfo"] = userInfo;
                return Content("ok:登录成功");
            } else {
                return Content("no:登录失败");
            }
        }
    }
}