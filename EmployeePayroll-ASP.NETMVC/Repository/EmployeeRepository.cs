using EmployeePayroll_ASP.NETMVC.Models;
using EmployeePayroll_ASP.NETMVC.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeePayroll_ASP.NETMVC.Repository
{
    public class EmployeeRepository
    {
        /// <summary>
        /// The database
        /// </summary>
        public ApplicationDbContext db = new ApplicationDbContext();
        /// <summary>
        /// Gets the employees.
        /// </summary>
        /// <returns></returns>
        public List<EmployeeViewModel> GetEmployees()
        {
            try
            {
                List<EmployeeViewModel> list = (from e in db.Employees
                                                join d in db.Departments on e.DepartmentId equals d.DeptId
                                                join s in db.Salaries on e.SalaryId equals s.SalaryId
                                                select new EmployeeViewModel
                                                {
                                                    EmpId = e.EmpId,
                                                    Name = e.Name,
                                                    Gender = e.Gender,
                                                    DepartmentId = d.DeptId,
                                                    Department = d.DeptName,
                                                    SalaryId = s.SalaryId,
                                                    Amount = s.Amount,
                                                    StartDate = e.StartDate,
                                                    Description = e.Description
                                                }).ToList<EmployeeViewModel>();

                return list;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Registers the employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns></returns>
        public bool RegisterEmployee(RegisterRequestModel employee)
        {

            try
            {
                Employee validEmployee = db.Employees.Where(x => x.Name == employee.Name && x.Gender == employee.Gender).FirstOrDefault();
                if (validEmployee == null)
                {
                    int departmentId = db.Departments.Where(x => x.DeptName == employee.Department).Select(x => x.DeptId).FirstOrDefault();
                    Employee newEmployee = new Employee()
                    {
                        Name = employee.Name,
                        Gender = employee.Gender,
                        DepartmentId = departmentId,
                        SalaryId = Convert.ToInt32(employee.SalaryId),
                        StartDate = employee.StartDate,
                        Description = employee.Description
                    };
                    Employee returnData = db.Employees.Add(newEmployee);
                }
                int result = db.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Gets the employee.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Employee GetEmployee(int id)
        {
            try
            {
                Employee list = db.Employees.Where(x => x.EmpId == id).SingleOrDefault();

                return list;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Updates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public int Update(Employee model)
        {
            var data = db.Employees.FirstOrDefault(x => x.EmpId == model.EmpId);

            // Checking if any such record exist  
            if (data != null)
            {
                data.EmpId = model.EmpId;
                data.Name = model.Name;
                data.Gender = model.Gender;
                data.DepartmentId = model.DepartmentId;
                data.Department = model.Department;
                data.SalaryId = model.SalaryId;
                data.Salary = model.Salary;
                data.StartDate = model.StartDate;
                data.Description = model.Description;
                return db.SaveChanges();
            }
            else
                return 0;
        }
    }
}