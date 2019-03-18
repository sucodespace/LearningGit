using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL
{
    public class SysAdminsSerivices
    {
        /// <summary>
        /// 管理员登陆
        /// </summary>
        /// <param name="sysAdmin"></param>
        /// <returns></returns>
        public SysAdmins AdminLogin(SysAdmins sysAdmin)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                return (from s in db.SysAdmins where s.LoginId == sysAdmin.LoginId && s.LoginPwd == sysAdmin.LoginPwd select s).FirstOrDefault();
            }
        }
    }
}
