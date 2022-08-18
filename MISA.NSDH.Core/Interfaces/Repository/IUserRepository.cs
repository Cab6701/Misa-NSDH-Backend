using MISA.NSDH.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.NSDH.Core.Interfaces.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        bool CheckUserCodeExits(string userCode);
        Object GetPaging(int pageIndex, int pageSize, string? fillter);
    }
}
