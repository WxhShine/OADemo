using OA.BLL;
using OA.IBLL;
using OA.Model;
using OA.Model.Enum;
using OA.Model.Search;
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

        /// <summary>
        /// 加载用户管理页面
        /// </summary>
        /// <returns></returns>
        public ActionResult GetUserInfoList() {
            int pageIndex = Request["page"] != null ? int.Parse(Request["page"]) : 1;
            int pageSize = Request["rows"] != null ? int.Parse(Request["rows"]) : 5;
            string userName = Request["name"];
            string userRemark = Request["remark"];
            int totalCount = 0;
            var userInfoSearch = new UserInfoSearch() { UserName = userName, UserRemark = userRemark, PageIndex = pageIndex, PageSize = pageSize, TotalCount = totalCount };
            var delFlag = (short)DeleteEnumType.Normal;
            //var userInfoList = bll.LoadPageEntities(pageIndex, pageSize, out totalCount, c => c.DelFlag == delFlag, c => c.Id,true).ToList();
            var userInfoList = bll.LoadSearchEntities(userInfoSearch, delFlag).ToList();
            var temp = userInfoList.Select(x => new { ID = x.Id, UName = x.UName, UPwd = x.UPwd, Remark = x.Remark, SunTime = x.SubTime.ToString("yyyy-MM-dd") });
            return Json(new { rows = temp.ToList(), total = userInfoSearch.TotalCount});
        }

        /// <summary>
        /// 批量删除用户
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteUserInfo() {
            string strId = Request["strId"];
            string[] strIds = strId.Split(',');
            List<int> list = new List<int>();
            foreach (string id in strIds) {
                list.Add(Convert.ToInt32(id));
            }
            if (bll.DeleteEntities(list)) {
                return Content("ok");
            } else {
                return Content("no");
            }
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public ActionResult AddUserInfo(UserInfo userInfo) {
            userInfo.DelFlag = 0;
            userInfo.ModifiedOn = DateTime.Now;
            userInfo.SubTime = DateTime.Now;
            bll.AddEntity(userInfo);
            return Content("ok");
        }

        
        /// <summary>
        /// 显示要修改用户
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowEditInfo() {
            int id = int.Parse(Request["id"]);
            var userInfo = bll.LoadEntities(u => u.Id == id).FirstOrDefault();
            return Json(userInfo, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public ActionResult EditUserInfo(UserInfo userInfo) {

            userInfo.ModifiedOn = DateTime.Now;
            if (bll.EditEntity(userInfo)) {
                return Content("ok");
            } else {
                return Content("no");
            }
        }
    }
}