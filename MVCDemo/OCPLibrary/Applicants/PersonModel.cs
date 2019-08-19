using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCPLibrary
{
    public class PersonModel : IApplicantModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IAccount AccountProcessor { get; set; } = new Account();

        //public EmployeeType TypeOfEmployee { get; set; } = EmployeeType.Staff;
    }
}
