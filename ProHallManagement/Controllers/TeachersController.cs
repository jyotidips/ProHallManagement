using ProHallManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProHallManagement.Controllers
{
    public class TeachersController : Controller
    {

        private bool act;
        DataContext teacherContext;

        public TeachersController()
        {
            teacherContext = new DataContext();
        }

        protected override void Dispose(bool disposing)
        {
            teacherContext.Dispose();
        }


        // GET: Teachers
        public ActionResult Index()
        {
            var teachers = teacherContext.Teachers.ToList();

            return View(teachers);
        }

        public ActionResult Create()
        {
            return View();
            //return RedirectToAction("Index", "Teachers");
        }
        [HttpPost]
        public ActionResult AddTeacher(Teacher teacher)
        {

            if (teacherContext.Teachers.Single(t => t.Email == teacher.Email) != null)
            {
                ViewBag.error = teacher.Name + " is already registered with this Email";
                return View("Create", teacher);
            }

            var newuser = new User
            {
                Name = teacher.Name,
                Email = teacher.Email,
                Password = "12345", //Here any password cannot be given By Admin
                CreatedAt = DateTime.Now,
                UserCategoryId = 2
            };


            if (DateTime.Now < teacher.DateEnd)
            {
                act = true;
            }
            else
            {
                act = false;
            }
            var newteacher = new Teacher
            {
                Name = teacher.Name,
                Email = teacher.Email,
                Address = teacher.Address,
                DateJoined = teacher.DateJoined,
                DateEnd = teacher.DateJoined.AddYears(1),
                Activity = act,
                Phone = teacher.Phone
            };

            teacherContext.Teachers.Add(newteacher);
            teacherContext.Users.Add(newuser);
            teacherContext.SaveChanges();

            return RedirectToAction("Index", "Teachers");
        }

        public ActionResult Edit(int Id)
        {
            var teacherOfDb = teacherContext.Teachers.SingleOrDefault(c => c.Id == Id);

            return View(teacherOfDb);

        }



        public ActionResult Update(Teacher teacher)
        {
            if (teacherContext.Students.Single(s => s.Email == teacher.Email) != null)
            {
                ViewBag.error = teacher.Name + " is already registered with this Email";
                return View("Edit", teacher);
            }

            var TeacherInDb = teacherContext.Teachers.Single(c => c.Id == teacher.Id);

            var userdata = teacherContext.Users.Single(u => u.Email == TeacherInDb.Email);

            userdata.Name = teacher.Name;
            userdata.Email = teacher.Email;

            //userdata.UserCategoryId is not needed
            //userdata.CreatedAt  Here Created at is null
            //userdata.Password HEre, password will be set null



            TeacherInDb.Name = teacher.Name;
            TeacherInDb.Address = teacher.Address;
            TeacherInDb.DateJoined = teacher.DateJoined;
            TeacherInDb.DateEnd = teacher.DateEnd;
            TeacherInDb.Activity = teacher.Activity;
            TeacherInDb.Phone = teacher.Phone;

            teacherContext.SaveChanges();

            return RedirectToAction("Index", "Teachers");
        }
    }
}