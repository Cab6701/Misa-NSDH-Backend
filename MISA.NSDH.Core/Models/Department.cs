using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.NSDH.Core.Models
{
    public class Department:BaseEntity
    {
        #region Constructor
        public Department()
        {
            this.DepartmentID = Guid.NewGuid();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Mã phòng ban
        /// </summary>
        public Guid DepartmentID { get; set; }
        /// <summary>
        /// Tên phòng ban
        /// </summary>
        public string DepartmentName { get; set; }
      
        #endregion
    }
}
