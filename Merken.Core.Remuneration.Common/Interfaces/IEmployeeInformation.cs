using Merken.Core.Remuneration.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merken.Core.Remuneration.Common
{
    public interface IEmployeeInformation
    {
        int Id { get; }
        string FirstName { get; set; }
        string LastName { get; set; }
        int NumberOfChildren { get; set; }
        int NumberOfChildrenOnCharge { get; set; }
        int NumberOfChildrenOnChargeWithHandicap { get; set; }
        double BrutoSalary { get; set; }
        EmployeeType EmployeeType { get; set; }
    }
}
