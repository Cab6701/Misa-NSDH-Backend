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
