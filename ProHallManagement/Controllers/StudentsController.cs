using ProHallManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using ProHallManagement.ViewModel;

namespace ProHallManagement.Controllers
{
    public class StudentsController : Controller
    {
        readonly DataContext studentContext;
        List<StudentView> _studentview;

        public StudentsController()
        {
            studentContext = new DataContext();
        }

        protected override void Dispose(bool Disposing)
        {
            studentContext.Dispose();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var students = studentContext.Students
                .Include(s => s.Faculty)
                .Include(s => s.Session)
                .ToArray()
                .Select(c => new StudentView(c))
                .ToList();
            return View(students);
        }


        //being changed

        [Route("Students/Search/{search}")]
        public ActionResult Search(string search)
        {

            if (ViewBag.count == 1)
            {

                _studentview = null;

            }
            ViewBag.count = 0;
            this._studentview = studentContext.Students
              .Include(c => c.Session)
              .Include(c => c.Faculty)
              .Where(s => s.Name.Contains(search))
              .ToArray()
              .Select(c => new StudentView(c))
              .ToList();
            return View("Index", _studentview);


        }

        //being changed

        public ActionResult Create()
        {
            var studentdata = new StudentFacultySessionViewModel()
            {
                Faculty = studentContext.Faculties.ToList(),
                Session = studentContext.Sessions.ToList()
            };
            return View(studentdata);
        }




        [HttpPost]
        public ActionResult AddStudent(StudentFacultySessionViewModel studentV)
        {
            if (studentContext.Students.Single(s => s.Email == studentV.Student.Email) != null)
            {
                ViewBag.error = studentV.Student.Name + " is already registered with this Email";
                return View("Create", studentV);
            }

            var user = new User
            {
                Name = studentV.Student.Name,
                Email = studentV.Student.Email,
                Password = "12345",
                CreatedAt = DateTime.Now,
                UserCategoryId = 1
            };

            var student = new Student
            {
                StudentId = studentV.Student.StudentId,
                Name = studentV.Student.Name,
                Email = studentV.Student.Email,
                Attachment = studentV.Student.Attachment,
                Registration = studentV.Student.Registration,
                FacultyId = studentV.Student.FacultyId,
                SessionId = studentV.Student.SessionId,
                Phone = studentV.Student.Phone
            };



            studentContext.Users.Add(user);
            studentContext.Students.Add(student);
            studentContext.SaveChanges();
            return RedirectToAction("Index", "Students");
        }


        public ActionResult Edit(int Id)
        {
            var studentInDb = studentContext.Students.SingleOrDefault(c => c.StudentId == Id);
            var data = new StudentFacultySessionViewModel
            {
                Student = studentInDb,
                Faculty = studentContext.Faculties.ToList(),
                Session = studentContext.Sessions.ToList()
            };
            return View(data);
        }


        public ActionResult Update(Student student)
        {
            if (studentContext.Students.Single(s => s.Email == student.Email) != null)
            {
                ViewBag.error = student.Name + " is already registered with this Email";
                return View("Edit");
            }

            var studentData = studentContext.Students
                .Include(s => s.Faculty)
                .Include(s => s.Session)
                .Single(c => c.StudentId == student.StudentId);

            var userdata = studentContext.Users.Single(u => u.Email == studentData.Email);


            //User table data manipulate
            userdata.Name = student.Name;
            userdata.Email = student.Email;

            //Student Table data manipulate
            studentData.StudentId = student.StudentId;
            studentData.Name = student.Name;
            studentData.Email = student.Email;
            studentData.Attachment = student.Attachment;
            studentData.Registration = student.Registration;
            studentData.FacultyId = student.FacultyId;
            studentData.SessionId = student.SessionId;
            studentData.Phone = student.Phone;

            studentContext.SaveChanges();
            return RedirectToAction("Index", "Students");
        }



        //public ActionResult Search(string name)
        //{
        //    var student = studentContext.Students.Where(c=>c.Name==name).ToList();

        //    var studentList = new SearchViewModel
        //    {
        //        Student = student,
        //    };

        //    return View(studentList);
        //}
    }
}