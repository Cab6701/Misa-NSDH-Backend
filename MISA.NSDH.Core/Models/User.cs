using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.NSDH.Core.Models
{
    public class User:BaseEntity
    {
        #region Contructor
        public User()
        {
            this.UserID = Guid.NewGuid();
            this.DepartmentID = Guid.NewGuid();
            this.PositionID = Guid.NewGuid();
        }
        public User(string userCode, string userName, Guid departmentID, Guid positionID, string email, int status)
        {
            UserID = Guid.NewGuid();
            UserCode = userCode;
            UserName = userName;
            DepartmentID = departmentID;
            PositionID = positionID;
            Email = email;
            Status = status;
        }
        #endregion
        #region Properties
        /// <summary>
        /// Khoá chính
        /// </summary>
        public Guid UserID { get; set; }
        /// <summary>
        /// Mã người dùng
        /// </summary>
        public string UserCode { get; set; }
        /// <summary>
        /// Tên người dùng
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Mã phòng ban
        /// </summary>
        public Guid DepartmentID { get; set; }
        /// <summary>
        /// Mã vị trí
        /// </summary>
        public Guid PositionID { get; set; }
        /// <summary>
        /// Tên phòng ban
        /// </summary>
        public string? DepartmentName { get; set; }
        /// <summary>
        /// Tên vị trí
        /// </summary>
        public string? PositionName { get; set; }
        /// <summary>
        /// Tên vai trò
        /// </summary>
        public string? RoleName { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Trạng thái
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// Mảng mã vai trò
        /// </summary>
        public List<Guid> RoleID { get; set; }

        #endregion
    }
}
