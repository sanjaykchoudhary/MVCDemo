using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitOfWorkRepositoryPattern.DAL;
using UnitOfWorkRepositoryPattern.GenericRepository;
using UnitOfWorkRepositoryPattern.Repository;
using UnitOfWorkRepositoryPattern.UnitOfWork;

namespace UnitOfWorkRepositoryPattern.Controllers
{
    public class EmployeeController : Controller
    {
        private UnitOfWork<EmployeeDBContext> unitOfWork = new UnitOfWork<EmployeeDBContext>();
        private GenericRepository<Employee> repository;
        private IEmployeeRepository employeeRepository;

        public EmployeeController()
        {
            //IF you want to work with Generic repository with unit of work.
            repository = new GenericRepository<Employee>(unitOfWork);
            //IF you want to use specific repository with Unit of work.
            employeeRepository = new EmployeeRepository(unitOfWork);
        }
        // GET: Employee
        [HttpGet]
        public ActionResult Index()
        {
            var model = repository.GetAll();
            return View(model);
            //Using Specific Repository
            //var model = employeeRepository.GetEmployeesByDepartment(1);
        }
        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(Employee emp)
        {
            try
            {
                unitOfWork.CreateTransaction();
                if(ModelState.IsValid)
                {
                    repository.Insert(emp);
                    unitOfWork.Save();
                    //Do Some Other Task with the Database
                    //If everything is working then commit the transaction else rollback the transaction
                    unitOfWork.Commit();
                    return RedirectToAction("Index", "Employee");
                }
            }
            catch(Exception ex)
            {
                //Log the exception and rollback the transaction.
                
                unitOfWork.Rollback();
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditEmployee(int empID)
        {
            Employee emp = repository.GetById(empID);
            return View(emp);
        }
        [HttpPost]
        public ActionResult EditEmployee(Employee emp)
        {
            if(ModelState.IsValid)
            {
                repository.Update(emp);
                unitOfWork.Save();
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                return View(emp);
            }
        }
        [HttpGet]
        public ActionResult DeleteEmployee(int empID)
        {
            Employee emp = repository.GetById(empID);
            return View(emp);
        }
        [HttpPost]
        public ActionResult Delete(int empID)
        {
            Employee emp = repository.GetById(empID);
            repository.Delete(emp);
            unitOfWork.Save();
            return RedirectToAction("Index", "Employee");
        }
    }
}