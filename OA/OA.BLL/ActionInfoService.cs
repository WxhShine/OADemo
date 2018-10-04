using OA.IBLL;
using OA.Model;

namespace OA.BLL {
    /// <summary>
    /// 权限 业务逻辑类
    /// </summary>
    public partial class ActionInfoService : BaseService<ActionInfo>, IActionInfoService {
        
        public override void SetCurrentDal() {
            CurrentDal = this.CurrentDBSession.ActionInfoDal;
        }
    }
}