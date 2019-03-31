using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProHallManagement.Models
{
    public class UComment
    {

        public int Id { get; set; }
        public string Body { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }


        public int PostId { get; set; }
        [ForeignKey("PostId")]
        public virtual UPost UPost { get; set; }
    }
}