using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Model {
    public class OAContext : DbContext {
        public OAContext() : base("OAContext") {}
        
        public DbSet<UserInfo> UserInfo { get; set; }
    }
}
