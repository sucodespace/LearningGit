using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.SqlClient;

namespace DAL
{
    public class NewsServices
    {
        //创建一个通用类
        private EFDBHelper helper = new EFDBHelper(new HotelDBEntities());

        /// <summary>
        /// 发布新闻:添加
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        public int PublishNews(News news)
        {
            return helper.Add<News>(news);
        }
        //使用存储过程
        //public int PublishNews(News news)
        //{
        //    SqlParameter[] param = new SqlParameter[]
        //    {
        //        new SqlParameter("@NewsTitle",news.NewsTitle),
        //        new SqlParameter("@NewsContents",news.NewsContents),
        //        new SqlParameter("@CategoryId",news.CategoryId)
        //    };
        //    using (HotelDBEntities db = new HotelDBEntities())
        //    {
        //        return db.Database.ExecuteSqlCommand("excecute usp_AddNews @NewsTitle,@NewsContents,@CategoryId", param);
        //    }
        //}

        /// <summary>
        /// 修改新闻
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        public int ModifyNews(News news)
        {
            return helper.Modity<News>(news);
        }
        
        /// <summary>
        /// 删除新闻
        /// </summary>
        /// <param name="newsId"></param>
        /// <returns></returns>
        public int DeleteNews(int newsId)
        {
            News news = new News {NewsId=newsId };
            return helper.Delete<News>(news);
        }

        /// <summary>
        /// 查询指定前几条新闻
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<News> GetNews(int count)
        {
            using (HotelDBEntities db=new HotelDBEntities())
            {
                //return (from n in db.News orderby n.PublishTime descending select n).Take(count).ToList();
                var newsList= (from n in db.News orderby n.PublishTime descending select new
                {
                    n.NewsId,
                    n.NewsTitle,
                    n.PublishTime,
                    n.CategoryId,
                    n.NewsContents,
                    n.NewsCategory.CategoryName
                }).Take(count);
                List<News> list = new List<News>();
                foreach (var item in newsList)
                {
                    list.Add(new News{
                        NewsId=item.NewsId,
                        NewsTitle=item.NewsTitle,
                        PublishTime=item.PublishTime,
                        CategoryId=item.CategoryId,
                        NewsContents=item.NewsContents,
                        NewsCategory=new NewsCategory { CategoryName = item.CategoryName }                        
                    });
                }
                return list;
            }
            
        }

        /// <summary>
        /// 根据新闻Id查询新闻详细信息
        /// </summary>
        /// <param name="newsId"></param>
        /// <returns></returns>
        public News GetNewsById(int newsId)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                return (from n in db.News where n.NewsId==newsId select n).FirstOrDefault();
            }
        }

        /// <summary>
        /// 获取所有的新闻分类
        /// </summary>
        /// <returns></returns>
        public List<NewsCategory> GetAllCategory()
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
               return (from c in db.NewsCategory select c).ToList();
            }
        }

        /// <summary>
        /// 根据新闻分类Id查询分类名称
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public string GetCategoryName(int categoryId)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                return (from c in db.NewsCategory where c.CategoryId == categoryId select c.CategoryName).FirstOrDefault();
            }
        }
    }
}
