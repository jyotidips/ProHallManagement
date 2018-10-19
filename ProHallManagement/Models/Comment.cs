using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProHallManagement.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Body { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        public Post PostId { get; set; }
        public Post Post { get; set; }

    }

}