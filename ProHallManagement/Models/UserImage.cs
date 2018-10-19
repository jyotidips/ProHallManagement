using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProHallManagement.Models
{
    public class UserImage
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }


        public int UserId { get; set; }
        public User User { get; set; }
    }
}