using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL
{
    public class SuggestionServices
    {
        /// <summary>
        /// 提交投诉
        /// </summary>
        /// <param name="suggestion"></param>
        /// <returns></returns>
        public int SubmitSuggestion(Suggestion suggestion)
        {
            suggestion.SuggestionTime = DateTime.Now;//数据库的默认值不起作用
            using (HotelDBEntities db=new HotelDBEntities())
            {
                db.Suggestion.Add(suggestion);
                return db.SaveChanges();
            }
        }

        /// <summary>
        /// 获取最新的建议
        /// </summary>
        /// <returns></returns>
        public List<Suggestion> GetSuggestion()
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                return (from s in db.Suggestion orderby s.SuggestionTime descending select s).ToList();
            }
        }

        /// <summary>
        /// 受理投诉
        /// </summary>
        /// <param name="suggestionId"></param>
        /// <returns></returns>
        public int HandleSuggestion(int suggestionId)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                Suggestion suggestion = new Suggestion { SuggestionId = suggestionId };
                db.Suggestion.Attach(suggestion);
                suggestion.StatusId = 1;
                return db.SaveChanges();
            }
        }
    }
}
