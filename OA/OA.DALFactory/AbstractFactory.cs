using OA.IDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OA.DALFactory {
    /// <summary>
    /// 抽象工厂类
    /// 通过反射机制,创建各个数据操作类实例
    /// </summary>
    public partial class AbstractFactory {
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["AssemblyPath"];
        private static readonly string NameSpace = ConfigurationManager.AppSettings["NameSpace"];

        /// <summary>
        /// 用户信息数据操作类
        /// </summary>
        /// <returns></returns>
        public static IUserInfoDal CreateUserInfoDal() {
            string fullClassName = NameSpace + ".UserInfoDal";
            return CreateInstance(fullClassName) as IUserInfoDal;
        }

        /// <summary>
        /// 权限信息数据操作类
        /// </summary>
        /// <returns></returns>
        public static IActionInfoDal CreateActionInfoDal() {

            string fullClassName = NameSpace + ".ActionInfoDal";
            return CreateInstance(fullClassName) as IActionInfoDal;

        }

        /// <summary>
        /// 部门信息数据操作类
        /// </summary>
        /// <returns></returns>
        public static IDepartmentDal CreateDepartmentDal() {

            string fullClassName = NameSpace + ".DepartmentDal";
            return CreateInstance(fullClassName) as IDepartmentDal;

        }

        /// <summary>
        /// 用户-权限信息数据操作类
        /// </summary>
        /// <returns></returns>
        public static IR_UserInfo_ActionInfoDal CreateR_UserInfo_ActionInfoDal() {

            string fullClassName = NameSpace + ".R_UserInfo_ActionInfoDal";
            return CreateInstance(fullClassName) as IR_UserInfo_ActionInfoDal;

        }

        /// <summary>
        /// 角色信息数据操作类
        /// </summary>
        /// <returns></returns>
        public static IRoleInfoDal CreateRoleInfoDal() {

            string fullClassName = NameSpace + ".RoleInfoDal";
            return CreateInstance(fullClassName) as IRoleInfoDal;

        }

        /// <summary>
        /// 创建实例
        /// </summary>
        /// <param name="fullClassName"></param>
        /// <returns></returns>
        private static object CreateInstance(string fullClassName) {
            var assmbly = Assembly.Load(AssemblyPath);
            return assmbly.CreateInstance(fullClassName);
        }
    }
}
