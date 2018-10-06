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
    /// <summary>
    /// 用户业务逻辑类
    /// </summary>
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
                temp = temp.Where(u => u.Name.Contains(userInfoSearch.UserName));
            }
            if (!string.IsNullOrEmpty(userInfoSearch.UserRemark)) {
                temp = temp.Where(u => u.Remark.Contains(userInfoSearch.UserRemark));
            }
            userInfoSearch.TotalCount = temp.Count();
            return temp.OrderBy(u => u.Id).Skip((userInfoSearch.PageIndex - 1) * userInfoSearch.PageSize).Take(userInfoSearch.PageSize);
        }

        /// <summary>
        /// 设置用户角色信息
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleIdList"></param>
        /// <returns></returns>
        public bool SetUserRoleInfo(int userId, List<int> roleIdList) {
            var userInfo = this.CurrentDal.LoadEntities(x => x.Id == userId).FirstOrDefault();
            if (userInfo != null) {
                var roleInfoes = this.CurrentDBSession.RoleInfoDal.LoadEntities(x => roleIdList.Contains(x.Id));
                userInfo.RoleInfo.Clear();
                userInfo.RoleInfo.AddRange(roleInfoes.ToList());
                return this.CurrentDBSession.SaveChanges();
            }
            return false;
        }

        /// <summary>
        /// 设置用户权限
        /// </summary>
        /// <param name="actionId"></param>
        /// <param name="userId"></param>
        /// <param name="isPass"></param>
        /// <returns></returns>
        public bool SetUserActionInfo(int actionId, int userId, bool isPass) {

            //判断userId以前是否有了该actionId,如果有了只需要修改isPass状态，否则插入。
            var r_userInfo_actionInfo = this.CurrentDBSession.R_UserInfo_ActionInfoDal.LoadEntities(a => a.ActionInfoID == actionId && a.UserInfoID == userId).FirstOrDefault();
            if (r_userInfo_actionInfo == null) {
                R_UserInfo_ActionInfo userInfoActionInfo = new R_UserInfo_ActionInfo {
                    ActionInfoID = actionId,
                    UserInfoID = userId,
                    IsPass = isPass
                };
                this.CurrentDBSession.R_UserInfo_ActionInfoDal.AddEntity(userInfoActionInfo);
            } else {
                r_userInfo_actionInfo.IsPass = isPass;
                this.CurrentDBSession.R_UserInfo_ActionInfoDal.EditEntity(r_userInfo_actionInfo);
            }
            return this.CurrentDBSession.SaveChanges();
        }
    }
}
