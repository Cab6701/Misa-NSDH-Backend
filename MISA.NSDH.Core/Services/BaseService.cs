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

        public int UpdateService(MISAEntity user)
        {
            throw new NotImplementedException();
        }

        protected virtual MISAEntity BeforeInsert(MISAEntity entity)
        {
            return entity;
        }
        protected virtual int DoInsert(MISAEntity entity)
        {
            var res = _repository.Insert(entity);
            return res;

        }
        protected virtual MISAEntity AfterInsert(MISAEntity entity)
        {
            return entity;
        }

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
        /// Thực hiện validate dữ liệu khi thêm mới
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>true - hợp lệ; false - không hợp lệ</returns>
        protected virtual bool Validate(MISAEntity entity)
        {
            return true;
        }
        /// <summary>
        /// Thực hiện validate dữ liệu khi update
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected virtual bool ValidateUpdate(MISAEntity entity)
        {
            return true;
        }

        
    }
}
