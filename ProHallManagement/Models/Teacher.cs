using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProHallManagement.Models
{
    public class Teacher
    {

        public int Id { get; set; }

        [Required]
        [DisplayName("Teacher Name")]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }


        [Required]
        [DisplayName("Joining Date")]
        public DateTime DateJoined { get; set; }

        [DisplayName("Work End")]
        public DateTime DateEnd { get; set; }

        [DisplayName("Active Now")]
        public Boolean Activity { get; set; }

        [Required]
        [DisplayName("Phone No.")]
        public int Phone { get; set; }


        public int FacultyId { get; set; }
        [ForeignKey("FacultyId")]
        public virtual Faculty Faculty { get; set; }



    }
}