using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL;
using System.Web.Security;

namespace HotelWebProject.Areas.WebHotelManage.Controllers
{
    public class SysAdminController : Controller
    {
        // 登陆页面
        public ActionResult Index()
        {
            return View("AdminLogin");
        }

        public ActionResult AdminLogin(SysAdmins sysAdmin)
        {
            if (ModelState.IsValid)
            {
                sysAdmin = new SysAdminManager().AdminLogin(sysAdmin);
                if (sysAdmin != null)
                {
                    Session["currentAdmin"] = sysAdmin.LoginId;
                    FormsAuthentication.SetAuthCookie(sysAdmin.LoginName, true);//签发身份票据
                    return View("AdminMain");
                }
                else
                {
                    return Content("<script>alert('用户名或密码错误!');location.href='" + Url.Action("Index") + "'</script>");
                }
            }
            else
            {
                return View("AdminLogin");
            }
        }
        /// <summary>
        /// 后台欢迎页面
        /// </summary>
        /// <returns></returns>
        public ActionResult AdminMain()
        {
            return View();
        }
        /// <summary>
        /// 退出系统
        /// </summary>
        /// <returns></returns>
        public ActionResult ExitSys()
        {
            Session["currentAdmin"] = null;
            Session.Abandon();
            FormsAuthentication.SignOut();
            return View("AdminLogin");
        }
    }
}