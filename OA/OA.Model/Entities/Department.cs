using System;
using System.Collections.Generic;

namespace OA.Model {
    /// <summary>
    /// 部门表
    /// </summary>
    public class Department : BaseEntity {

        /// <summary>
        /// 父级Id
        /// </summary>
        public int ParentId { get; set; }
        public string TreePath { get; set; }
        
        public int Level { get; set; }
        public bool IsLeaf { get; set; }

        public virtual List<ActionInfo> ActionInfo { get; set; }
        public virtual List<UserInfo> UserInfo { get; set; }
    }
}
