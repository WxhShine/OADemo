using OA.DALFactory;
using OA.IDAL;
using OA.Model;
using OA.Model.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OA.BLL {
    public abstract class BaseService<T> where T: IdEntity, new () {
        /// <summary>
        /// 当前的数据会话层
        /// </summary>
        public IDBSession CurrentDBSession {
            get { return DBSessionFactory.CreateDBSession(); }
        }
        /// <summary>
        /// 当前数据访问层
        /// </summary>
        public IBaseDal<T> CurrentDal { get; set; }

        /// <summary>
        /// 设置当前数据访问层
        /// </summary>
        public abstract void SetCurrentDal();

        public BaseService() {
            SetCurrentDal();//子类实现抽象方法。
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda) {
            return  CurrentDal.LoadEntities(whereLambda);
        }

        /// <summary>
        /// 分页加载数据
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">一页的显示个数</param>
        /// <param name="totalCount">总数</param>
        /// <param name="whereLambda">条件过滤的lambda表达式</param>
        /// <param name="orderbyLambda">排序的lambda表达式</param>
        /// <param name="isAsc">是否升序</param>
        /// <returns></returns>
        public IQueryable<T> LoadPageEntities<S> (int pageIndex,int pageSize, out int totalCount,Expression<Func<T,bool>> whereLambda, Expression<Func<T,S>> orderbyLambda,bool isAsc) {
            return CurrentDal.LoadPageEntities(pageIndex, pageSize, out totalCount, whereLambda, orderbyLambda, isAsc);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleteEntity(T entity) {
            CurrentDal.DeleteEntity(entity);
            return CurrentDBSession.SaveChanges();
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool BatchDeleteEntities(List<int> ids) {
            var entitis = LoadEntities(x => ids.Contains(x.Id));
            foreach(var item in entitis) {
                CurrentDal.DeleteEntity(item);
            }
            return CurrentDBSession.SaveChanges();
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool EditEntity(T entity) {
            CurrentDal.EditEntity(entity);
            return CurrentDBSession.SaveChanges();
        }
        
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T AddEntity(T entity) {
            CurrentDal.AddEntity(entity);
            CurrentDBSession.SaveChanges();
            return entity;
        }
    }
}
