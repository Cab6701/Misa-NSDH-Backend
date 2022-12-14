using Dapper;
using MISA.NSDH.Core.Interfaces.Repository;
using MISA.NSDH.Core.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.NSDH.Infrastructure.Repository
{
    public class UserRoleRepository:BaseRepository<User_Role>,IUserRoleRepository
    {
        /// <summary>
        /// Author: THBAC (15/8/2022)
        /// Hàm xoá vai trò người dùng
        /// </summary>
        /// <param name="id1"></param>
        /// <param name="id2"></param>
        /// <returns></returns>
        public override int Delete(Guid id1, Guid id2)
        {
            using (MySqlConnection = new MySqlConnection(ConnectionString))
            {
                var sql = $"DELETE FROM {TableName} WHERE RoleID = @RoleID and UserID = @UserID";
                var parametes = new DynamicParameters();
                parametes.Add($"@RoleID", id2);
                parametes.Add($"@UserID", id1);
                var res = MySqlConnection.Execute(sql: sql, param: parametes);
                return res;
            }
        }
    }
}
