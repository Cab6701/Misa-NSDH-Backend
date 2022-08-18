using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.NSDH.Core.Models
{
    public class User_Role:BaseEntity
    {
        #region Constructor
        public User_Role()
        {
            RoleID = Guid.NewGuid();
            UserID = Guid.NewGuid();
        }
        public User_Role(Guid roleId, Guid userId)
        {
            UserID = userId;
            RoleID = roleId;
        }
        #endregion
        #region Properties
        /// <summary>
        /// Mã vai trò
        /// </summary>
        public Guid RoleID { get; set; }
        /// <summary>
        /// Mã người dùng
        /// </summary>
        public Guid UserID { get; set; }

        /// <summary>
        /// trạng thái để thực hiện cập nhật
        /// 1 - thêm
        /// 2 - xoá
        /// 3 - không làm gì
        /// </summary>
        public int status { get; set; }
        #endregion
    }
}
