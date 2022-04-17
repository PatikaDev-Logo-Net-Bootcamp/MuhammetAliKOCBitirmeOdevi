using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class User:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PictureUrl { get; set; }


        public ICollection<UserRole> UserRoles { get; set; }

        public ICollection<Car> UserCars { get; set; }
    }
}
