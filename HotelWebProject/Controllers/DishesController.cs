using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;
using HotelWebProject.Models;

namespace HotelWebProject.Controllers
{
    public class DishesController : Controller
    {
        // GET: Dishes
        public ActionResult DishesShow()
        {
            List<Dishes> dishesList = new DishesManager().GetAllDishes();
            ViewBag.dishes = dishesList;
            return View();
        }
        /// <summary>
        /// 在线预定入口页面
        /// </summary>
        /// <returns></returns>
        public ActionResult DishesBook()
        {
            return View();
        }
        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <returns></returns>
        public ActionResult ValidateCode()
        {
            CreateValidateCode createCode = new CreateValidateCode();
            string code = createCode.CreateRandomCode(6);
            Session["ValidateCode"] = code.ToLower();
            return File(createCode.CreateValidateGraphic(code),"images/jpeg");
        }
        /// <summary>
        /// 验证码判断
        /// </summary>
        /// <returns></returns>
        public ActionResult CheckValidate()
        {
            string txtValidateCode = Request["value"];
            if (string.Compare(Session["ValidateCode"].ToString(), txtValidateCode, true) != 0)
            {
                return Content("0");//不正确
            }
            else
            {
                return Content("1");//正确
            }
        }

        /// <summary>
        /// 在线预定
        /// </summary>
        /// <param name="dishesBook"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Book(DishesBook dishesBook)
        {
            dishesBook.BookTime = DateTime.Now;
            int result = new DishesBookManager().Book(dishesBook);
            if (result > 0)
                return Content("success");
            else
                return Content("error");
        }

    }
}