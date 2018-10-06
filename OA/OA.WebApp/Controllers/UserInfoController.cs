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
        /// <summary>
        /// 用户信息业务
        /// </summary>
        IUserInfoService UserInfoService { get; set; }
        /// <summary>
        /// 角色信息业务
        /// </summary>
        IRoleInfoService RoleInfoService { get; set; }
        /// <summary>
        /// 权限信息业务
        /// </summary>
        IActionInfoService ActionInfoService { get; set; }
        /// <summary>
        /// 用户-权限 业务
        /// </summary>
        IR_UserInfo_ActionInfoService R_UserInfo_ActionInfoService { get; set; }

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
            var userInfoList = UserInfoService.LoadSearchEntities(userInfoSearch, delFlag).ToList();
            var temp = userInfoList.Select(x => new { ID = x.Id, UName = x.Name, UPwd = x.Pwd, Remark = x.Remark, SunTime = x.SubTime});
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
            if (UserInfoService.DeleteEntities(list)) {
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
            userInfo.ModifiedOn = DateTime.Now.ToString();
            userInfo.SubTime = DateTime.Now.ToString();
            UserInfoService.AddEntity(userInfo);
            return Content("ok");
        }

        /// <summary>
        /// 显示要修改用户
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowEditInfo() {
            int id = int.Parse(Request["id"]);
            var userInfo = UserInfoService.LoadEntities(u => u.Id == id).FirstOrDefault();
            var data = Json(userInfo);
            var res = data.Data;
            return Json(userInfo);
        }

        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public ActionResult EditUserInfo(UserInfo userInfo) {
            userInfo.ModifiedOn = DateTime.Now.ToString();
            if (UserInfoService.EditEntity(userInfo)) {
                return Content("ok");
            } else {
                return Content("no");
            }
        }

        /// <summary>
        /// 为用户分配角色
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowUserRoleInfo() {
            int id = int.Parse(Request["id"]);
            var userInfo = UserInfoService.LoadEntities(x => x.Id == id).FirstOrDefault();
            ViewBag.UserInfo = userInfo;
            short delFlag = (short)DeleteEnumType.Normal;
            var allRoleList = RoleInfoService.LoadEntities(x => x.DelFlag == delFlag).ToList();
            var allUserRoleIdList = userInfo.RoleInfo.Select(x => x.Id).ToList();
            ViewBag.AllRoleList = allRoleList;
            ViewBag.AllUserRoleIdList = allUserRoleIdList;
            return View();
        }

        /// <summary>
        /// 设置用户角色
        /// </summary>
        /// <returns></returns>
        public ActionResult SetUserRoleInfo() {
            int userId = int.Parse(Request["userId"]);
            string[] allKeys = Request.Form.AllKeys;//获取表单元素的Name属性
            var roleIdList = new List<int>();
            foreach(var item in allKeys) {
                if (item.StartsWith("role_")) {
                    string k = item.Replace("role_", "");
                    roleIdList.Add(int.Parse(k));
                }
            }
            if (UserInfoService.SetUserRoleInfo(userId, roleIdList)) return Content("ok");
            return Content("no");
        }

        public ActionResult ShowUserActionInfo() {
            int userId = int.Parse(Request["userId"]);
            var userInfo = UserInfoService.LoadEntities(x => x.Id == userId).FirstOrDefault();
            ViewBag.UserInfo = userInfo;
            var allActionInfos = ActionInfoService.LoadEntities(x => x.DelFlag == (short)DeleteEnumType.Normal).ToList();
            var allUserActionIds = userInfo.R_UserInfo_ActionInfo.ToList();
            ViewBag.AllActionInfos = allActionInfos;
            ViewBag.AllUserActionIds = allUserActionIds;
            return View();
        }

        /// <summary>
        /// 设置用户权限
        /// </summary>
        /// <returns></returns>
        public ActionResult SetUserAction() {
            int actionId = int.Parse(Request["actionId"]);
            int userId = int.Parse(Request["userId"]);
            bool isPass = Request["isPass"] == "true" ? true : false;
            if (UserInfoService.SetUserActionInfo(actionId, userId, isPass)) {
                return Content("ok");
            } else {
                return Content("no");
            }
        }

        /// <summary>
        /// 清空用户权限
        /// </summary>
        /// <returns></returns>
        public ActionResult ClearUserAction() {
            int actionId = int.Parse(Request["actionId"]);
            int userId = int.Parse(Request["userId"]);
            var r_userInfo_actionInfo = R_UserInfo_ActionInfoService.LoadEntities(r => r.ActionInfoID == actionId && r.UserInfoID == userId).FirstOrDefault();
            if (r_userInfo_actionInfo != null) {
                if (R_UserInfo_ActionInfoService.DeleteEntity(r_userInfo_actionInfo)) {
                    return Content("ok:删除成功!!");
                } else {
                    return Content("ok:删除失败!!");
                }
            } else {
                return Content("no:数据不存在!!");
            }
        }
    }
}