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
    public class PositionsService : BaseService<Positions>, IPositionsService
    {
        IPositionsRepository _repository;
        public PositionsService(IPositionsRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
