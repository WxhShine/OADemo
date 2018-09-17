using OA.IBLL;
using OA.IDAL;
using OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.BLL {
    public class UserInfoService : BaseService<UserInfo>, IUserInfoService {
       
        public override void SetCurrentDal() {
            CurrentDal = this.CurrentDBSession.UserInfoDal;
        }

        public bool DeleteEntities(List<int> list) {
            var userInfoList = this.CurrentDBSession.UserInfoDal.LoadEntities(u=>list.Contains(u.Id));
            foreach(var item in userInfoList) {
                this.CurrentDBSession.UserInfoDal.DeleteEntity(item);
            }
            return this.CurrentDBSession.SaveChanges();
        }
    }
}
