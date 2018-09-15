using System;

namespace OA.Model {
    public class UserInfo : BaseEntity {
        
        public string UName { get; set; }
        public string UPwd { get; set; }
        public DateTime SubTime { get; set; }
        public short DelFlag { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string Remark { get; set; }
        public string Sort { get; set; }
    }
}
