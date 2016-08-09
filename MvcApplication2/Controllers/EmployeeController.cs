using System;
using System.Linq;
using System.Web.Mvc;
using BusinessEntities;
using BusinessLayer;
using MvcApplication2.Filters;
using ViewModels;

namespace MvcApplication2.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/
        [HeaderFooterFilter]
        [Authorize]
        public ActionResult Index()
        {
            var employeeList = new EmployeeBusinessLayer().GetEmployees();
            var employeeListViewModel = new EmployeeListViewModel();
            employeeListViewModel.UserName = User.Identity.Name;
            var employeeViewModels = employeeList.Select(employee => new EmployeeViewModel
            {
                Name = employee.FirstName + " " + employee.LastName, Salary = employee.Salary, SalaryColor = employee.Salary > 10000 ? "red" : "green"
            }).ToList();
            employeeListViewModel.Employees = employeeViewModels;
           
            return View("Index",employeeListViewModel);
        }

        [AdminFilter]
        [HeaderFooterFilter]
        public ActionResult AddNew()
        {
            CreateEmployeeViewModel employeeViewModel = new CreateEmployeeViewModel();

            return View("CreateEmployee", employeeViewModel);
        }

        [AdminFilter]
        [HeaderFooterFilter]
        public ActionResult SaveEmployee(Employee e, string btnSubmit)
        {
            switch (btnSubmit)
            {
                case "Save Employee":
                    if (ModelState.IsValid)
                    {
                        EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
                        employeeBusinessLayer.SaveEmployee(e);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        CreateEmployeeViewModel vm = new CreateEmployeeViewModel();
                        vm.FirstName = e.FirstName;
                        vm.LastName = e.LastName;
                        if (e.Salary.HasValue)
                        {
                            vm.Salary = e.Salary.ToString();
                        }
                        else
                        {
                            vm.Salary = ModelState["Salary"].Value.AttemptedValue;
                        }
                       
                        return View("CreateEmployee",vm);
                    }
                    
                case "Cancel":
                    return RedirectToAction("Index");
            }
            return new EmptyResult();
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
       
       
    }
}
