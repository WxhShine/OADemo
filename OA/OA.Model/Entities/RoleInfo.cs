using System;
using System.Collections.Generic;

namespace OA.Model {

    /// <summary>
    /// 角色表 
    /// </summary>
    public class RoleInfo : BaseEntity{

        /// <summary>
        /// 排序
        /// </summary>
        public string Sort { get; set; }

        public virtual List<ActionInfo> ActionInfo { get; set; }
        public virtual List<UserInfo> UserInfo { get; set; }
    }
}
