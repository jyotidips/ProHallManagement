using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProHallManagement.Models
{
    public class User
    {


        public User()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public DateTime CreatedAt { get; set; }

        public int UserCategoryId { get; set; }

        public UserCategory UserCategory { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<UserImage> UserImages { get; set; }




    }
}