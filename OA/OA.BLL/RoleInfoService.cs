using System.Collections.Generic;
using System.Linq;
using OA.IBLL;
using OA.Model;

namespace OA.BLL {
    /// <summary>
    /// 角色业务逻辑类
    /// </summary>
    public partial class RoleInfoService : BaseService<RoleInfo>, IRoleInfoService {

        public override void SetCurrentDal() {
            CurrentDal = this.CurrentDBSession.RoleInfoDal;
        }

        /// <summary>
        /// 设置角色权限
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool SetRoleActionInfo(int roleId, List<int> list) {
            var roleInfo = CurrentDBSession.RoleInfoDal.LoadEntities(x => x.Id == roleId).FirstOrDefault();
            if(roleInfo != null) {
                roleInfo.ActionInfo.Clear();
                var actionInfos = CurrentDBSession.ActionInfoDal.LoadEntities(x => list.Contains(x.Id)).ToList();
                roleInfo.ActionInfo.AddRange(actionInfos);
                return this.CurrentDBSession.SaveChanges();
            }
            return false;
        }
    }
}
