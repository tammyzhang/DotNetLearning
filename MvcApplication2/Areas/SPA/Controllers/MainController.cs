using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BusinessEntities;
using BusinessLayer;
using MvcApplication2.Filters;
using ViewModels.SPA;
using OldViewModel = ViewModels;

namespace MvcApplication2.Areas.SPA.Controllers
{
    public class MainController : Controller
    {
        //
        // GET: /SPA/Main/

        public ActionResult Index()
        {
            var vm = new MainViewModel
            {
                UserName = User.Identity.Name,
                FooterData =
                    new OldViewModel.FooterViewModel
                    {
                        CompanyName = "StepByStepSchools",
                        Year = DateTime.Now.Year.ToString()
                    }
            };
            return View("Index", vm);
        }


        public ActionResult EmployeeList()
        {
            var employeeListViewModel = new ViewModels.SPA.EmployeeListViewModel();
            var empBal = new EmployeeBusinessLayer();
            List<Employee> employees = empBal.GetEmployees();

            var empViewModels = new List<EmployeeViewModel>();
            foreach (Employee emp in employees)
            {
                var empViewModel = new EmployeeViewModel();
                empViewModel.Name = emp.FirstName + " " + emp.LastName;
                empViewModel.Salary = emp.Salary.Value.ToString("C");
                if (emp.Salary > 15000)
                {
                    empViewModel.SalaryColor = "yellow";
                }
                else
                {
                    empViewModel.SalaryColor = "green";
                }
                empViewModels.Add(empViewModel);
            }
            employeeListViewModel.Employees = empViewModels;
            return View("EmployeeList", employeeListViewModel);
        }


        public ActionResult GetAddNewLink()
        {
            if (Convert.ToBoolean(Session["IsAdmin"]))
            {
                return PartialView("AddNewLink");
            }
            else
            {
                return new EmptyResult();
            }
        }

        [AdminFilter]
        public ActionResult AddNew()
        {
            var v = new CreateEmployeeViewModel();
            return PartialView("CreateEmployee", v);
        }

        [AdminFilter]
        public ActionResult SaveEmployee(Employee emp)
        {
            var empBal = new EmployeeBusinessLayer();
            empBal.SaveEmployee(emp);

            var empViewModel = new EmployeeViewModel();
            empViewModel.Name = emp.FirstName + " " + emp.LastName;
            empViewModel.Salary = emp.Salary.Value.ToString("C");
            if (emp.Salary > 15000)
            {
                empViewModel.SalaryColor = "yellow";
            }
            else
            {
                empViewModel.SalaryColor = "green";
            }
            return Json(empViewModel);
        }
    }
}
