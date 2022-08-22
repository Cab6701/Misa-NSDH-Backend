using MISA.NSDH.Core.Exceptions;
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
    public class UserRoleService : BaseService<User_Role>, IUserRoleService
    {
        IUserRoleRepository _repository;
        public UserRoleService(IUserRoleRepository repository) : base(repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Author: THBAC (15/8/2022)
        /// Hàm cập nhật vai trò cho người dùng
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected override int UpdateUserRole(IEnumerable<User_Role> entity)
        {
            foreach (var userRole in entity)
            {
                if (userRole.status == 1)
                {
                    var res = _repository.Insert(userRole);
                }

                if (userRole.status == 2)
                {
                    var res = _repository.Delete(userRole.UserID, userRole.RoleID);
                }
            }
            return 1;
        }
    }
}
