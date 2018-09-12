using OA.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace OA.DAL {
    /// <summary>
    /// 负责创建EF数据操作上下文实例，保证线程内对象唯一
    /// </summary>
    public class DBContextFactory {
        public static DbContext CreateDbContext() {
            DbContext dbContext = (DbContext)CallContext.GetData("dbContext");
            if(dbContext == null) {
                dbContext = new OAContext();
                CallContext.SetData("dbContext", dbContext);
            }
            return dbContext;
        }
    }
}
