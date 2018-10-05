using System;
using System.ComponentModel.DataAnnotations;

namespace OA.Model {
    public class BaseEntity : IdEntity {

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string SubTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 逻辑删除标识
        /// </summary>
        public short DelFlag { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public string ModifiedOn { get; set; }
    }
}
