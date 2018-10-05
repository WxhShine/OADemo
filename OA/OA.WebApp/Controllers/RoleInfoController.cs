using OA.IBLL;
using OA.Model;
using OA.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OA.WebApp.Controllers
{
    public class RoleInfoController : Controller
    {
        IRoleInfoService RoleInfoService { get; set; }
        IActionInfoService ActionInfoService { get; set; }

        // GET: RoleInfo
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <returns></returns>
        public ActionResult GetRoleInfoList() {
            int pageIndex = string.IsNullOrEmpty(Request["page"]) ? int.Parse(Request["page"]) : 1;
            int pageSize = string.IsNullOrEmpty(Request["rows"]) ? int.Parse(Request["rows"]) : 5;
            int totalCount;
            short delFlag = (short)DeleteEnumType.Normal;
            var roleInfoList = RoleInfoService.LoadPageEntities(pageIndex, pageSize, out totalCount, u => u.DelFlag == delFlag, u => u.Id, true).ToList();
            var temp = from r in roleInfoList
                       select new { ID = r.Id, r.Name, SubTime = r.SubTime,r.Remark };
            return Json(new { rows = temp, total = totalCount, JsonRequestBehavior.AllowGet });
        }
        
        /// <summary>
        /// 展示添加表单
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowAddInfo() {
            return View();
        }

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="roleInfo"></param>
        /// <returns></returns>
        public ActionResult AddRoleInfo(RoleInfo roleInfo) {
            roleInfo.ModifiedOn = DateTime.Now.ToString();
            roleInfo.SubTime = DateTime.Now.ToString();
            roleInfo.DelFlag = 0;
            RoleInfoService.AddEntity(roleInfo);
            return Content("ok");
        }

        /// <summary>
        /// 展示角色权限
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowRoleAction() {
            return View();
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteRoleInfo() {
            string strId = Request["strId"];
            var strIds = strId.Split(',');
            var ids = new List<int>();
            foreach(var i in strIds) {
                ids.Add(Convert.ToInt32(i));
            }
            if(RoleInfoService.BatchDeleteEntities(ids)) return Content("oK");
            return Content("No");
        }

        /// <summary>
        /// 展示要修改的角色信息
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowEditRoleInfo() {
            int id = int.Parse(Request["Id"]);
            var roleInfo = RoleInfoService.LoadEntities(x => x.Id == id).FirstOrDefault();
            return Json(roleInfo, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="roleInfo"></param>
        /// <returns></returns>
        public ActionResult EditRoleInfo(RoleInfo roleInfo) {
            roleInfo.ModifiedOn = DateTime.Now.ToString();
            if (RoleInfoService.EditEntity(roleInfo)) return Content("Ok");
            return Content("No");
        }
    }
}