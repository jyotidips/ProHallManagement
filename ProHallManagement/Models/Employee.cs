using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProHallManagement.Models
{
    public class Employee
    {

        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }

        public string Phone { get; set; }

        public int WorkID { get; set; }
        [ForeignKey("WorkID")]
        public virtual Work Work { get; set; }



    }
}