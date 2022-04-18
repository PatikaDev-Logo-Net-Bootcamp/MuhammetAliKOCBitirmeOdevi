using Business.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserTypeService
    {
        IQueryable<UserType> UserTypes();

        ReturnObjectDTO GetUserType(int id);
        List<UserTypeDTO> GetAllUserTypes();
        ReturnObjectDTO AddUserType(UserTypeDTO userType);

        ReturnObjectDTO UpdateUserType(int id, UserTypeDTO userType, string updatedBy = "Api Kullanicisi");

        ReturnObjectDTO DeleteUserType(int id, string updatedBy = "Api Kullanicisi");
    }
}
