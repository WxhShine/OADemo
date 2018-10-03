using System;
using System.Collections.Generic;

namespace OA.Model {

    /// <summary>
    /// 角色表 
    /// </summary>
    public class RoleInfo : BaseEntity{
        public RoleInfo() {
            this.ActionInfo = new HashSet<ActionInfo>();
            this.UserInfo = new HashSet<UserInfo>();
        }

        /// <summary>
        /// 排序
        /// </summary>
        public string Sort { get; set; }

        public virtual ICollection<ActionInfo> ActionInfo { get; set; }
        public virtual ICollection<UserInfo> UserInfo { get; set; }
    }
}
