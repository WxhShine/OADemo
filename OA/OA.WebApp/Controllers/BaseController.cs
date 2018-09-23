using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OA.WebApp.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// 执行控制器中的方法之前先执行该方法
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext) {
            base.OnActionExecuting(filterContext);
            if(Session["UserInfo"] == null) {
                //filterContext.HttpContext.Response.Redirect("/Login/Index");
                // 不能用上面的写法,因为使用以上写法当进入判断后,因没有Result 会依然执行后续代码.
                filterContext.Result = Redirect("/Login/Index");
            }
        }
    }
}