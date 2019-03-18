using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.Entity;

namespace DAL
{
    /// <summary>
    /// 菜品操作数据库访问类
    /// </summary>
    public class DishesSerivces
    {
        /// <summary>
        /// 发布菜品
        /// </summary>
        /// <param name="dishes"></param>
        /// <returns></returns>
        public int AddDishes(Dishes dishes)
        {
            using (HotelDBEntities db=new HotelDBEntities())
            {
                db.Dishes.Add(dishes);
                return db.SaveChanges();
            }
        }

        /// <summary>
        /// 修改菜品
        /// </summary>
        /// <param name="dishes"></param>
        /// <returns></returns>
        public int ModifyDishes(Dishes dishes)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                db.Entry<Dishes>(dishes).State = EntityState.Modified;
                return db.SaveChanges();
            }
        }

        public int DeleteDishes(int dishesId)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                Dishes dishes = new Dishes { DishesId=dishesId};
                db.Dishes.Attach(dishes);
                db.Dishes.Remove(dishes);
                return db.SaveChanges();
            }
        }
        /// <summary>
        /// 获取菜品列表(根据分类编号)
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public List<Dishes> GetAllDishes(int categoryId=0)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                if (categoryId == 0)
                    return (from d in db.Dishes select d).ToList();
                else
                    return (from d in db.Dishes where d.CategoryId == categoryId select d).ToList();
            }
        }
        /// <summary>
        /// 获取所有菜品分类(下拉框填充使用)
        /// </summary>
        /// <returns></returns>
        public List<DishesCategory> GetAllDishesCategory()
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                return (from c in db.DishesCategory select c).ToList();
            }
        }
        /// <summary>
        /// 根据菜品分类id查询分类名称
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public string GetCategoryName(int categoryId)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                return (from c in db.DishesCategory where c.CategoryId == categoryId select c.CategoryName).FirstOrDefault();
            }
        }

        public Dishes GetDishesById(int dishesId)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                return (from d in db.Dishes where d.DishesId == dishesId select d).FirstOrDefault();
            }
        }
    }
}
