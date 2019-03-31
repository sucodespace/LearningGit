using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL;

namespace HotelWebProject.Areas.WebHotelManage.Controllers
{
    [Authorize]
    public class NewsController : Controller
    {
        /// <summary>
        /// 新闻发布页面展示
        /// </summary>
        /// <returns></returns>
        public ActionResult NewsPublish()
        {
            //获取新闻分类下拉列表集合,为后面填充下拉列表使用
            List<NewsCategory> categoryList = new NewsManager().GetAllCategory();
            SelectList list = new SelectList(categoryList,"CategoryId","CategoryName");
            ViewBag.dlist = list;
            return View();
        }
        /// <summary>
        /// 发布新闻
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult PublishNews(News news)
        {
            int result = new NewsManager().PublishNews(news);
            if (result > 0)
            {
                return Content("<script>alert('新闻发布成功!');location.href='" + Url.Action("NewsPublish") + "'</script>");
            }
            else
            {
                return Content("<script>alert('新闻发布失败!');location.href='" + Url.Action("NewsPublish") + "'</script>");
            }
        }
    }
}