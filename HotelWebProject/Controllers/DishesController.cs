using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelWebProject.Controllers
{
    public class DishesController : Controller
    {
        // GET: Dishes
        public ActionResult Index()
        {
            return View();
        }
    }
}