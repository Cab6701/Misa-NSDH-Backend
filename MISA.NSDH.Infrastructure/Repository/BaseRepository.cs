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
        /// Hàm lấy dữ liệu thông tin 
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
        /// <summary>
        /// Author: THBAC (15/8/2022)
        /// Lấy thông tin theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Author: THBAC (15/8/2022)
        /// Hàm thêm mới thông tin
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Insert(MISAEntity entity)
        {
            using (MySqlConnection = new MySqlConnection(ConnectionString))
            {
                var sql = $"Proc_Insert{TableName}";
                var res = MySqlConnection.Execute(sql: sql, param: entity, commandType: System.Data.CommandType.StoredProcedure);
                return res;
            }
        }
        /// <summary>
        /// Author: THBAC (15/8/2022)
        /// Hàm xoá thông tin
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Author: THBAC (15/8/2022)
        /// 
        /// </summary>
        /// <returns></returns>
        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        /// <summary>
        /// Author: THBAC (15/8/2022)
        /// Hàm xoá vai trò người dùng
        /// </summary>
        /// <param name="id1"></param>
        /// <param name="id2"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>

        public virtual int Delete(Guid id1, Guid id2)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Author: THBAC (15/8/2022)
        /// Hàm cập nhật dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Update(MISAEntity entity)
        {
            using (MySqlConnection = new MySqlConnection(ConnectionString))
            {
                var sql = $"Proc_Update{TableName}";
                var res = MySqlConnection.Execute(sql: sql, param: entity, commandType: System.Data.CommandType.StoredProcedure);
                return res;
            }
        }
    }
}
