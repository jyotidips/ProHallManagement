using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProHallManagement.Areas.Admin.ViewModels;
using ProHallManagement.Models;

namespace ProHallManagement.Areas.Admin.Controllers
{
    public class RolesController : Controller
    {
        private int userRoleID = 0;
        private DataContext db = new DataContext();

        // GET: Admin/Roles
        public ActionResult Index()
        {
            return View(db.Roles.ToList());
        }

        // GET: Admin/Roles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = db.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // GET: Admin/Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Role role)
        {
            if (ModelState.IsValid)
            {
                db.Roles.Add(role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(role);
        }

        // GET: Admin/Roles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = db.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Role role)
        {
            if (ModelState.IsValid)
            {
                db.Entry(role).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(role);
        }

        // GET: Admin/Roles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = db.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }


        // POST: Admin/Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            Role role = db.Roles.Find(id);
            var userRoles = db.UserRoles.Where(u => u.RoleId == id).ToList();

            foreach (var item in userRoles)
            {
                db.UserRoles.Remove(item);
            }

            db.Roles.Remove(role);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult AssignRole(string keyword)
        {
            var users = db.Users.Where(u => u.Email.Contains(keyword) || keyword == null).OrderByDescending(u => u.Id).ToList();
            var userRole = db.UserRoles.ToList();
            var roles = db.Roles.ToList();

            var vm = new RoleAssign
            {
                Users = users,
                UserRoles = userRole,
                Roles = roles
            };
            if (Session["AssignSuccess"] != null)
            {
                ViewBag.assignSuccess = Session["AssignSuccess"];
            }
            return View(vm);
        }


        [HttpGet]
        public ActionResult Assign(int id)
        {
            if (id == null || db.Users.Single(u => u.Id == id) == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "User Not Found!");
            }
            var user = db.Users.Single(u => u.Id == id);

            if (db.Roles == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Role Not Found!");
            }
            var roles = db.Roles.ToList();

            var viewModel = new RoleAssign
            {
                User = user,
                Roles = roles
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Assign(RoleAssign assign)
        {

            if (assign.User.Id == 0 || assign.UserRole.RoleId == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Role Or User Not Found!");
            }

            if (db.Users.Single(u => u.Id == assign.User.Id) == null ||
                db.Roles.Single(r => r.Id == assign.UserRole.RoleId) == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Role Or User Not Found!");
            }
            //var user = db.UserRoles.Where(u => u.Id == assign.User.Id);
            //var role = db.UserRoles.Where(r => r.Id == assign.UserRole.RoleId


            //var userR = db.UserRoles
            //    .Where(ur => ur.RoleId == assign.UserRole.RoleId)
            //    .Select(ur => ur.UserId == assign.User.Id).SingleOrDefault();

            var userRoles = db.UserRoles.ToList();
            foreach (var role in userRoles)
            {
                foreach (var user in userRoles)
                {
                    if (role.RoleId == assign.UserRole.RoleId && user.UserId == assign.User.Id)
                    {
                        userRoleID = db.UserRoles.Where(u => u.UserId == assign.User.Id && u.RoleId == assign.UserRole.RoleId)
                            .Select(u => u.Id).SingleOrDefault();
                    }
                }
            }

            if (userRoleID != 0)
            {
                var user = db.Users.Single(u => u.Id == assign.User.Id);

                if (db.Roles == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Role Not Found!");
                }
                var roles = db.Roles.ToList();

                var viewModel = new RoleAssign
                {
                    User = user,
                    Roles = roles
                };
                ViewBag.errorExist = "Your data already exists";
                return View(viewModel);
            }
            var userRole = new UserRole
            {
                UserId = assign.User.Id,
                RoleId = assign.UserRole.RoleId
            };
            db.UserRoles.Add(userRole);
            db.SaveChanges();
            Session["assignSuccess"] = "You Successfully assigned A Role With An User";

            return RedirectToAction("AssignRole");
        }


        public ActionResult DeleteRole(int id)
        {
            if (id == null || db.Users.Single(u => u.Id == id) == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "User Not Found!");
            }
            var user = db.Users.Single(u => u.Id == id);

            if (db.Roles == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Role Not Found!");
            }

            var userRoles = db.UserRoles.Where(u => u.UserId == id).ToList();
            var roles = db.Roles.ToList();
            var viewModel = new RoleAssign
            {
                User = user,
                UserRoles = userRoles,
                Roles = roles
            };

            return View(viewModel);
        }


        [HttpPost]
        public ActionResult DeleteRole(RoleAssign assign)
        {

            if (assign.User.Id == 0 || assign.UserRole.RoleId == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Role Or User Not Found!");
            }

            if (db.Users.Single(u => u.Id == assign.User.Id) == null ||
                db.Roles.Single(r => r.Id == assign.UserRole.RoleId) == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Role Or User Not Found!");
            }
            //var user = db.UserRoles.Where(u => u.Id == assign.User.Id);
            //var role = db.UserRoles.Where(r => r.Id == assign.UserRole.RoleId


            var userRoleId = db.UserRoles.Where(u => u.UserId == assign.User.Id && u.RoleId == assign.UserRole.RoleId)
                .Select(u => u.Id).Single();

            var userRole = db.UserRoles.Find(userRoleId);
            db.UserRoles.Remove(userRole);
            db.SaveChanges();
            Session["assignSuccess"] = "You Successfully Deleted A Role With An User";




            //var userRole = new UserRole
            //{
            //    UserId = assign.User.Id,
            //    RoleId = assign.UserRole.RoleId
            //};

            return RedirectToAction("AssignRole");

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
