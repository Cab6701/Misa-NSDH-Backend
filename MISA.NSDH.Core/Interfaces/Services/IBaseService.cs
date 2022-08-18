using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.NSDH.Core.Interfaces.Services
{
    public interface IBaseService<MISAEntity>
    {
        int InsertService(MISAEntity user);
        int UpdateService(MISAEntity user);
        int InsertAllService(IEnumerable<MISAEntity> entity);
    }
}
