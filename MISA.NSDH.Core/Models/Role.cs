using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.NSDH.Core.Models
{
    public class Role:BaseEntity
    {
        #region Constructor
        public Role()
        {
            this.RoleID= Guid.NewGuid();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Mã vai trò
        /// </summary>
        public Guid RoleID { get; set; }
        /// <summary>
        /// Tên vai trò
        /// </summary>
        public string RoleName { get; set; }
        #endregion
    }
}
