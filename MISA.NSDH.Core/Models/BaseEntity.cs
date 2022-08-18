using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.NSDH.Core.Models
{
    public class BaseEntity
    {
        #region Properties
        /// <summary>
        /// Author: THBAC (3/8/2022)
        /// Ngày tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Author: THBAC (3/8/2022)
        /// Người tạo
        /// </summary>
        public string? CreatedBy { get; set; }

        /// <summary>
        /// Author: THBAC (3/8/2022)
        /// Ngày sửa
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Author: THBAC (3/8/2022)
        /// Người sửa
        /// </summary>
        public string? ModifiedBy { get; set; }
        #endregion
    }
}
