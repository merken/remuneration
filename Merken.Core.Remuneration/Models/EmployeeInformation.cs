using Merken.Core.Remuneration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merken.Core.Remuneration.Enum;
using Merken.Core.Remuneration.Common;
using Merken.Core.Remuneration.Common.Enum;

namespace Merken.Core.Remuneration.Models
{
    public class EmployeeInformation : IEmployeeInformation
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public int NumberOfChildren { get; set; }
        public int NumberOfChildrenOnCharge { get; set; }
        public int NumberOfChildrenOnChargeWithHandicap { get; set; }
        public double BrutoSalary { get; set; }
    }
}
