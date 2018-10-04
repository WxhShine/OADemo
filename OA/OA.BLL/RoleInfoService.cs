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
    }
}
