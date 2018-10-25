using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProHallManagement.Models;

namespace ProHallManagement.Areas.Admin.ViewModels
{
    public class RoleAssign
    {
        public List<User> Users { get; set; }
        public List<Role> Roles { get; set; }

        public User User { get; set; }
        public Role Role { get; set; }

        public UserRole UserRole { get; set; }
        public List<UserRole> UserRoles { get; set; }


    }
}