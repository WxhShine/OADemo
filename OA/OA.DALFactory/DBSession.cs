using OA.DAL;
using OA.IDAL;
using OA.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.DALFactory {
    /// <summary>
    /// 数据会话层（工厂类）
    /// 通过数据会话层创建各个数据操作类
    /// </summary>
    public partial class DBSession : IDBSession {
        public DbContext Db {
            get { return DBContextFactory.CreateDbContext(); }
            set { }
        }

        /// <summary>
        /// 用户信息
        /// </summary>
        private IUserInfoDal _userInfoDal;
        public IUserInfoDal UserInfoDal {
            get {
                if(_userInfoDal == null) {
                    _userInfoDal = AbstractFactory.CreateUserInfoDal();//通过抽象工厂封装类的实例的创建
                }
                return _userInfoDal;
            }
            set { _userInfoDal = value; }
        }

        /// <summary>
        /// 权限信息
        /// </summary>
        private IActionInfoDal _ActionInfoDal;
        public IActionInfoDal ActionInfoDal {
            get {
                if (_ActionInfoDal == null) {
                    _ActionInfoDal = AbstractFactory.CreateActionInfoDal();
                }
                return _ActionInfoDal;
            }
            set { _ActionInfoDal = value; }
        }

        /// <summary>
        /// 部门信息
        /// </summary>
        private IDepartmentDal _DepartmentDal;
        public IDepartmentDal DepartmentDal {
            get {
                if (_DepartmentDal == null) {
                    _DepartmentDal = AbstractFactory.CreateDepartmentDal();
                }
                return _DepartmentDal;
            }
            set { _DepartmentDal = value; }
        }

        /// <summary>
        /// 用户-权限
        /// </summary>
        private IR_UserInfo_ActionInfoDal _R_UserInfo_ActionInfoDal;
        public IR_UserInfo_ActionInfoDal R_UserInfo_ActionInfoDal {
            get {
                if (_R_UserInfo_ActionInfoDal == null) {
                    _R_UserInfo_ActionInfoDal = AbstractFactory.CreateR_UserInfo_ActionInfoDal();
                }
                return _R_UserInfo_ActionInfoDal;
            }
            set { _R_UserInfo_ActionInfoDal = value; }
        }

        /// <summary>
        /// 角色信息
        /// </summary>
        private IRoleInfoDal _RoleInfoDal;
        public IRoleInfoDal RoleInfoDal {
            get {
                if (_RoleInfoDal == null) {
                    _RoleInfoDal = AbstractFactory.CreateRoleInfoDal();
                }
                return _RoleInfoDal;
            }
            set { _RoleInfoDal = value; }
        }

        /// <summary>
        /// 批量储存对数据库的修改
        /// </summary>
        /// <returns></returns>
        public bool SaveChanges() {
            return Db.SaveChanges() > 0;
        }
    }
}
