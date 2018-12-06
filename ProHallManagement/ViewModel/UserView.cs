using ProHallManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProHallManagement.ViewModel
{
    public class UserView
    {
        public UserView()
        {

        }

        public User User { get; set; }
        public Student Student { get; set; }
        public Teacher Teacher { get; set; }
        public Employee Employee { get; set; }
        public UserImage UserImage { get; set; }

        public string Password { get; set; }

        public IEnumerable<UserCategory> UserCategory { get; set; }
        public IEnumerable<Work> Work { get; set; }
        public IEnumerable<Faculty> Faculty { get; set; }
        public IEnumerable<Session> Session { get; set; }


        public ChangePassword ChangePassword { get; set; }


    }
}