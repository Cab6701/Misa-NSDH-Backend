using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.NSDH.Core.Interfaces.Repository;
using MISA.NSDH.Core.Interfaces.Services;
using MISA.NSDH.Core.Models;

namespace MISA.NSDH.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RoleController : BaseController<Role>
    {
        IRoleService _service;
        IRoleRepository _repository;
        public RoleController(IRoleService service, IRoleRepository repository ):base(service,repository)
        {
            _service = service;
            _repository = repository;
        }
    }
}
