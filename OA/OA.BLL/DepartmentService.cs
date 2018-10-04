using OA.IBLL;
using OA.Model;

namespace OA.BLL {
    /// <summary>
    /// 部门业务逻辑类
    /// </summary>
    public partial class DepartmentService : BaseService<Department>, IDepartmentService {

        public override void SetCurrentDal() {
            CurrentDal = this.CurrentDBSession.DepartmentDal;
        }
    }
}
