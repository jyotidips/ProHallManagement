using ProHallManagement.Models;
using ProHallManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProHallManagement.Controllers
{
    public class EmployeesController : Controller
    {
        DataContext _context;

        public EmployeesController()
        {
            _context = new DataContext();
        }

        protected override void Dispose(bool Disposing)
        {
            _context.Dispose();
        }
        // GET: Employees
        public ActionResult Index()
        {
            var employees = _context.Employees.Include(c => c.Work).ToList();
            return View(employees);
        }
        public ActionResult Create()
        {
            var allWorks = new EmployeeViewModel
            {
                Work = _context.Works.ToList(),
            };

            return View(allWorks);
        }


        public ActionResult Add(EmployeeViewModel viewModel)
        {
            if (_context.Students.Single(s => s.Email == viewModel.Employee.Phone) != null)
            {
                ViewBag.error = viewModel.Employee.Name + " is already registered with this : " + viewModel.Employee.Phone + " Email/Phone";
                return View("Create", viewModel);
            }

            var user = new User
            {
                Name = viewModel.Employee.Name,
                Email = viewModel.Employee.Phone,
                Password = "12345",  //Here The password field is left empty
                CreatedAt = DateTime.Now,
                UserCategoryId = 3
            };



            var emp = new Employee
            {
                Name = viewModel.Employee.Name,
                Address = viewModel.Employee.Address,
                Phone = viewModel.Employee.Phone,
                WorkID = viewModel.Employee.WorkID

            };


            if (ModelState.IsValid)
            {
                _context.Employees.Add(emp);
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            else
            {
                string v = "Theres Something Problem Happened";
                ViewBag.v = v;
            }
            return RedirectToAction("Index", "Employees");
        }

        public ActionResult Edit(int Id)
        {
            var employeeInDb = _context.Employees.SingleOrDefault(m => m.Id == Id);
            var viewModelData = new EmployeeViewModel
            {
                Employee = employeeInDb,
                Work = _context.Works.ToList()
            };
            return View(viewModelData);
        }

        public ActionResult Update(EmployeeViewModel emp)
        {
            var empdata = _context.Employees.Include(m => m.Work).Single(m => m.Id == emp.Employee.Id);




            //try
            //{
            var userdata = _context.Users.Single(u => u.Email == empdata.Phone);
            //User table
            userdata.Name = emp.Employee.Name;
            userdata.Email = emp.Employee.Phone;   // phone number of the USER
            //}
            //catch (Exception e)
            //{

            //    throw new Exception();
            //}





            //Employee table
            empdata.Name = emp.Employee.Name;
            empdata.WorkID = emp.Employee.WorkID;
            empdata.Address = emp.Employee.Address;
            empdata.Phone = emp.Employee.Phone;   //phone number of the EMPLOYEE






            _context.SaveChanges();

            return RedirectToAction("Index", "Employees");
        }

    }
}