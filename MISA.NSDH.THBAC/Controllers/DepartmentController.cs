using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.NSDH.Core.Interfaces.Repository;
using MISA.NSDH.Core.Interfaces.Services;
using MISA.NSDH.Core.Models;

namespace MISA.NSDH.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DepartmentController : BaseController<Department>
    {
        IDepartmentService _service;
        IDepartmentRepository _repository;
        public DepartmentController(IDepartmentService service, IDepartmentRepository repository) : base(service, repository)
        {
            _service = service;
            _repository = repository;
        }
    }
}
