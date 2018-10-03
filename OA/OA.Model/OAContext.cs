using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Model {
    public class OAContext : DbContext {
        public OAContext() : base("OAContext") {}
        
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<RoleInfo> RoleInfo { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<ActionInfo> ActionInfos { get; set; }
        public DbSet<R_UserInfo_ActionInfo> R_UserInfo_ActionInfo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            //在数据库中创建表的表名单复数形式    (默认为复数形式,此代码为单数形式(移除复数形式))
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
