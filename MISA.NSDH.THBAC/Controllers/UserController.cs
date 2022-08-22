using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.NSDH.Core.Interfaces.Repository;
using MISA.NSDH.Core.Interfaces.Services;
using MISA.NSDH.Core.Models;

namespace MISA.NSDH.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : BaseController<User>
    {
        IUserService _service;
        IUserRepository _repository;
        #region Constructor
        public UserController(IUserService service, IUserRepository repository) : base(service, repository)
        {
            _service = service;
            _repository = repository;
        }

        #endregion

        #region Methods
        /// <summary>
        /// Author: THBAC (15/8/2022)
        /// Hàm phân trang và lọc
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet("filter")]
        public IActionResult GetPaging(int pageIndex, int pageSize, string? filter)
        {
            try
            {
                var res = _repository.GetPaging(pageIndex, pageSize, filter);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        /// <summary>
        /// Author: THBAC (15/8/2022)
        /// Thêm hàng loạt
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>

        [HttpPost("InsertUsers")]
        public IActionResult Insert(List<User> users)
        {
            try
            {
                var res = _service.InsertAllService(users);
                return StatusCode(201, res);
            }
            catch (Exception ex)
            {

                return HandleException(ex);
            }
        }

        /// <summary>
        /// Author: THBAC (15/8/2022)
        /// Hàm lấy Code mới
        /// </summary>
        /// <returns></returns>
        [HttpGet("newUserCode")]
        public IActionResult GetNewEmployeeCode()
        {
            try
            {
                var res = _repository.GetNewUserCode();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
        #endregion
    }
}
