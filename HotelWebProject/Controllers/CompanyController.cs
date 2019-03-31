using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL;

namespace HotelWebProject.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Index()
        {
            //显示前5条新闻
            List<News> newsList = new NewsManager().GetNews(5);
            ViewBag.list = newsList;
            return View();
        }

        public ActionResult ComDesc()
        {
            return View();
        }

        /// <summary>
        /// 关于我们
        /// </summary>
        /// <returns></returns>
        public ActionResult AboutUs()
        {
            return View();
        }

        /// <summary>
        /// 餐厅环境
        /// </summary>
        /// <returns></returns>
        public ActionResult Environment()
        {
            return View();
        }

        /// <summary>
        /// 加盟连锁
        /// </summary>
        /// <returns></returns>
        public ActionResult JoinUs()
        {
            return View();
        }
        /// <summary>
        /// 招聘信息
        /// </summary>
        /// <returns></returns>
        public ActionResult RecruitmentList()
        {
            return View();
        }
        //招聘信息详情
        public ActionResult RecruitmentDetail(int postId)
        {
            Recruitment recruitment = new RecruitmentManager().GetPostById(postId);
            return View("RecruitmentDetail", recruitment);
        }

        /// <summary>
        /// 投诉建议展示页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Suggestions()
        {
            return View();
        }
        /// <summary>
        /// 提交投诉建议
        /// </summary>
        /// <param name="suggestion"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public ActionResult SubmitSuggestion(Suggestion suggestion,string vCode)
        {
            if (ModelState.IsValid)
            {
                string code = Session["ValidateCode"].ToString();
                if (code != vCode.ToLower())
                {
                    ModelState.AddModelError("vCode", "验证码不正确,请重新输入!");
                    return View("Suggestions", suggestion);
                }
                else
                {
                    suggestion.StatusId = 0;
                    int result = new SuggestionManager().SubmitSuggestion(suggestion);
                    if (result > 0)
                    {
                        return Content("<script>alert('投诉提交成功!');window.location='" + Url.Content("~/Company/Index") + "'</script>");
                    }
                    else
                    {
                        return Content("<script>alert('投诉提交失败!');window.location='" + Url.Content("~/Company/Suggestions") + "'</script>");
                    }
                }
            }
            else
            {
                return View("Suggestions", suggestion);
            }
        }
    }
}