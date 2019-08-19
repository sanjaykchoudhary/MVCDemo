using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCPLibrary
{
   public class Account : IAccount
    {
        public EmployeeModel Create(IApplicantModel person)
        {
            EmployeeModel output = new EmployeeModel();
            output.FirstName = person.FirstName;
            output.LastName = person.LastName;
            output.EmailAddress = $"{person.FirstName.Substring(0, 1)}{person.LastName}@acme.com";
            

            return output;

            //if (person.TypeOfEmployee == EmployeeType.Manager)
            //{
            //    output.IsManager = true;
            //}

            //switch (person.TypeOfEmployee)
            //{
            //    case EmployeeType.Staff:
            //        break;
            //    case EmployeeType.Manager:
            //        output.IsManager = true;
            //        break;
            //    case EmployeeType.Executive:
            //        output.IsManager = true;
            //        output.IsExecutive = true;
            //        break;
            //    default:
            //        break;
            //}
        }
    }
}
