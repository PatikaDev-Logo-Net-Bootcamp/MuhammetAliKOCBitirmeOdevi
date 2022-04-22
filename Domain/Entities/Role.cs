using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Role : IdentityRole
    {
        public Role() : base()
        {
        }
        public Role(string roleName) : base(roleName)
        {
        }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
