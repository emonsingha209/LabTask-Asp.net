using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LoginLabTask.Models;

namespace LoginLabTask
{
    public class EmployeeRepo
    {
        public int AddEmployee(EmployeeModel employeeModel)
        {
            using (var context = new LabTaskEntities())
            {
                Employee c = new Employee()
                {
                    Name = employeeModel.Name,
                    DOB = employeeModel.DOB,
                    Email = employeeModel.Email,
                    PhoneNo = employeeModel.PhoneNo,
                };

                context.Employee.Add(c);

                context.SaveChanges();

                return c.Id;
            }
        }

        public EmployeeModel GetData(int id)
        {
            using (var context = new LabTaskEntities())
            {
                var result = context.Employee.Where(x => x.Id == id).Select(x => new EmployeeModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    DOB = x.DOB,
                    Email = x.Email,
                    PhoneNo = x.PhoneNo,
                }
                ).FirstOrDefault();

                return result;
            }
        }

        public bool UpdateData(int id, EmployeeModel employeeModel)
        {
            using (var context = new LabTaskEntities())
            {
                var employee = context.Employee.FirstOrDefault(x => x.Id == id);

                if (employee != null)
                {
                    employee.Name = employeeModel.Name;
                    employee.DOB = employeeModel.DOB;
                    employee.Email = employeeModel.Email;
                    employee.PhoneNo = employeeModel.PhoneNo;
                }

                context.SaveChanges();

                return true;
            }
        }

        public bool DeleteData(int id)
        {
            using (var context = new LabTaskEntities())
            {
                var employee = context.Employee.FirstOrDefault(x => x.Id == id);
                if (employee != null)
                {
                    context.Employee.Remove(employee);
                    context.SaveChanges();
                    return true;
                }

                return false;
            }
        }

        public List<EmployeeModel> ShowEmployee()
        {
            using (var context = new LabTaskEntities())
            {
                var result = context.Employee.Select(x => new EmployeeModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    DOB = x.DOB,
                    Email = x.Email,
                    PhoneNo = x.PhoneNo,
                }
                ).ToList();

                return result;
            }
        }
    }
}