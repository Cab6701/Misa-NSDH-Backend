using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.NSDH.Core.Interfaces.Repository;
using MISA.NSDH.Core.Interfaces.Services;
using MISA.NSDH.Core.Models;

namespace MISA.NSDH.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserRoleController : BaseController<User_Role>
    {
        IUserRoleService _service;
        IUserRoleRepository _repository;
        public UserRoleController(IUserRoleService service, IUserRoleRepository repository) : base(service, repository)
        {
            _service = service;
            _repository = repository;
        }

        /// <summary>
        /// Author: THBAC (15/8/2022)
        /// Hàm update thông tin vai trò người dùng
        /// </summary>
        /// <param name="urole"></param>
        /// <returns></returns>
        [HttpPut("UpdateUserRole")]
        public IActionResult UpdateUserRole(IEnumerable<User_Role> urole)
        {
            try
            {
                var res = _service.UpdateService(urole);
                return Ok(res);
            }
            catch (Exception ex)
            {

                return HandleException(ex);
            }
        }

        /// <summary>
        /// Author: THBAC (15/8/2022)
        /// Hàm xoá vai trò của người dùng
        /// </summary>
        /// <param name="id1">roleID</param>
        /// <param name="id2">userID</param>
        /// <returns></returns>
        [HttpDelete("{id1}/{id2}")]
        public IActionResult Delete(Guid id1, Guid id2)
        {
            try
            {
                var res = _repository.Delete(id1, id2);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}
