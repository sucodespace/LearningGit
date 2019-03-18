using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using Models;

namespace Test
{
    class Program
    {
       // static NewsManager manager = new NewsManager();
        static void Main(string[] args)
        {
            NewsManager manager = new NewsManager();
            News news = new News { NewsTitle = "MVC+EF项目正式开讲!", NewsContents = "常老师详细讲解", CategoryId = 1 };
            Console.WriteLine(manager.PublishNews(news));
            Console.ReadLine();
        }
    }
}
