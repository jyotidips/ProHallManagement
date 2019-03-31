using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProHallManagement.Models
{
    public class UPost
    {


        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public bool Status { get; set; }


        public int Support { get; set; }
        public int Unsupport { get; set; }


        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }


        public virtual ICollection<UComment> Comments { get; set; }

        public virtual ICollection<PImage> PImage { get; set; }

    }
}