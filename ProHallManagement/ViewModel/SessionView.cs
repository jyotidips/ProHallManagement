using ProHallManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ProHallManagement.ViewModel
{
    public class SessionView
    {
        public SessionView(){}


        public SessionView(Session session)
        {
            Id = session.Id;
            Name = session.Name;
        }

        public int Id { get; set; }
        [DisplayName("Session")]
        public string Name { get; set; }
    }
}