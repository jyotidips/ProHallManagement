using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using ProHallManagement.Areas.Admin.ViewModels;
using ProHallManagement.Models;
using ProHallManagement.ViewModel;

namespace ProHallManagement.Areas.Admin.Controllers
{
    public class WorksController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Admin/Works
        public ActionResult Index()
        {
            return View(db.Works.ToList());
        }

        // GET: Admin/Works/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work work = db.Works.Find(id);
            if (work == null)
            {
                return HttpNotFound();
            }
            return View(work);
        }

        // GET: Admin/Works/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Work work)
        {
            if (ModelState.IsValid)
            {
                db.Works.Add(work);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(work);
        }

        // GET: Admin/Works/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work work = db.Works.Find(id);
            if (work == null)
            {
                return HttpNotFound();
            }
            return View(work);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Work work)
        {
            if (ModelState.IsValid)
            {
                db.Entry(work).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(work);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work work = db.Works.Find(id);
            if (work == null)
            {
                return HttpNotFound();
            }

            ViewBag.work = work.Name;
            var assignedEmp = db.Employees.Where(e => e.WorkID == id).ToList();
            ViewBag.assignedEmp = assignedEmp;
            var data = new AssignedEmployees
            {
                Work = work,
                Employees = assignedEmp
            };
            Session["assignedEmp"] = assignedEmp;
            Session["id"] = id;

            return View(data);
        }



        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Work work = db.Works.Find(id);

            var employees = db.Employees.Where(e => e.WorkID == id).ToList();
            var users = db.Users.ToList();
            foreach (var emp in employees)
            {
                foreach (var user in users)
                {
                    if (emp.Phone == user.Email)
                    {
                        db.Users.Remove(user);
                    }
                }
            }

            foreach (var item in employees)
            {
                db.Employees.Remove(item);
            }

            db.Works.Remove(work);
            db.SaveChanges();
            return RedirectToAction("Index");
        }




        [HttpGet]
        public ActionResult AssignedEmployees()
        {

            var works = db.Works.ToList();
            var id = (int)Session["id"];

            var assigned = db.Employees.Where(e => e.WorkID == id).ToList();


            ViewBag.success = Session["success"];

            var viewModel = new AssignedEmployees
            {
                Works = works,
                Employees = assigned
            };


            return View(viewModel);
        }


        public ActionResult EditAssigned(int? id)

        {
            if (id == null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }

            //var id = (int)Session["id"];
            var works = db.Works.ToList();
            var assigned = db.Employees.Single(e => e.Id == id);

            var viewModel = new AssignedEmployees
            {
                Works = works,
                EmpName = assigned.Name,
                EmpAddress = assigned.Address,
                EmpPhone = assigned.Phone,
                Employee = assigned
            };

            return View(viewModel);
        }


        [HttpPost]
        public ActionResult SaveAssigned(AssignedEmployees model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //save employee table
            var emp = db.Employees.First(e => e.Phone == model.EmpPhone);
            emp.Name = model.EmpName;
            emp.Address = model.EmpAddress;
            emp.Phone = model.EmpPhone;
            emp.WorkID = model.Employee.WorkID;


            //save user table
            var user = db.Users.First(u => u.Email == model.EmpPhone);
            user.Name = model.EmpName;
            user.Email = model.EmpPhone;

            Session["success"] = "Your Data is Edited Successfully";
            db.SaveChanges();

            return RedirectToAction("AssignedEmployees");
        }


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
