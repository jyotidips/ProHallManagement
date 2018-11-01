using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProHallManagement.Models
{
    public class Post
    {
        public Post()
        {
            Status = false;
            Support = 0;
            Unsupport = 0;
        }



        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public bool Status { get; set; }
        public int Support { get; set; }
        public int Unsupport { get; set; }



        public int UserId { get; set; }
        public virtual User User { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public PostImage PostImageId { get; set; }
        public PostImage PostImage { get; set; }

    }
}