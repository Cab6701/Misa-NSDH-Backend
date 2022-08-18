using Dapper;
using MISA.NSDH.Core.Interfaces.Repository;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.NSDH.Infrastructure.Repository
{
    public class BaseRepository<MISAEntity> : IBaseRepository<MISAEntity>
    {
        protected string ConnectionString;
        protected MySqlConnection MySqlConnection;
        protected string TableName;

        public BaseRepository()
        {
            ConnectionString = "Host=localhost; " +
                    "Port=3306; " +
                    "Database = misa.nsdh.thbac; " +
                    "User Id = trinhbac; " +
                    "Password=123456";
            TableName = typeof(MISAEntity).Name;
        }
        /// <summary>
        /// Athor: THBAC (3/8/2022)
        /// Hàm lấy dư liệu thông tin người dùng
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<MISAEntity> Get()
        {
            using (MySqlConnection = new MySqlConnection(ConnectionString))
            {
                var sql = $"Proc_Get{TableName}";
                var users = MySqlConnection.Query<MISAEntity>(sql: sql, commandType: System.Data.CommandType.StoredProcedure);
                return users;
            }
        }

        public MISAEntity Get(Guid id)
        {
            using (MySqlConnection = new MySqlConnection(ConnectionString))
            {
                var sql = $"SELECT * FROM {TableName} WHERE {TableName}ID = @{TableName}ID";
                var parametes = new DynamicParameters();
                parametes.Add($"@{TableName}ID", id);
                var user = MySqlConnection.QueryFirstOrDefault<MISAEntity>(sql: sql, param: parametes);
                return user;
            }
        }

        public int Insert(MISAEntity entity)
        {
            using (MySqlConnection = new MySqlConnection(ConnectionString))
            {
                var sql = $"Proc_Insert{TableName}";
                var res = MySqlConnection.Execute(sql: sql, param: entity, commandType: System.Data.CommandType.StoredProcedure);
                return res;
            }
        }

        public int Delete(Guid entityId)
        {
            using (MySqlConnection = new MySqlConnection(ConnectionString))
            {
                var sql = $"DELETE FROM {TableName} WHERE {TableName}ID = @{TableName}ID";
                var parametes = new DynamicParameters();
                parametes.Add($"@{TableName}ID", entityId);
                var res = MySqlConnection.Execute(sql: sql, param: parametes);
                return res;
            }
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public virtual int Delete(Guid id1, Guid id2)
        {
            throw new NotImplementedException();
        }
    }
}
