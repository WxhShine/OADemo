using OA.Model;
using OA.Model.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.IBLL {
    public interface IUserInfoService:IBaseService<UserInfo> {
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
    }
}
