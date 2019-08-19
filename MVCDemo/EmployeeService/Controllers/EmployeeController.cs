using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeDataAccess;

namespace EmployeeService.Controllers
{
    public class EmployeeController : ApiController
    {
        public IEnumerable<EmployeeData> Get()
        {
            using (EmployeeDataEntities entities = new EmployeeDataEntities())
            {
                return entities.EmployeeDatas.ToList();
            }
        }

        public EmployeeData Get(int id)
        {
            EmployeeDataEntities entities = new EmployeeDataEntities();
            return entities.EmployeeDatas.FirstOrDefault(emp => emp.ID == id);
        }
    }
}
