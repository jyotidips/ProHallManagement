using ProHallManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProHallManagement.ViewModel
{
    public class StudentView
    {

        public StudentView(Student students)
        {
            StudentId = students.StudentId;
            Name = students.Name;
            Email = students.Email;
            Attachment = students.Attachment;
            Registration = students.Registration;
            FacultyId = students.FacultyId;
            SessionId = students.SessionId;
            Faculty = students.Faculty;
            Session = students.Session;
            Phone = students.Phone;

        }




        [DisplayName("Student ID")]
        public int StudentId { get; set; }

        [Required]
        [DisplayName("Student Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }


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
    }
}