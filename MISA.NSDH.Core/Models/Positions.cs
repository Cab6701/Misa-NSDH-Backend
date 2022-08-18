using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.NSDH.Core.Models
{
    public class Positions:BaseEntity
    {
        #region Constructor
        public Positions()
        {
            this.PositionID = Guid.NewGuid();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Mã vị trí
        /// </summary>
        public Guid PositionID { get; set; }
        /// <summary>
        /// Tên vị trí
        /// </summary>
        public string PositionName { get; set; }    
        #endregion
    }
}
