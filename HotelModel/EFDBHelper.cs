using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace HotelModel
{
    /// <summary>
    /// 基于EF的通用数据通用访问类
    /// </summary>
    public class EFDBHelper
    {
        private DbContext dbContext = null;

        public EFDBHelper(DbContext dbcontext)
        {
            this.dbContext = dbcontext;
        }

        /// <summary>
        /// 新增实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Add<T>(T entity)where T:class 
        {
            //dbContext.Set<T>().Attach(entity);
            //dbContext.Set<T>().Add(entity);
            dbContext.Entry<T>(entity).State = EntityState.Added;
            return dbContext.SaveChanges();
        }

        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Modity<T>(T entity) where T : class
        {
            dbContext.Entry<T>(entity).State = EntityState.Modified;//此种方式设置更新是更新全部字段,不适合部分字段的更新
            return dbContext.SaveChanges();
        }

        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Delete<T>(T entity) where T : class
        {
            //dbContext.Set<T>().Attach(entity);
            //dbContext.Set<T>().Remove(entity);
            dbContext.Entry<T>(entity).State = EntityState.Deleted;
            return dbContext.SaveChanges();
        }
    }
}
