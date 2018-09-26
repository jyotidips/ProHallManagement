using ProHallManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProHallManagement.ViewModel
{
    public class EmployeeViewModel
    {

        public Employee Employee { get; set; }
        public IEnumerable<Work> Work { get; set; }

    }
}