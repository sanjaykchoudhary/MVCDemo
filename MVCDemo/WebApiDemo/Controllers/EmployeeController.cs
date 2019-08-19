using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeDataAccess;
using System.Threading;

namespace WebApiDemo.Controllers
{
    public class EmployeeController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage LoadEmployee()
        {
            try
            {
                using (EmployeeDataEntities entities = new EmployeeDataEntities())
                {
                    var entity = entities.EmployeeDatas.ToList();
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "There is no data in DB");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        public HttpResponseMessage LoadEmployeeByID(int id)
        {
            using (EmployeeDataEntities entities = new EmployeeDataEntities())
            {
                var entity = entities.EmployeeDatas.FirstOrDefault(emp => emp.ID == id);
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with ID: " + id.ToString() + " Not found.");
                }
            }                
        }

     
        public HttpResponseMessage Get(string gender)
        {
            using (EmployeeDataEntities entities = new EmployeeDataEntities())
            {
                //string username = Thread.CurrentPrincipal.Identity.Name;
                switch(gender.ToLower())
                {
                    case "all":
                        return Request.CreateResponse(HttpStatusCode.OK, entities.EmployeeDatas.ToList());
                    case "male":
                        return Request.CreateResponse(HttpStatusCode.OK, entities.EmployeeDatas.Where(emp => emp.Gender.ToLower() == "male").ToList());
                    case "female":
                        return Request.CreateResponse(HttpStatusCode.OK, entities.EmployeeDatas.Where(emp => emp.Gender.ToLower() == "female").ToList());
                    default:
                       return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Value for gender must be male, female, or all " + gender + " is invalid");
                }
            }
        }

        public HttpResponseMessage POST([FromBody] EmployeeData employee)
        {
            try
            {
                using (EmployeeDataEntities entities = new EmployeeDataEntities())
                {
                    entities.EmployeeDatas.Add(employee);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, employee);
                    message.Headers.Location = new Uri(Request.RequestUri + employee.ID.ToString());
                    return message;
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage PUT([FromBody]int id,[FromUri]EmployeeData employee)
        {
            try
            {
                using (EmployeeDataEntities entities = new EmployeeDataEntities())
                {
                    var entity = entities.EmployeeDatas.FirstOrDefault(emp => emp.ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with ID: " + id.ToString() + " Not found.");
                    }
                    entity.FirstName = employee.FirstName;
                    entity.LastName = employee.LastName;
                    entity.Gender = employee.Gender;
                    entity.Salary = employee.Salary;
                    entities.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (EmployeeDataEntities entities = new EmployeeDataEntities())
                {
                    var entity = entities.EmployeeDatas.FirstOrDefault(emp => emp.ID == id);
                    if(entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with ID: " + id.ToString() + " not found to delete.");
                    }
                    else
                    {
                        entities.EmployeeDatas.Remove(entity);
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
