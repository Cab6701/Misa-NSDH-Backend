using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MISA.NSDH.Core.Exceptions
{
    public class MISAValidateException : Exception
    {
        #region Properties
        /// <summary>
        /// Author: Trịnh Hoài Bắc (20/6/2022 - 11:43)
        /// Tin nhắn lỗi check validate
        /// </summary>
        public string? ValidateErrorMsg { get; set; }
        /// <summary>
        /// Author: Trịnh Hoài Bắc (20/6/2022 - 11:50)
        /// Chuỗi các lỗi
        /// </summary>
        public IDictionary Errors { get; set; }
        /// <summary>
        /// Author: Trịnh Hoài Bắc (20/6/2022 - 11:50)
        /// Hàm ghi đè Message
        /// </summary>
        public override string Message => this.ValidateErrorMsg;
        /// <summary>
        /// Author: Trịnh Hoài Bắc (20/6/2022 - 11:50)
        /// Hàm chứa các thông tin lỗi
        /// </summary>
        public override IDictionary Data => Errors;
        #endregion

        #region Constructor
        /// <summary>
        /// Author: Trịnh Hoài Bắc (20/6/2022 - 11:50)
        /// Hàm tạo
        /// </summary>
        /// <param name="errorMsg"></param>
        public MISAValidateException(string errorMsg)
        {
            ValidateErrorMsg = errorMsg;

        }
        /// <summary>
        /// Author: Trịnh Hoài Bắc (20/6/2022 - 11:50)
        /// Hàm tạo
        /// </summary>
        /// <param name="errorMsg"></param>
        public MISAValidateException(List<string> errorMsg)
        {
            Errors = new Dictionary<string, object>();
            Errors.Add("errors", errorMsg);
        }
        #endregion
    }
}
