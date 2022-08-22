using MISA.NSDH.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.NSDH.Core.Interfaces.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        /// <summary>
        /// Author: THBAC (15/8/2022)
        /// Check mã người dùng đã tồn tại
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        bool CheckUserCodeExits(string userCode);
        /// <summary>
        /// Author: THBAC (15/8/2022)
        /// Hàm phân trang và lọc
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="fillter"></param>
        /// <returns></returns>
        Object GetPaging(int pageIndex, int pageSize, string? fillter);
        /// <summary>
        /// Author: THBAC (15/8/2022)
        /// Hàm lấy mã mới
        /// </summary>
        /// <returns></returns>
        string GetNewUserCode();
    }
}
