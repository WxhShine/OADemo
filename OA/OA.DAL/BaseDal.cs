﻿using OA.Model;
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

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleteEntity(T entity) {
            context.Entry(entity).State = EntityState.Deleted;
            return true;//context.SaveChanges() > 0;
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool EditEntity(T entity) {
            context.Entry(entity).State = EntityState.Modified;
            return true;// context.SaveChanges() > 0;
        }

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda) {
            return context.Set<T>().Where(whereLambda);
        }

        /// <summary>
        /// 分页加载
        /// </summary>
        /// <typeparam name="s"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <param name="whereLambda"></param>
        /// <param name="orderLambda"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
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
