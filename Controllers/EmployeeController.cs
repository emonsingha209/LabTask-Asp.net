using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginLabTask.Models;
using LoginLabTask;
using System.ComponentModel.DataAnnotations;

namespace LoginLabTask.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeModel employeeModel)
        {
            EmployeeRepo employeeRepo = new EmployeeRepo();
            if (ModelState.IsValid)
            {
                var id = employeeRepo.AddEmployee(employeeModel);
                if (id > 0)
                {
                    ModelState.Clear();
                    ViewBag.Okay = "User Added";
                }
            }

            return View();
        }

        public ActionResult ShowEmployee()
        {
            EmployeeRepo employeeRepo = new EmployeeRepo();
            var data = employeeRepo.ShowEmployee();
            return View(data);
        }

        public ActionResult Edit(int id)
        {
            EmployeeRepo employeeRepo = new EmployeeRepo();
            var data = employeeRepo.GetData(id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeModel employeeModel)
        {
            EmployeeRepo employeeRepo = new EmployeeRepo();

            if (ModelState.IsValid)
            {
                employeeRepo.UpdateData(employeeModel.Id, employeeModel);
                ViewBag.Okay = "Updated";
            }

            return View(employeeRepo);
        }
        public ActionResult Delete(int id)
        {
            EmployeeRepo employeeRepo = new EmployeeRepo();
            var data = employeeRepo.GetData(id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Delete(EmployeeModel employeeModel)
        {
            EmployeeRepo employeeRepo = new EmployeeRepo();
            employeeRepo.DeleteData(employeeModel.Id);
            return View("Create");
        }
    }
}