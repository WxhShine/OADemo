using OA.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OA.DAL {
    public class BaseDal<T> where T:class,new () {
        DbContext context = DBContextFactory.CreateDbContext();
        public T AddEntity(T entity) {
            context.Set<T>().Add(entity);
            //context.SaveChanges();
            return entity;
        }

        public bool DeleteEntity(T entity) {
            context.Entry(entity).State = EntityState.Deleted;
            return true;//context.SaveChanges() > 0;
        }

        public bool EditEntity(T entity) {
            context.Entry(entity).State = EntityState.Modified;
            return true;// context.SaveChanges() > 0;
        }

        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda) {
            return context.Set<T>().Where(whereLambda);
        }

        public IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderLambda, bool isAsc) {
            var temp = context.Set<T>().Where(whereLambda);
            totalCount = temp.Count();
            if (isAsc) {
                temp = temp.OrderBy(orderLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            } else {
                temp = temp.OrderByDescending(orderLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            return temp;
        }
    }
}
