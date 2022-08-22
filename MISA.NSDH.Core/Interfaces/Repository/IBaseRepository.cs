using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.NSDH.Core.Interfaces.Repository
{
    public interface IBaseRepository<MISAEntity>
    {
        /// <summary>
        /// Author: THBAC (15/8/2022)
        /// Hàm lấy thông tin người dùng
        /// </summary>
        /// <returns></returns>
        IEnumerable<MISAEntity> Get();
        /// <summary>
        /// Author: THBAC (15/8/2022)
        /// Lấy thông tin người dùng theo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        MISAEntity Get(Guid id);
        /// <summary>
        /// Author: THBAC (15/8/2022)
        /// THêm hàng loạt người dùng
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int Insert(MISAEntity user);
        /// <summary>
        /// Author: THBAC (15/8/2022)
        /// Cập nhật hàng loạt
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int Update(MISAEntity user);
        /// <summary>
        /// Author: THBAC (15/8/2022)
        /// Xoá người dùng
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        int Delete(Guid userID);
        /// <summary>
        /// Author: THBAC (15/8/2022)
        /// Xoá vai trò của người dùng
        /// </summary>
        /// <param name="id1"></param>
        /// <param name="id2"></param>
        /// <returns></returns>
        int Delete(Guid id1, Guid id2);
        /// <summary>
        /// Author: THBAC (15/8/2022)
        /// Hàm tạo kết nối
        /// </summary>
        /// <returns></returns>
        MySqlConnection GetConnection();
    }
}
