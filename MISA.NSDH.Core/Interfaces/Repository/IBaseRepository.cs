using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.NSDH.Core.Interfaces.Repository
{
    public interface IBaseRepository<MISAEntity>
    {
        IEnumerable<MISAEntity> Get();
        MISAEntity Get(Guid id);
        int Insert(MISAEntity user);
        int Delete(Guid userID);
        int Delete(Guid id1, Guid id2);
        MySqlConnection GetConnection();
    }
}
