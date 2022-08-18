using MISA.NSDH.Core.Interfaces.Repository;
using MISA.NSDH.Core.Interfaces.Services;
using MISA.NSDH.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.NSDH.Core.Services
{
    public class RoleService:BaseService<Role>,IRoleService
    {
        IRoleRepository _repository;
        public RoleService(IRoleRepository repository):base(repository)
        {
            _repository = repository;
        }
    }
}
