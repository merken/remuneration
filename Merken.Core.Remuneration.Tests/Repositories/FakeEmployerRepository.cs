using Merken.Core.Remuneration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merken.Core.Remuneration.Common;
using Merken.Core.Remuneration.Models;

namespace Merken.Core.Remuneration.Tests.Repositories
{
    public class FakeEmployerRepository : IEmployerRepository
    {
        public IEmployerInformation GetEmployerInformation(int employerId, DateTime? date = default(DateTime?))
        {
            return new EmployerInformation();
        }
    }
}
