using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace OA.Model {
    /// <summary>
    /// 用户表
    /// </summary>
    public class UserInfo : BaseEntity {
        /// <summary>
        /// 用户密码
        /// </summary>
        public string Pwd { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public string Sort { get; set; }

        [JsonIgnore]
        public virtual List<R_UserInfo_ActionInfo> R_UserInfo_ActionInfo { get; set; }
        [JsonIgnore]
        public virtual List<Department> Department { get; set; }
        [JsonIgnore]
        public virtual List<RoleInfo> RoleInfo { get; set; }
    }
}
