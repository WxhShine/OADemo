using OA.IBLL;
using OA.IDAL;
using OA.Model;
using OA.Model.Search;
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

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool DeleteEntities(List<int> list) {
            var userInfoList = this.CurrentDBSession.UserInfoDal.LoadEntities(u => list.Contains(u.Id));
            foreach (var item in userInfoList) {
                this.CurrentDBSession.UserInfoDal.DeleteEntity(item);
            }
            return this.CurrentDBSession.SaveChanges();
        }

        /// <summary>
        /// 完成用户信息的搜索
        /// </summary>
        /// <param name="userInfoSearch">封装的搜索条件数据</param>
        /// <returns></returns>
        public IQueryable<UserInfo> LoadSearchEntities(UserInfoSearch userInfoSearch, short delFlag) {
            var temp = CurrentDal.LoadEntities(c => c.DelFlag == delFlag);
            //根据用户名来搜索
            if (!string.IsNullOrEmpty(userInfoSearch.UserName)) {
                temp = temp.Where(u => u.UName.Contains(userInfoSearch.UserName));
            }
            if (!string.IsNullOrEmpty(userInfoSearch.UserRemark)) {
                temp = temp.Where(u => u.Remark.Contains(userInfoSearch.UserRemark));
            }
            userInfoSearch.TotalCount = temp.Count();
            return temp.OrderBy(u => u.Id).Skip((userInfoSearch.PageIndex - 1) * userInfoSearch.PageSize).Take(userInfoSearch.PageSize);
        }
    }
}
