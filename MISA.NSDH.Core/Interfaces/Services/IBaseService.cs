using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.NSDH.Core.Interfaces.Services
{
    public interface IBaseService<MISAEntity>
    {
        /// <summary>
        /// Author: THBAC (15/8/2022)
        /// Thêm người dùng
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int InsertService(MISAEntity user);
        /// <summary>
        /// Author: THBAC (15/8/2022)
        /// Cập nhật người dùng
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int UpdateService(MISAEntity user);
        /// <summary>
        /// Cập nhật vai trò người dùng
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int UpdateService(IEnumerable<MISAEntity> entity);
        /// <summary>
        /// Author: THBAC (15/8/2022)
        /// Thêm hàng loạt người dùng
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int InsertAllService(IEnumerable<MISAEntity> entity);
    }
}
