using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using BusinessEntities;
using BusinessLayer;
using MvcApplication2.Filters;
using ViewModels;

namespace MvcApplication2.Controllers
{
    public class BulkUploadController : AsyncController
    {
        
        [AdminFilter]
        [HeaderFooterFilter]
        public ActionResult Index()
        {
            return View(new FileUploadViewModel());
        }

        public ActionResult Upload(FileUploadViewModel viewModel)
        {
            List<Employee> employees = GetEmployees(viewModel);
            EmployeeBusinessLayer bal = new EmployeeBusinessLayer();
            bal.UploadEmployees(employees);
            return RedirectToAction("Index", "Employee");
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
