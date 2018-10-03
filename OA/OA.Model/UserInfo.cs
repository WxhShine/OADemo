using System;

namespace OA.Model {
    public class UserInfo : BaseEntity {
        
        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string Pwd { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime SubTime { get; set; }
        /// <summary>
        /// 逻辑删除标记
        /// </summary>
        public short DelFlag { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime ModifiedOn { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public string Sort { get; set; }
    }
}
