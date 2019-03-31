using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProHallManagement.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }


    }
}