using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTest.Data;
using WebApiTest.Entities;

namespace WebApiTest.Business
{
    public interface EmployeeBusinessLogic
    {
        IEnumerable<Employee> GetEmployeeList();
        IEnumerable<Employee> GetEmployeeById(int id);
        void UpdateEmployee(Employee employee);
        void AddEmployee(Employee employee);
        void DeleteEmployee(int id);

    }

    public class EmployeeBL : EmployeeBusinessLogic
    {
        WebApiTestEntities db = new WebApiTestEntities();

        public void AddEmployee(Employee employee)
        {
            using (var db = new WebApiTestEntities())
            {
                Employee NewEmployee = new Employee();
                NewEmployee.Name = employee.Name;
                NewEmployee.Code = employee.Code;
                NewEmployee.Salary = employee.Salary;

                db.SaveChanges();
            }
        }

        public void DeleteEmployee(int id)
        {
            using (var db = new WebApiTestEntities())
            {
                Employee deleteEmployee = db.Employees.Where(x => x.EmployeeId == id).FirstOrDefault();
                db.Employees.Remove(deleteEmployee);
                db.SaveChanges();

            }
        }

        public IEnumerable<Employee> GetEmployeeById(int id)
        {
            using (var db = new WebApiTestEntities())
            {
                var query = (from emp in db.Employees.Where(x => x.EmployeeId == id)
                             select new Employee
                             {
                                 Name = emp.Name,
                                 Code = emp.Code,
                                 Salary = emp.Salary
                             }).ToList();

                return query;
            }
        }

        public IEnumerable<Employee> GetEmployeeList()
        {
            using (var db = new WebApiTestEntities())
            {
                var query = (from emp in db.Employees
                             select new Employee
                             {
                                 Name = emp.Name,
                                 Code = emp.Code,
                                 Salary = emp.Salary
                             });

                return query.ToList();
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            using (var db = new WebApiTestEntities())
            {
                Employee updateEmploye = db.Employees.Where(x => x.EmployeeId == employee.EmployeeId).FirstOrDefault();
                updateEmploye.Name = employee.Name;
                updateEmploye.Code = employee.Code;
                updateEmploye.Salary = employee.Salary;

                db.SaveChanges();

            }
        }
    }
}
