using MISA.NSDH.Core.Exceptions;
using MISA.NSDH.Core.Interfaces.Repository;
using MISA.NSDH.Core.Interfaces.Services;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.NSDH.Core.Services
{
    public class BaseService<MISAEntity> : IBaseService<MISAEntity>
    {
        IBaseRepository<MISAEntity> _repository;
        protected List<string> ErrorValidateMsgs;
        protected bool IsValid = true;
        public BaseService(IBaseRepository<MISAEntity> repository)
        {
            _repository = repository;
            ErrorValidateMsgs = new List<string>();
        }
        /// <summary>
        /// Author: THBAC (15/8/2022)
        /// Thực hiện chức năng thêm mới
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="MISAValidateException"></exception>
        public virtual int InsertService(MISAEntity user)
        {
            //Validate dữ liệu:
            var isValid = Validate(user);
            //Thực hiện thêm mới:
            if (isValid == true)
            {
                var res = _repository.Insert(user);
                return res;
            }
            else
            {
                throw new MISAValidateException(ErrorValidateMsgs);
            }
        }

        /// <summary>
        /// Author: THBAC (15/8/2022)
        /// Chức năng cập nhật vai trò
        /// </summary>
        /// <param name="urole"></param>
        /// <returns></returns>
        public int UpdateService(IEnumerable<MISAEntity> urole)
        {
            var res = this.UpdateUserRole(urole);
            return res;
        }
        /// <summary>
        /// Author: THBAC (15/8/2022)
        /// Chức năng cập nhật vai trò
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected virtual int UpdateUserRole(IEnumerable<MISAEntity> entity)
        {
            return 0;
        }

        /// <summary>
        /// Author: THBAC (15/8/2022)
        /// Hàm trước khi thêm
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected virtual MISAEntity BeforeInsert(MISAEntity entity)
        {
            return entity;
        }
        /// <summary>
        /// Author: THBAC (15/8/2022)
        /// Chức năng thêm
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected virtual int DoInsert(MISAEntity entity)
        {
            var res = _repository.Insert(entity);
            return res;

        }
        /// <summary>
        /// Author: THBAC (15/8/2022)
        /// Chức năng sau khi thêm
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected virtual MISAEntity AfterInsert(MISAEntity entity)
        {
            return entity;
        }
        /// <summary>
        /// Author: THBAC (15/8/2022)
        /// Chức năng thêm hàng loạt
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="MISAValidateException"></exception>
        public virtual int InsertAllService(IEnumerable<MISAEntity> entity)
        {
            MySqlTransaction transaction = null;
            var connection = _repository.GetConnection();
            using (connection)
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                try
                {
                    foreach (var item in entity)
                    {
                        var res = this.InsertService(item);
                        if (res != 1)
                            throw new MISAValidateException(ErrorValidateMsgs);
                    }
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw new MISAValidateException(ErrorValidateMsgs); ;
                }
                finally
                {
                    transaction.Dispose();
                }
            }
            // nếu lỗi roll back
            return 1;

        }


        /// <summary>
        /// Author: THBAC (15/8/2022)
        /// Thực hiện validate dữ liệu khi thêm mới
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>true - hợp lệ; false - không hợp lệ</returns>
        protected virtual bool Validate(MISAEntity entity)
        {
            return true;
        }
        /// <summary>
        /// Author: THBAC (15/8/2022)
        /// Thực hiện validate dữ liệu khi update
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected virtual bool ValidateUpdate(MISAEntity entity)
        {
            return true;
        }
        /// <summary>
        /// Author: THBAC (15/8/2022)
        /// Chức năng cập nhật
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="MISAValidateException"></exception>
        public int UpdateService(MISAEntity user)
        {
            //Validate dữ liệu:
            var isValid = Validate(user);
            //Thực hiện thêm mới:
            if (isValid == true)
            {
                var res = _repository.Update(user);
                return res;
            }
            else
            {
                throw new MISAValidateException(ErrorValidateMsgs);
            }
        }
    }
}
