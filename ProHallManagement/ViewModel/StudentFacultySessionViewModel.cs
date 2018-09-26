using ProHallManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProHallManagement.ViewModel
{
    public class StudentFacultySessionViewModel
    {
        public Student Student { get; set; }
        public IEnumerable<Faculty> Faculty { get; set; }
        public IEnumerable<Session> Session { get; set; }

    }
}