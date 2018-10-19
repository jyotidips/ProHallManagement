using ProHallManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProHallManagement.ViewModel
{
    public class TotalViewModel : BaseViewModel
    {
        public Student Students { get; set; }
        public List<Session> Sessions { get; set; }
        public List<Faculty> Faculty { get; set; }


        public Teacher Teachers { get; set; }
        public Employee Employees { get; set; }
        public Work Works { get; set; }


        public Notification Notifications { get; set; }
        public List<Post> Posts { get; set; }


    }
}