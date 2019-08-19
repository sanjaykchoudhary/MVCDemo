﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RepositoryUsingEFinMVC.DAL;
using RepositoryUsingEFinMVC.Repository;

namespace RepositoryUsingEFinMVC.Controllers
{
    public class EmployeeController_WithoutGeneric : Controller
    {
        IEmployeeRepository empRepository;
        public EmployeeController_WithoutGeneric()
        {
            empRepository = new EmployeeRepository(new EmployeeDBContext());
        }
        public EmployeeController_WithoutGeneric(IEmployeeRepository repository)
        {
            empRepository = repository;
        }
        // GET: Employee
        [HttpGet]
        public ActionResult Index()
        {
            var model = empRepository.GetAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(Employee emp)
        {
            if(ModelState.IsValid)
            {
                empRepository.Insert(emp);
                empRepository.Save();
                return RedirectToAction("Index", "Employee");
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditEmployee(int empID)
        {
            Employee emp = empRepository.GetByID(empID);
            return View(emp);
        }
        [HttpPost]
        public ActionResult EditEmployee(Employee emp)
        {
            if(ModelState.IsValid)
            {
                empRepository.Update(emp);
                empRepository.Save();
                return RedirectToAction("Index", "Employee");
            }
            return View(emp);
        }
        [HttpGet]
        public ActionResult DeleteEmployee(int empID)
        {
            Employee emp = empRepository.GetByID(empID);
            return View(emp);
        }
        [HttpPost]
        public ActionResult Delete(int empID)
        {
            empRepository.Delete(empID);
            empRepository.Save();
            return RedirectToAction("Index", "Employee");
        }
    }
}