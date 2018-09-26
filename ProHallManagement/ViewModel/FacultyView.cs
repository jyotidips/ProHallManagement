using ProHallManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProHallManagement.ViewModel
{
    public class FacultyView
    {
        public FacultyView()
        {

        }

        public FacultyView(Faculty faculty)
        {
            Id = faculty.Id;
            Name = faculty.Name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}