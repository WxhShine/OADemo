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
    /// </summary>
    public class DBSession : IDBSession {
        public DbContext Db {
            get { return DBContextFactory.CreateDbContext(); }
            set { }
        }
        private IUserInfoDal _userInfoDal;
        public IUserInfoDal UserInfoDal {
            get {
                if(_userInfoDal == null) {
                    _userInfoDal = AbstractFactory.CreatUserInfoDal();//通过抽象工厂封装类的实例的创建
                }
                return _userInfoDal;
            }
            set { _userInfoDal = value; }
        }

        public bool SaveChanges() {
            return Db.SaveChanges() > 0;
        }
    }
}
