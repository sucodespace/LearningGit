using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;

namespace BLL
{
    public class SysAdminManager
    {
        private SysAdminsSerivices sysAdminService = new SysAdminsSerivices();

        /// <summary>
        /// 管理员登陆
        /// </summary>
        /// <param name="sysAdmin"></param>
        /// <returns></returns>
        public SysAdmins AdminLogin(SysAdmins sysAdmin)
        {
            return sysAdminService.AdminLogin(sysAdmin);
        }
    }
}
