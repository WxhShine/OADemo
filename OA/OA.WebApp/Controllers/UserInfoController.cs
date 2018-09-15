using OA.BLL;
using OA.IBLL;
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
            bll.LoadEntities(x => x.Id == 2);
            return View();
        }
    }
}