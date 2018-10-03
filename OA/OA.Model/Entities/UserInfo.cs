using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace OA.Model {
    /// <summary>
    /// 用户表
    /// </summary>
    public class UserInfo : BaseEntity {
        public UserInfo() {
            this.R_UserInfo_ActionInfo = new HashSet<R_UserInfo_ActionInfo>();
            this.Department = new HashSet<Department>();
            this.RoleInfo = new HashSet<RoleInfo>();
        }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string Pwd { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public string Sort { get; set; }

        [JsonIgnore]
        public virtual ICollection<R_UserInfo_ActionInfo> R_UserInfo_ActionInfo { get; set; }
        [JsonIgnore]
        public virtual ICollection<Department> Department { get; set; }
        [JsonIgnore]
        public virtual ICollection<RoleInfo> RoleInfo { get; set; }
    }
}
