using ProHallManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.IO;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using ProHallManagement.ViewModel;
using WebGrease.Css.Extensions;

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
                //------------------------------------------------------------------------


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
            var login = SignInFn(signinVm);
            if (login == false)
            {
                ViewBag.errorin = "Your Login Credential is invalid";
                return View("SignIn");
            }


            return RedirectToAction("Account", "Users");
        }




        //This is the ACCOUNT action of USER CONTROLLER
        [HttpGet]
        public ActionResult Account()
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("SignIn");
            }

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
        //------------------------------------------------Account Action Done!!---------------------------------------


        //Basic view loader for Profile
        public ActionResult UserProfile()
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("SignIn");
            }

            var id = (int)Session["Id"];

            var userdata = _context.Users.Find(id);




            var viewmodel = new UserView
            {
                User = userdata
            };


            return View(viewmodel);
        }



        //Update User Profile Data
        [HttpPost]
        public ActionResult UpdateProfile(UserView uv)
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("SignIn");
            }

            var email = Session["Email"];

            var userData = _context.Users.SingleOrDefault(u => u.Email == email);

            var stdData = _context.Students.SingleOrDefault(c => c.Email == email);


            var teachData = _context.Teachers.SingleOrDefault(t => t.Email == email);

            var empData = _context.Employees.SingleOrDefault(e => e.Phone == email);


            //checks if the user is existed in Both User and Student table
            if (userData != null && stdData != null)
            {

                if (uv.User.Email != uv.User.ConfirmEmail && uv.User.Password != uv.User.ConformPassword)
                {
                    return View("UserProfile", uv);
                }

                userData.Name = uv.User.Name;
                userData.Email = uv.User.Email;
                userData.Password = uv.User.Password;


                stdData.Name = uv.User.Name;
                stdData.Email = uv.User.Email;

                _context.Users.Add(userData);
                _context.Students.Add(stdData);
                _context.SaveChanges();
            }

            //checks if the user is existed in Both User and Teacher table
            else if (userData != null && teachData != null)
            {

                if (uv.User.Email != uv.User.ConfirmEmail && uv.User.Password != uv.User.ConformPassword)
                {
                    return View("UserProfile", uv);
                }

                userData.Name = uv.User.Name;
                userData.Email = uv.User.Email;
                userData.Password = uv.User.Password;


                teachData.Name = uv.User.Name;
                teachData.Email = uv.User.Email;

                _context.Users.Add(userData);
                _context.Teachers.Add(teachData);
                _context.SaveChanges();
            }

            //checks if the user is existed in Both User and Employee table
            else if (userData != null && empData != null)
            {

                if (uv.User.Email != uv.User.ConfirmEmail && uv.User.Password != uv.User.ConformPassword)
                {
                    return View("UserProfile", uv);
                }

                userData.Name = uv.User.Name;
                userData.Email = uv.User.Email;
                userData.Password = uv.User.Password;


                empData.Name = uv.User.Name;
                empData.Phone = uv.User.Email;



                _context.Users.Add(userData);
                _context.Employees.Add(empData);
                _context.SaveChanges();
            }
            else
            {
                ViewBag.error = "Data is missing Somewhere";
                return View("UserProfile");
            }
            return RedirectToAction("UserProfile");
        }

        //------------------------------------------------Update Profile Done!!---------------------------------------



        //Change Image
        public ActionResult Change()
        {

            if (Session["Id"] == null)
            {
                return RedirectToAction("SignIn");
            }

            var userId = (int)Session["Id"];

            if (Session["successRPP"] != null)
            {
                var successMsgPro = Session["successRPP"];
                ViewBag.successpro = successMsgPro;
            }

            if (Session["successRCP"] != null)
            {
                var successMsgCover = Session["successRCP"];
                ViewBag.successcover = successMsgCover;
            }


            var profileImgUrl = _context.UserImages.Where(i => i.IsProfilePic == true && i.UserId == userId).FirstOrDefault();
            var coverImgUrl = _context.UserImages.Where(i => i.IsCoverPic == true && i.UserId == userId).FirstOrDefault();


            if (profileImgUrl != null)
            {
                ViewBag.proImageId = profileImgUrl.Id;
                ViewBag.profileImgUrl = profileImgUrl.ImageUrl;
            }

            if (coverImgUrl != null)
            {
                ViewBag.coverImageId = coverImgUrl.Id;
                ViewBag.coverImgUrl = coverImgUrl.ImageUrl;
            }


            Session["successRPP"] = null;
            Session["successRCP"] = null;

            return View();
        }


        public ActionResult RemovePro(int id)
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("SignIn");
            }

            var image = _context.UserImages.Where(i => i.Id == id).First();
            image.IsProfilePic = false;

            _context.Entry(image).State = EntityState.Modified;
            _context.SaveChanges();
            Session["successRPP"] = "Successfully Removed Profile Picture";
            return RedirectToAction("Change");
        }

        public ActionResult RemoveCover(int id)
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("SignIn");
            }
            var image = _context.UserImages.Where(i => i.Id == id).First();

            image.IsCoverPic = false;

            _context.Entry(image).State = EntityState.Modified;
            _context.SaveChanges();
            Session["successRCP"] = "Successfully Removed Cover Picture";

            return RedirectToAction("Change");
        }
        public ActionResult ChangePassword()
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("SignIn");
            }

            var id = (int)Session["Id"];


            var viewm = new UserView
            {
                ChangePassword = new ChangePassword
                {
                    Id = id
                }
            };

            return View(viewm);
        }


        [HttpPost]
        public ActionResult ChangePassword(UserView userView)
        {

            if (Session["Id"] == null)
            {
                return RedirectToAction("SignIn");
            }
            var id = (int)Session["Id"];

            var user = _context.Users.Find(id);



            if (user != null)
            {
                if (userView.ChangePassword.NewPassword != null && user.Password != userView.ChangePassword.NewPassword)
                {

                    var viewm = new UserView
                    {
                        ChangePassword = new ChangePassword
                        {
                            Id = id
                        }
                    };

                    ViewBag.errorPass = "Your Password Did not match!";
                    return View(viewm);
                }

                user.Password = userView.ChangePassword.NewPassword;
                _context.Entry(user).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
                return RedirectToAction("SignIn");
            }

            return View();
        }


        public ActionResult SaveProfileImage(UserImage ui)
        {

            if (Session["Id"] == null)
            {
                return RedirectToAction("SignIn");
            }
            var userId = (int)Session["Id"];

            var album = _context.Albums.SingleOrDefault(c => c.Name == "Profile");


            if (album == null)
            {
                var newProfileAlbum = new Album
                {
                    Name = "Profile",
                    UserId = userId
                };

                _context.Albums.Add(newProfileAlbum);
                _context.SaveChanges();
            }

            var albumCreated = _context.Albums.Single(c => c.Name == "Profile");

            string fileName = Path.GetFileNameWithoutExtension(ui.ImageFile.FileName);
            string extension = Path.GetExtension(ui.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            ui.ImageUrl = "~/Assets/Images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Assets/Images/"), fileName);
            ui.ImageFile.SaveAs(fileName);

            ui.AlbumId = albumCreated.Id;
            ui.UserId = userId;
            ui.IsCoverPic = false;
            ui.IsProfilePic = true;
            ui.Title = "Profile-Pic";

            _context.UserImages.Add(ui);
            _context.SaveChanges();


            return View("Change");
        }

        //------------------------------------------------Save Profile Image Done!!---------------------------------------


        public ActionResult SaveCoverImage(UserImage ui)
        {

            if (Session["Id"] == null)
            {
                return RedirectToAction("SignIn");
            }
            var userId = (int)Session["Id"];
            var album = _context.Albums.SingleOrDefault(c => c.Name == "Cover");
            if (album == null)
            {
                var newCoverAlbum = new Album
                {
                    Name = "Cover",
                    UserId = userId
                };

                _context.Albums.Add(newCoverAlbum);
                _context.SaveChanges();
            }

            var albumCreated = _context.Albums.Single(c => c.Name == "Cover");

            string fileName = Path.GetFileNameWithoutExtension(ui.ImageFile.FileName);
            string extension = Path.GetExtension(ui.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            ui.ImageUrl = "/Assets/Images/" + fileName;
            fileName = Path.Combine(Server.MapPath("/Assets/Images/"), fileName);
            ui.ImageFile.SaveAs(fileName);

            ui.AlbumId = albumCreated.Id;
            ui.UserId = userId;
            ui.IsCoverPic = true;
            ui.IsProfilePic = false;
            ui.Title = "Cover-Pic";
            _context.UserImages.Add(ui);
            _context.SaveChanges();


            return View("Change");
        }

        //------------------------------------------------Save Cover Done!!---------------------------------------


        public bool SignInFn(LoginViewModel signinVm)
        {


            if (ModelState.IsValid)
            {
                var emailPass = _context.Users.FirstOrDefault(u => u.Email == signinVm.Email && u.Password == signinVm.Password);

                //var idpass = context.Users
                //    .Where(u => u.Id == signinVM.Id && u.Password.Contains(signinVM.Password)).FirstOrDefault();

                if (emailPass == null)
                {
                    return false;
                }

                var user = _context.Users.FirstOrDefault(u => u.Email == signinVm.Email);

                var id = emailPass.Id;

                Session["Id"] = id;
                Session["Email"] = emailPass.Email;

                //var idPass = _context.Users.FirstOrDefault(u => u.Id == signinVm.Id && u.Password.Contains(signinVm.Password));

                //if (emailPass != null || idPass != null)
                //{
                //    Session["Id"] = signinVm.Id;
                //    Session["Email"] = signinVm.Email;


                //}
            }

            return true;
        }
        //------------------------------------------------Sign In Function Done!!---------------------------------------

        public ActionResult SignOut()
        {
            Session.Clear();
            Session.RemoveAll();
            return RedirectToAction("SignIn");
        }
        //------------------------------------------------Sign-Out Action Function Done!!---------------------------------------


    }
}