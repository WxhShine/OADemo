using OA.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace OA.DALFactory {
    /// <summary>
    /// 通过数据会话层工厂,保证线程唯一性
    /// </summary>
    public class DBSessionFactory {
        public static IDBSession CreateDBSession() {
            IDBSession DbSession = (IDBSession)CallContext.GetData("dbSession");
            if(DbSession == null) {
                DbSession = new DALFactory.DBSession();
                CallContext.SetData("dbSession", DbSession);
            }
            return DbSession;
        }
    }
}
