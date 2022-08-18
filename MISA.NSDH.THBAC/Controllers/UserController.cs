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
        #endregion
    }
}
