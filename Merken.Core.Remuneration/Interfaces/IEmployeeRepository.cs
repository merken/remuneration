﻿using Merken.Common.Interfaces;
using Merken.Core.Remuneration.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merken.Core.Remuneration.Interfaces
{
    public interface IEmployeeRepository : ICanBeResolved
    {
        IEmployeeInformation GetEmployeeInformation(int employeeId, DateTime? date = default(DateTime?));
    }
}
