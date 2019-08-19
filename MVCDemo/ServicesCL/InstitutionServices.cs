using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesCL;

namespace ServicesCL
{
    public interface IInstitutionServices
    {
        Institution GetInstitutionByID(long institutionID);
    }
    public class InstitutionServices : IInstitutionServices
    {
        public Institution GetInstitutionByID(long institutionID)
        {
            return new Institution
            {
                InstitutionID = institutionID,
                Name = "Demo Institute",
                Address = "Bangalore",
                Mobile = "0128732123"
            };
        }
    }
}
