using OA.DALFactory;
using OA.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OA.BLL {
    public abstract class BaseService<T> where T: class, new () {
        public IDBSession CurrentDBSession {
            get { return DBSessionFactory.CreateDBSession(); }
        }
        public IDAL.IBaseDal<T> CurrentDal { get; set; }
        public abstract void SetCurrentDal();
        public BaseService() {
            SetCurrentDal();//子类实现抽象方法。
        }
        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda) {
            return  CurrentDal.LoadEntities(whereLambda);
        }

        public IQueryable<T> LoadPageEntities<S> (int pageIndex,int pageSize, out int totalCount,Expression<Func<T,bool>> whereLambda, Expression<Func<T,S>> orderbyLambda,bool isAsc) {
            return CurrentDal.LoadPageEntities(pageIndex, pageSize, out totalCount, whereLambda, orderbyLambda, isAsc);
        }

        public bool DeleteEntity(T entity) {
            CurrentDal.DeleteEntity(entity);
            return CurrentDBSession.SaveChanges();
        }

        public bool EditEntity(T entity) {
            CurrentDal.EditEntity(entity);
            return CurrentDBSession.SaveChanges();
        }
        
        public T AddEntity(T entity) {
            CurrentDal.AddEntity(entity);
            CurrentDBSession.SaveChanges();
            return entity;
        }
    }
}
