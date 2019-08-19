using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataAccess
{
    public class EmployeeSecurity
    {
        public static bool Login(string username,string password)
        {
            using (EmployeeDataEntities entities = new EmployeeDataEntities())
            {
                return entities.Users.Any(user => user.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && user.Password == password);
            }
        }
    }

}
