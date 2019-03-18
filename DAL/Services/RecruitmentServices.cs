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
    /// 招聘信息数据库访问类
    /// </summary>
    public class RecruitmentServices
    {
        /// <summary>
        /// 发布招聘信息
        /// </summary>
        /// <param name="recruitment"></param>
        /// <returns></returns>
        public int AddRecruitment(Recruitment recruitment)
        {
            using (HotelDBEntities db=new HotelDBEntities())
            {
                db.Recruitment.Add(recruitment);
                return db.SaveChanges();
            }
        }

        /// <summary>
        /// 修改招聘信息
        /// </summary>
        /// <param name="recruitmnet"></param>
        /// <returns></returns>
        public int ModifyRecruitment(Recruitment recruitmnet)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                db.Recruitment.Attach(recruitmnet);
                db.Entry<Recruitment>(recruitmnet).State = EntityState.Modified;
                return db.SaveChanges();
            }
        }

        /// <summary>
        /// 删除招聘信息
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public int DeleteRecruitment(int postId)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                Recruitment recruitment = new Recruitment { PostId = postId };
                db.Recruitment.Attach(recruitment);
                db.Recruitment.Remove(recruitment);
                return db.SaveChanges();
            }
        }

        /// <summary>
        /// 查询所有的职位列表信息
        /// </summary>
        /// <returns></returns>
        public List<Recruitment> GetAllRecruitment()
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                return (from r in db.Recruitment select r).ToList();
            }
        }

        /// <summary>
        /// 根据发布的编号查询详细职位信息
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public Recruitment GetPostById(int postId)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                return (from r in db.Recruitment where r.PostId == postId select r).FirstOrDefault();
            }
        }
    }
}
