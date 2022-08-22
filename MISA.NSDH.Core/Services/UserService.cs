using MISA.NSDH.Core.Exceptions;
using MISA.NSDH.Core.Interfaces.Repository;
using MISA.NSDH.Core.Interfaces.Services;
using MISA.NSDH.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MISA.NSDH.Core.Services
{
   
    public class UserService : BaseService<User>, IUserService
    {
        IUserRepository _repository;
        IUserRoleRepository _roleRepository;
        public UserService(IUserRepository repository, IUserRoleRepository roleRepository) :base(repository)
        {
            _repository = repository;
            _roleRepository = roleRepository;
        }
        /// <summary>
        /// Author: THBAC (15/8/2022)
        /// Thêm mới hàng loạt
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="MISAValidateException"></exception>
        public override int InsertService(User entity)
        {
            //Validate dữ liệu:
            var isValid = Validate(entity);
            //Thực hiện thêm mới:
            if (isValid == true)
            {
                User user = new User(entity.UserCode, entity.UserName, entity.DepartmentID, entity.PositionID, entity.Email, entity.Status);
                var res = _repository.Insert(user);
                var list = new List<int>();
                List<Guid> roleIDs = entity.RoleID;
                foreach (var item in roleIDs)
                {
                    User_Role userRole = new User_Role (item, user.UserID);
                    var response = _roleRepository.Insert(userRole);
                    list.Add(response);
                }
                foreach (var item in list)
                {
                    if (item == 0)
                    {
                        res = 0;
                        break;
                    }

                }
                return res;
            }
            else
            {
                throw new MISAValidateException(ErrorValidateMsgs);
            }
        }
        /*protected override int DoInsert(User entity)
        {
            User user = new User(entity.UserCode, entity.UserName, entity.DepartmentID, entity.PositionID, entity.Email, entity.Status);
            var res = _repository.Insert(user);
            var list = new List<int>();
            List<Guid> roleIDs = entity.RoleID;
            foreach (var item in roleIDs)
            {
                User_Role userRole = new User_Role(user.UserID, item);
                var response = _roleRepository.Insert(userRole);
                list.Add(response);
            }
            foreach (var item in list)
            {
                if (item == 0)
                {
                    res = 0;
                    break;
                }

            }
            return res;

        }*/

        /// <summary>
        /// Author: THBAC (15/8/2022)
        /// Hàm validate
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        protected override bool Validate(User user)
        {

            //Check bắt buộc nhập mã nhân viên:
            if (string.IsNullOrEmpty(user.UserCode))
            {
                IsValid = false;
                ErrorValidateMsgs.Add("Mã người dùng không được phép để trống");
            }
            //Check bắt buộc nhập tên nhân viên:
            if (string.IsNullOrEmpty(user.UserName))
            {
                IsValid = false;
                ErrorValidateMsgs.Add("Tên người dùng không được phép để trống");
            }
            //Check trùng mã:
            if (_repository.CheckUserCodeExits(user.UserCode) == true)
            {
                IsValid = false;
                ErrorValidateMsgs.Add("Mã người dùng đã tồn tại");
            }
            //Check email
            if (!string.IsNullOrEmpty(user.Email) && !Regex.IsMatch(user.Email, @"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$"))
            {
                IsValid = false;
                ErrorValidateMsgs.Add("Email không đúng định dạng");
            }


            return IsValid;
        }
    }
}
