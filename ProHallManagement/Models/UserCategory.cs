﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProHallManagement.Models
{
    public class UserCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }

    }
}