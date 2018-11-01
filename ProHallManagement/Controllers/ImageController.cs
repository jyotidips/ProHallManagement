using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProHallManagement.Models;

namespace ProHallManagement.Controllers
{
    public class ImageController : Controller
    {

        private DataContext db = new DataContext();











        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}