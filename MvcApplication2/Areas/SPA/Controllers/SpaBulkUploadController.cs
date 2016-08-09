using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessEntities;
using BusinessLayer;
using ViewModels.SPA;

namespace MvcApplication2.Areas.SPA.Controllers
{
    public class SpaBulkUploadController : Controller
    {
        //
        // GET: /SPA/SpaBulkUpload/

        public ActionResult Index()
        {
            return PartialView("Index");
        }

        public ActionResult Upload(FileUploadViewModel viewModel)
        {
            List<Employee> employees = GetEmployees(viewModel);
            EmployeeBusinessLayer bal = new EmployeeBusinessLayer();
            bal.UploadEmployees(employees);
            EmployeeListViewModel vm = new EmployeeListViewModel();
            vm.Employees = new List<EmployeeViewModel>();
            foreach (Employee item in employees)
            {
                EmployeeViewModel evm = new EmployeeViewModel();
                evm.Name = item.FirstName + " " + item.LastName;
                evm.Salary = item.Salary.Value.ToString("C");
                if (item.Salary > 15000)
                {
                    evm.SalaryColor = "yellow";
                }
                else
                {
                    evm.SalaryColor = "green";
                }
                vm.Employees.Add(evm);
            }
            return Json(vm);
        }

        private List<Employee> GetEmployees(FileUploadViewModel viewModel)
        {
            List<Employee> employees = new List<Employee>();
            StreamReader csvReader = new StreamReader(viewModel.fileUpload.InputStream);
            csvReader.ReadLine();
            while (!csvReader.EndOfStream)
            {
                var line = csvReader.ReadLine();
                var values = line.Split(',');
                Employee e = new Employee();
                e.FirstName = values[0];
                e.LastName = values[1];
                e.Salary = int.Parse(values[2]);

                employees.Add(e);
            }

            return employees;
        }
    }
}
