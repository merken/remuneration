using Merken.Core.Remuneration.Common;
using Merken.Core.Remuneration.Common.Enum;
using Merken.Core.Remuneration.Enum;
using Merken.Core.Remuneration.Interfaces;
using Merken.Core.Remuneration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merken.Core.Remuneration.Tests.Repositories
{
    public class FakeEmployeeRepositoryBlueCollar : IEmployeeRepository
    {
        public IEmployeeInformation GetEmployeeInformation(int employeeId, DateTime? date = default(DateTime?))
        {
            return new EmployeeInformation
            {
                FirstName = "Steven",
                LastName = "Stevens",
                BrutoSalary = 2088,
                EmployeeType = EmployeeType.BlueCollar,
                NumberOfChildren = 2,
                NumberOfChildrenOnCharge = 2
            };
        }
    }

    public class FakeEmployeeRepositoryWhiteCollar : IEmployeeRepository
    {
        public IEmployeeInformation GetEmployeeInformation(int employeeId, DateTime? date = default(DateTime?))
        {
            return new EmployeeInformation
            {
                FirstName = "Jan",
                LastName = "Jansen",
                BrutoSalary = 3000,
                EmployeeType = EmployeeType.WhiteCollar,
                NumberOfChildren = 1,
                NumberOfChildrenOnCharge = 1
            };
        }
    }

    public class FakeEmployeeRepositoryWhiteCollar2 : IEmployeeRepository
    {
        public IEmployeeInformation GetEmployeeInformation(int employeeId, DateTime? date = default(DateTime?))
        {
            return new EmployeeInformation
            {
                FirstName = "Peter",
                LastName = "Peters",
                BrutoSalary = 2844.64,
                EmployeeType = EmployeeType.WhiteCollar,
                NumberOfChildren = 1,
                NumberOfChildrenOnCharge = 1
            };
        }
    }
}
