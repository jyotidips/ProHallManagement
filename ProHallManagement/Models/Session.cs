using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ProHallManagement.Models
{
    public class Session
    {
        public int Id { get; set; }
        [DisplayName("Session")]
        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }

    }
}