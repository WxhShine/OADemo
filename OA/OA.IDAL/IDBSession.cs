using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.IDAL {
    /// <summary>
    /// 业务层调用的是数据会话层的接口
    /// </summary>
    public interface IDBSession {
        DbContext Db { get; }
        IUserInfoDal UserInfoDal { get; set; }

        IActionInfoDal ActionInfoDal { get; set; }

        IDepartmentDal DepartmentDal { get; set; }

        IR_UserInfo_ActionInfoDal R_UserInfo_ActionInfoDal { get; set; }

        IRoleInfoDal RoleInfoDal { get; set; }


        bool SaveChanges();
        }
}
