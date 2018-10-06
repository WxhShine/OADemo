using OA.Model;
using OA.Model.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.IBLL {
    /// <summary>
    /// 用户业务逻辑接口
    /// </summary>
    public partial interface IUserInfoService:IBaseService<UserInfo> {
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        bool DeleteEntities(List<int> list);
        /// <summary>
        /// 完成用户信息的搜索
        /// </summary>
        /// <param name="userInfoSearch">封装的搜索条件数据</param>
        /// <returns></returns>
        IQueryable<UserInfo> LoadSearchEntities(UserInfoSearch userInfoSearch, short delFlag);
        /// <summary>
        /// 设置用户角色信息
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="roleIdList">角色id集合</param>
        /// <returns></returns>
        bool SetUserRoleInfo(int userId, List<int> roleIdList);
        /// <summary>
        /// 设置用户权限
        /// </summary>
        /// <param name="actionId"></param>
        /// <param name="userId"></param>
        /// <param name="isPass"></param>
        /// <returns></returns>
        bool SetUserActionInfo(int actionId, int userId, bool isPass);
    }
}
