using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCPLibrary
{
    public class ManagerModel : IApplicantModel
    {
        public IAccount AccountProcessor { get; set; } = new ManagerAccounts();

        public string FirstName { get; set; }

        public string LastName { get; set; }

    }

}
