using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ProHallManagement.Models;

namespace ProHallManagement.ViewModel
{
    public class ChangePassword
    {

        private readonly DataContext _context;
        public ChangePassword()
        {
            _context = new DataContext();
        }


        public int Id { get; set; }

        [Required(ErrorMessage = "This Field Is Required")]

        public string PreviousPassword { get; set; }



        [Required(ErrorMessage = "This Field Is Required")]
        public string NewPassword { get; set; }



        [Required(ErrorMessage = "This Field Is Required")]
        [System.Web.Mvc.Compare("NewPassword", ErrorMessage = "Password Does not Match")]
        public string ConfirmNewPassword { get; set; }








    }
}