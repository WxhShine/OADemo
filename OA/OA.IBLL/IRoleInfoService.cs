using System.Collections.Generic;
using OA.Model;

namespace OA.IBLL {
    public partial interface IRoleInfoService : IBaseService<RoleInfo> {
        /// <summary>
        /// 设置角色权限
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        bool SetRoleActionInfo(int roleId, List<int> list);
    }
}
