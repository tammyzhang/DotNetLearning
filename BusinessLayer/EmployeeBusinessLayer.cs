using System.Collections.Generic;
using System.Linq;
using BusinessEntities;
using DataAccessLayer;

namespace BusinessLayer
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployees()
        {
            //return new List<Employee>
            //{
            //    new Employee
            //    {
            //        FirstName = "John",
            //        LastName = "Smith",
            //        Salary = 20000
            //    },
            //    new Employee
            //    {
            //        FirstName = "Adm",
            //        LastName = "Wamg",
            //        Salary = 20382
            //    },
            //    new Employee
            //    {
            //        FirstName = "Huarekrj",
            //        LastName = "Xureile",
            //        Salary = 4567
            //    }
            //};
            var employeeDAL = new EmployeeDAL();
            return employeeDAL.Employees.ToList();
        }

        public Employee SaveEmployee(Employee e)
        {
            EmployeeDAL employeeDAL = new EmployeeDAL();
            employeeDAL.Employees.Add(e);
            employeeDAL.SaveChanges();
            return e;
        }


        public UserStatus IsValidUser(UserDetails u)
        {
            if (u.UserName == "Admin" && u.Password == "Admin")
            {
                return UserStatus.AuthenticatedAdmin;
            }
            else if(u.UserName=="Sukesh"&&u.Password=="Sukesh")
            {
                return UserStatus.AuthenticatedUser;
            }
            else
            {
                return UserStatus.NonAuthenticatedUser;
            }
        }

        public void UploadEmployees(List<Employee> employees)
        {
            EmployeeDAL employeeDal = new EmployeeDAL();
            foreach (var employee in employees)
            {
                employeeDal.Employees.Add(employee);
            }
            employeeDal.SaveChanges();
        }
    }
}