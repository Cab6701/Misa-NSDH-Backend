using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.NSDH.Core.Exceptions;
using MISA.NSDH.Core.Interfaces.Repository;
using MISA.NSDH.Core.Interfaces.Services;

namespace MISA.NSDH.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<MISAEntity> : ControllerBase
    {
        #region Constructor
        IBaseService<MISAEntity> _service;
        IBaseRepository<MISAEntity> _repository;

        public BaseController(IBaseService<MISAEntity> service, IBaseRepository<MISAEntity> repository)
        {
            _service = service;
            _repository = repository;
        }
        #endregion
        #region HttpGet
        /// <summary>
        /// Author: THBAC (2/8/2022)
        /// Lấy thông tin dữ liệu người dùng
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual IActionResult Get()
        {
            try
            {
                var users = _repository.Get();
                return Ok(users);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {

            try
            {
                var users = _repository.Get(id);
                return Ok(users);
            }
            catch (Exception ex)
            {

                return HandleException(ex);
            }
        }
        #endregion
        #region HttpPost
        [HttpPost]
        public IActionResult Post(MISAEntity user)
        {
            try
            {
                var res = _service.InsertService(user);
                return StatusCode(201, res);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        [HttpDelete]
        public IActionResult Delete(Guid userID)
        {
            try
            {
                var res = _repository.Delete(userID);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }



        protected IActionResult HandleException(Exception ex)
        {
            var res = new
            {
                devMsg = ex.Message,
                data = ex.Data,
                userMsg = "Có lỗi xảy ra vui lòng liên hệ Misa để được trợ giúp"
            };

            if (ex is MISAValidateException)
            {
                return StatusCode(400, res);
            }
            else
            {
                return StatusCode(500, res);
            }
        }
        #endregion
    }
}
