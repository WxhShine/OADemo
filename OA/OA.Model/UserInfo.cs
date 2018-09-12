using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Model {
    public class UserInfo {
        [Key]
        public int Id { get; set; }
        public string UName { get; set; }
        public string UPwd { get; set; }
        public DateTime SubTime { get; set; }
        public short DelFlag { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string Remark { get; set; }
        public string Sort { get; set; }
    }
}
