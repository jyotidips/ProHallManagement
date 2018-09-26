using ProHallManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using ProHallManagement.ViewModel;

namespace ProHallManagement.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users

        private DataContext context;
        private bool act;
        public UsersController()
        {
            context = new DataContext();
        }

        //protected override void Dispose(bool Disposing)
        //{
        //    context.Dispose();
        //}
        public ActionResult Index()
        {
            var users = context.Users.Include(c => c.UserCategory).ToList();

            return View(users);
        }



        public ActionResult SignUp()
        {
            var Faculties = context.Faculties.ToList();
            var Sessions = context.Sessions.ToList();
            var works = context.Works.ToList();
            var viewmod = new UserView
            {
                Faculty = Faculties,
                Session = Sessions,
                Work = works
            };

            return View(viewmod);
        }



        public ActionResult SignUpAsStudent(UserView user)
        {
            var newuser = new User
            {
                Name = user.Student.Name,
                Email = user.Student.Email,
                Password = user.Password,
                CreatedAt = DateTime.Now,
                UserCategoryId = 1
            };


            var newstudent = new Student
            {
                Name = user.Student.Name,
                StudentId = user.Student.StudentId,
                Registration = user.Student.Registration,
                Email = user.Student.Email,
                Attachment = user.Student.Attachment,
                Faculty = user.Student.Faculty,
                FacultyId = user.Student.FacultyId,
                Session = user.Student.Session,
                SessionId = user.Student.SessionId,
                Phone = user.Student.Phone,
                Post = user.Student.Post,
                PostId = user.Student.PostId
            };

            context.Students.Add(newstudent);
            context.Users.Add(newuser);
            context.SaveChanges();


            return RedirectToAction("Index", "Students");
        }


        public ActionResult SignUpAsTeacher(UserView user)
        {
            var newuser = new User
            {
                Name = user.Teacher.Name,
                Email = user.Teacher.Email,
                Password = user.Password,
                CreatedAt = DateTime.Now,
                UserCategoryId = 2
            };


            if (DateTime.Now < user.Teacher.DateEnd)
            {
                act = true;
            }
            else
            {
                act = false;
            }


            var newteacher = new Teacher
            {
                Name = user.Teacher.Name,
                Email = user.Teacher.Email,
                Address = user.Teacher.Address,
                DateJoined = user.Teacher.DateJoined,
                DateEnd = user.Teacher.DateJoined.AddYears(1),
                Activity = act,
                Phone = user.Teacher.Phone

            };

            context.Teachers.Add(newteacher);
            context.Users.Add(newuser);
            context.SaveChanges();


            return RedirectToAction("Index", "Teachers");
        }





        public ActionResult SignUpAsEmployee(UserView user)
        {
            var newuser = new User
            {
                Name = user.Employee.Name,
                Email = user.Employee.Phone,
                Password = user.Password,
                CreatedAt = DateTime.Now,
                UserCategoryId = 3
            };


            var newemployee = new Employee
            {
                Name = user.Teacher.Name,

                Address = user.Teacher.Address,
                WorkID = user.Employee.WorkID,
                Phone = user.Employee.Phone
            };

            context.Employees.Add(newemployee);
            context.Users.Add(newuser);
            context.SaveChanges();


            return RedirectToAction("Index", "Teachers");
        }




        [HttpGet]
        public ActionResult SignIn()
        {

            return View();
        }



        public ActionResult SignIn(LoginViewModel signinVM)
        {
            if (ModelState.IsValid)
            {

                var emailPass = context.Users
                    .Where(u => u.Email == signinVM.Email && u.Password.Contains(signinVM.Password)).FirstOrDefault();

                var idpass = context.Users
                    .Where(u => u.Id == signinVM.Id && u.Password.Contains(signinVM.Password)).FirstOrDefault();

                if (emailPass != null || idpass != null)
                {


                    Session["Id"] = signinVM.Id;
                    Session["Email"] = signinVM.Email;

                    return RedirectToAction("Account", "Users");
                }
            }


            return View(signinVM);
        }


        public ActionResult Account()
        {


            var email = Session["Email"];

            var user = context.Users.First(u => u.Email == email);
            if (user.UserCategoryId == 1)
            {
                var student = context.Students.Include(s => s.Faculty).Include(s => s.Session).Where(u => u.Email == email).FirstOrDefault();

                var data = new TotalViewModel
                {
                    Students = student,
                    Faculty = context.Faculties.ToList(),
                    Sessions = context.Sessions.ToList()
                };
                return View(data);
            }


            return View(user);
        }



        //[HttpPost]
        //public ActionResult StartSession(LoginViewModel login)
        //{

        //    var userexists = context.Users.Where(u => u.Email.Contains(login.Email) && u.Password.Contains(login.Password)).FirstOrDefault();

        //    if (userexists != null)
        //    {

        //        Session["Name"] = userexists.Name;
        //        Session["Email"] = userexists.Email;

        //    }
        //    else
        //    {

        //        return Content("Data not exists");
        //    }

        //    return View();
        //}

    }
}