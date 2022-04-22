using Business.DTO;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Business.Abstract
{
    public interface IUserTypeService
    {
        IQueryable<UserType> UserTypes();
        ReturnObjectDTO GetUserType(int id);
        List<UserTypeDTO> GetAllUserTypes();
        ReturnObjectDTO AddUserType(UserTypeDTO userType);
        ReturnObjectDTO UpdateUserType(int id, UserTypeDTO userType, string updatedBy = "");
        ReturnObjectDTO DeleteUserType(int id, string updatedBy = "");
    }
}
