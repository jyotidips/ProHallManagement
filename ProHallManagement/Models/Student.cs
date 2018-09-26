using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProHallManagement.Models
{
    public class Student
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [DisplayName("Student ID")]
        public int StudentId { get; set; }
        
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Student Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Attachment No.")]
        public int Attachment { get; set; }

        [Required]
        [DisplayName("Registration No.")]
        public int Registration { get; set; }


        public int FacultyId { get; set; }
        
        public Faculty Faculty { get; set; }

        public int SessionId { get; set; }

        public Session Session { get; set; }
        
        //public Boolean IsPaid { get; set; }
        [Required]
        [DisplayName("Phone No.")]
        public int Phone { get; set; }



        public int PostId { get; set; }
        public virtual ICollection<Post> Post { get; set; }


    }
}