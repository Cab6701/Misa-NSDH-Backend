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
    public class UserRepository:BaseRepository<User>, IUserRepository
    {
        public bool CheckUserCodeExits(string userCode)
        {
            using (MySqlConnection = new MySqlConnection(ConnectionString))
            {
                var sql = "SELECT UserCode FROM User WHERE UserCode = @UserCode";
                var parametes = new DynamicParameters();
                parametes.Add("@UserCode", userCode);
                var res = MySqlConnection.QueryFirstOrDefault(sql: sql, param: parametes);
                if (res == null)
                {
                    return false;
                }
                return true;
            }
        }

        /// <summary>
        /// Author : THBAC (11/8/2022)
        /// Lấy toàn bộ thông tin người dùng
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> Get()
        {
            using (MySqlConnection = new MySqlConnection(ConnectionString))
            {
                var sql = $"Proc_GetAllUser";
                var users = MySqlConnection.Query<User>(sql: sql, commandType: System.Data.CommandType.StoredProcedure);
                return users;
            }
        }

        public object GetPaging(int pageIndex, int pageSize, string? fillter)
        {
            using (MySqlConnection = new MySqlConnection(ConnectionString))
            {
                var sql = $"Proc_GetUserPaging";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@b_Filter", fillter);
                parameters.Add("@b_PageIndex", pageIndex);
                parameters.Add("@b_PageSize", pageSize);
                parameters.Add("@b_TotalRecord", direction: System.Data.ParameterDirection.Output);
                parameters.Add("@b_RecordStart", direction: System.Data.ParameterDirection.Output);
                parameters.Add("@b_RecordEnd", direction: System.Data.ParameterDirection.Output);

                var users = MySqlConnection.Query<User>(sql, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                int totalRecord = parameters.Get<int>("@b_TotalRecord");
                int recordStart = parameters.Get<int>("@b_RecordStart");
                int recordEnd = parameters.Get<int>("@b_RecordEnd");
                return new
                {
                    TotalRecord = totalRecord,
                    RecordStart = recordStart,
                    RecordEnd = recordEnd,
                    Data = users,
                };
            }
        }
    }
}
