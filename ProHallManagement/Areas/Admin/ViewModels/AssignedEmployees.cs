using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProHallManagement.Models;

namespace ProHallManagement.Areas.Admin.ViewModels
{
    public class AssignedEmployees
    {
        public List<Work> Works { get; set; }
        public List<Employee> Employees { get; set; }

        public Employee Employee { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public string EmpPhone { get; set; }
        public int EmpWorkId { get; set; }

        public Work Work { get; set; }




    }
}