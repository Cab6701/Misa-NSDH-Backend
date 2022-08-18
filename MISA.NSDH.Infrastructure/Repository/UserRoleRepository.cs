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
        public int Delete(Guid id1, Guid id2)
        {
            using (MySqlConnection = new MySqlConnection(ConnectionString))
            {
                var sql = $"DELETE FROM {TableName} WHERE RoleID = @RoleID and UserID = @UserID";
                var parametes = new DynamicParameters();
                parametes.Add($"@RoleID", id1);
                parametes.Add($"@UserID", id2);
                var res = MySqlConnection.Execute(sql: sql, param: parametes);
                return res;
            }
        }
    }
}
