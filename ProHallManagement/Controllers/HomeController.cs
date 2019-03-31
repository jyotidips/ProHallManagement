using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProHallManagement.Models;
using ProHallManagement.ViewModel;

namespace ProHallManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _context;
        private bool act;
        private string currentUserName;

        public HomeController()
        {
            _context = new DataContext();
        }

        public ActionResult Index()
        {
            if (Session["Email"] != null)
            {
                TotalViewModel baseView = new TotalViewModel
                {
                    CurrentUserName = currentUserName
                };
            }
            else
            {
                TotalViewModel baseView = new TotalViewModel
                {
                    CurrentUserName = ""
                };
            }




            return View();



        }
    }
}