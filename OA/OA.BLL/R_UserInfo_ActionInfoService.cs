using OA.IBLL;
using OA.Model;

namespace OA.BLL {
    /// <summary>
    /// 用户-权限 业务逻辑类
    /// </summary>
    public class R_UserInfo_ActionInfoService : BaseService<R_UserInfo_ActionInfo>, IR_UserInfo_ActionInfoService {

        public override void SetCurrentDal() {
            CurrentDal = this.CurrentDBSession.R_UserInfo_ActionInfoDal;
        }
    }
}
