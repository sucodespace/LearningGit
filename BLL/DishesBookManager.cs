using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data;
using DAL;

namespace BLL
{
    /// <summary>
    /// 菜品预定管理
    /// </summary>
    public class DishesBookManager
    {
        DishesBookServices dishesBook = new DishesBookServices();

        /// <summary>
        /// 客户提交订单
        /// </summary>
        /// <param name="dishesbook"></param>
        /// <returns></returns>
        public int Book(DishesBook dishesbook)
        {
            return dishesBook.Book(dishesbook);
        }

        /// <summary>
        /// 根据预定ID修改订单状态(审核通过,撤销,关闭-1)
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="orderStatus"></param>
        /// <returns></returns>
        public int ModifyBook(int bookId, string orderStatus)
        {
            return dishesBook.ModifyBook(bookId, orderStatus);
        }

        /// <summary>
        /// 获取未审核和未关闭的订单
        /// </summary>
        /// <returns></returns>
        public List<DishesBook> GetAllDishesBook()
        {
            return dishesBook.GetAllDishesBook();
        }

    }
}
