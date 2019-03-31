using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;

namespace BLL
{
    public class DishesManager
    {
        DishesSerivces dishesServices = new DishesSerivces();

        /// <summary>
        /// 发布菜品
        /// </summary>
        /// <param name="dishes"></param>
        /// <returns></returns>
        public int AddDishes(Dishes dishes)
        {
            return dishesServices.AddDishes(dishes);
        }

        /// <summary>
        /// 修改菜品
        /// </summary>
        /// <param name="dishes"></param>
        /// <returns></returns>
        public int ModifyDishes(Dishes dishes)
        {
            return dishesServices.ModifyDishes(dishes);
        }

        public int DeleteDishes(int dishesId)
        {
            return dishesServices.DeleteDishes(dishesId);
        }

        /// <summary>
        /// 获取菜品列表(根据分类编号)
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public List<Dishes> GetAllDishes(int categoryId = 0)
        {
            return dishesServices.GetAllDishes(categoryId);
        }

        /// <summary>
        /// 获取所有菜品分类(下拉框填充使用)
        /// </summary>
        /// <returns></returns>
        public List<DishesCategory> GetAllDishesCategory()
        {
            return dishesServices.GetAllDishesCategory();
        }

        /// <summary>
        /// 根据菜品分类id查询分类名称
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public string GetCategoryName(int categoryId)
        {
            return dishesServices.GetCategoryName(categoryId);
        }

        public Dishes GetDishesById(int dishesId)
        {
            return dishesServices.GetDishesById(dishesId);
        }
    }
}
