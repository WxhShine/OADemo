using System;
using System.Collections.Generic;

namespace OA.Model {

    /// <summary>
    /// 权限控制表
    /// </summary>
    public partial class R_UserInfo_ActionInfo : IdEntity{
        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserInfoID { get; set; }
        /// <summary>
        /// 权限Id
        /// </summary>
        public int ActionInfoID { get; set; }
        /// <summary>
        /// 是否拥有此权限
        /// </summary>
        public bool IsPass { get; set; }

        public virtual ActionInfo ActionInfo { get; set; }
        public virtual UserInfo UserInfo { get; set; }
    }
}
