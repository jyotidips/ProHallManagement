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
        private string _error = "";
        private readonly DataContext _context;
        private bool _act;
        public UsersController()
        {
            _context = new DataContext();
        }

        public ActionResult Index()
        {
            var users = _context.Users.Include(c => c.UserCategory).ToList();

            return View(users);
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            var faculties = _context.Faculties.ToList();
            var sessions = _context.Sessions.ToList();
            var userCat = _context.UserCategories.ToList();
            var works = _context.Works.ToList();
            var viewmodel = new UserView
            {
                Faculty = faculties,
                Session = sessions,
                Work = works,
                UserCategory = userCat

            };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult SignUp(UserView user, int id)
        {
            var faculties = _context.Faculties.ToList();
            var sessions = _context.Sessions.ToList();
            var userCat = _context.UserCategories.ToList();
            var works = _context.Works.ToList();

            var viewmodel = new UserView
            {
                Faculty = faculties,
                Session = sessions,
                Work = works,
                UserCategory = userCat
            };


            if (id == 1)
            {
                if (_context.Users.SingleOrDefault(u => u.Email == user.Student.Email) != null)
                {
                    ViewBag.error = user.Student.Name + " is already registered with " + user.Student.Email + " email";

                    return View(viewmodel);
                }



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

                _context.Students.Add(newstudent);
                _context.Users.Add(newuser);
                _context.SaveChanges();
                ViewBag.success = "You are Registered succesfully";

                return View(viewmodel);
            }
            else if (id == 2)
            {
                if (_context.Users.SingleOrDefault(u => u.Email == user.Teacher.Email) != null)
                {
                    ViewBag.error = user.Teacher.Name + " is already registered with " + user.Teacher.Email + " email";

                    return View(viewmodel);
                }


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
                    _act = true;
                }
                else
                {
                    _act = false;
                }

                var newteacher = new Teacher
                {
                    Name = user.Teacher.Name,
                    Email = user.Teacher.Email,
                    Address = user.Teacher.Address,
                    DateJoined = user.Teacher.DateJoined,
                    DateEnd = user.Teacher.DateJoined.AddYears(1),
                    Activity = _act,
                    Phone = user.Teacher.Phone

                };

                _context.Teachers.Add(newteacher);
                _context.Users.Add(newuser);
                _context.SaveChanges();

                ViewBag.success = "You are Registered succesfully";
                return View(viewmodel);
            }
            else if (id == 3)
            {
                if (_context.Users.SingleOrDefault(u => u.Email == user.Employee.Phone) != null)
                {
                    ViewBag.error = user.Employee.Name + " is already registered with " + user.Employee.Phone + " email/phone";

                    return View(viewmodel);
                }

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
                    Name = user.Employee.Name,
                    Address = user.Employee.Address,
                    WorkID = user.Employee.WorkID,
                    Phone = user.Employee.Phone
                };

                _context.Employees.Add(newemployee);
                _context.Users.Add(newuser);
                _context.SaveChanges();

                ViewBag.success = "You are Registered succesfully";
                return View(viewmodel);
            }

            return View(viewmodel);
        }


        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(LoginViewModel signinVm)
        {
            SignInFn(signinVm);
            return RedirectToAction("Account", "Users");
        }




        //This is the ACCOUNT action of USER CONTROLLER
        [HttpGet]
        public ActionResult Account()
        {
            var email = Session["Email"];

            if (email != null)
            {
                var user = _context.Users.First(u => u.Email == email);
                if (user.UserCategoryId == 1)
                {
                    var student = _context.Students.Include(s => s.Faculty).Include(s => s.Session).Where(u => u.Email == email).First();

                    var data = new TotalViewModel
                    {
                        Students = student,
                        Faculty = _context.Faculties.ToList(),
                        Sessions = _context.Sessions.ToList(),
                        CurrentUserName = student.Name
                    };
                    return View(data);
                }

                else if (user.UserCategoryId == 2)
                {
                    var teacher = _context.Teachers.Where(u => u.Email == email).First();

                    var data = new TotalViewModel
                    {
                        Teachers = teacher,
                        CurrentUserName = teacher.Name
                    };
                    return View(data);
                }

                else if (user.UserCategoryId == 3)
                {

                    var employee = _context.Employees.Where(u => u.Phone == email).First(); //here the email and phone for employee is same

                    var data = new TotalViewModel
                    {
                        //Employees = employee,
                        CurrentUserName = employee.Name
                    };
                    return View(data);
                }
                else
                {
                    return Content("User of this Category does not exists");
                }
            }

            else
            {
                return RedirectToAction("SignIn", "Users");
            }

        }





        public void SignInFn(LoginViewModel signinVm)
        {

            if (ModelState.IsValid)
            {
                var emailPass = _context.Users.FirstOrDefault(u => u.Email == signinVm.Email && u.Password.Contains(signinVm.Password));

                //var idpass = context.Users
                //    .Where(u => u.Id == signinVM.Id && u.Password.Contains(signinVM.Password)).FirstOrDefault();

                var idPass = _context.Users.FirstOrDefault(u => u.Id == signinVm.Id && u.Password.Contains(signinVm.Password));

                if (emailPass != null || idPass != null)
                {
                    Session["Id"] = signinVm.Id;
                    Session["Email"] = signinVm.Email;
                }
            }
        }

        public ActionResult SignOut()
        {
            Session.Clear();
            Session.RemoveAll();
            return RedirectToAction("SignIn");
        }



    }
}