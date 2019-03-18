using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;

namespace BLL
{
    public  class RecruitmentManager
    {
        private RecruitmentServices recruitmentService = new RecruitmentServices();

        /// <summary>
        /// 发布招聘信息
        /// </summary>
        /// <param name="recruitment"></param>
        /// <returns></returns>
        public int AddRecruitment(Recruitment recruitment)
        {
            return recruitmentService.AddRecruitment(recruitment);
        }

        /// <summary>
        /// 修改招聘信息
        /// </summary>
        /// <param name="recruitmnet"></param>
        /// <returns></returns>
        public int ModifyRecruitment(Recruitment recruitmnet)
        {
            return recruitmentService.ModifyRecruitment(recruitmnet);
        }

        /// <summary>
        /// 删除招聘信息
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public int DeleteRecruitment(int postId)
        {
            return recruitmentService.DeleteRecruitment(postId);
        }

        /// <summary>
        /// 查询所有的职位列表信息
        /// </summary>
        /// <returns></returns>
        public List<Recruitment> GetAllRecruitment()
        {
            return recruitmentService.GetAllRecruitment();
        }

        /// <summary>
        /// 根据发布的编号查询详细职位信息
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public Recruitment GetPostById(int postId)
        {
            return recruitmentService.GetPostById(postId);
        }

    }
}
