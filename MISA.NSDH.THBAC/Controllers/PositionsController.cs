using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.NSDH.Core.Interfaces.Repository;
using MISA.NSDH.Core.Interfaces.Services;
using MISA.NSDH.Core.Models;

namespace MISA.NSDH.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PositionsController : BaseController<Positions>
    {
        IPositionsService _service;
        IPositionsRepository _repository;
        public PositionsController(IPositionsService service, IPositionsRepository repository ):base(service,repository)
        {
            _service = service;
            _repository = repository;
        }
    }
}
