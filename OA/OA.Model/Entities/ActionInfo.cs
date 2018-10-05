using System;
using System.Collections.Generic;

namespace OA.Model {

    /// <summary>
    /// 权限类别表
    /// </summary>
    public class ActionInfo : BaseEntity{

        /// <summary>
        /// 此权限的url地址(控制器的方法地址)
        /// 若有此权限,则可访问控制器的方法
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 访问url的请求方式
        /// </summary>
        public string HttpMethod { get; set; }
        /// <summary>
        /// 访问的方法名
        /// </summary>
        public string ActionMethodName { get; set; }
        /// <summary>
        /// 访问的控制器名
        /// </summary>
        public string ControllerName { get; set; }
        /// <summary>
        /// 权限名
        /// </summary>
        public string ActionInfoName { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public string Sort { get; set; }
        /// <summary>
        /// 权限类别
        /// </summary>
        public short ActionTypeEnum { get; set; }
        /// <summary>
        /// 菜单图标
        /// </summary>
        public string MenuIcon { get; set; }
        public int IconWidth { get; set; }
        public int IconHeight { get; set; }

        public virtual List<R_UserInfo_ActionInfo> R_UserInfo_ActionInfo { get; set; }
        public virtual List<Department> Department { get; set; }
        public virtual List<RoleInfo> RoleInfo { get; set; }
    }
}
