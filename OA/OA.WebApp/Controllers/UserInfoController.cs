using OA.BLL;
using OA.IBLL;
using OA.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OA.WebApp.Controllers
{
    public class UserInfoController : Controller
    {
        IUserInfoService bll= new UserInfoService();
        // GET: UserInfo
        public ActionResult Index()
        {
            return View();
        }

        public  ActionResult GetUserInfoList() {
            int pageIndex = Request["page"] != null ? int.Parse(Request["page"]) : 1;
            int pageSize = Request["rows"] != null ? int.Parse(Request["rows"]) : 5;
            int totalCount;
            var delFlag = (short)DeleteEnumType.Normal;
            var userInfoList = bll.LoadPageEntities(pageIndex, pageSize, out totalCount, c => c.DelFlag == delFlag, c => c.Id,true);
            var temp = userInfoList.Select(x => new { ID = x.Id, UName = x.UName, UPwd = x.UPwd, Remark = x.Remark, SunTime = x.SubTime });
            return Json(new { rows = temp, total = totalCount});
        }
    }
}