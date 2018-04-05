using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merken.Core.Remuneration.Common
{
    /// <summary>
    /// This class represents the context for the salary calculation
    /// </summary>
    public interface IContext
    {
        IEmployeeInformation EmployeeInformation { get; }

        IEmployerInformation EmployerInformation { get; }

        IPerformanceInformation PerformanceInformation { get; }

        IList<IRemunCalculationResult> RemunCalculationResults { get; }

        DateTime? Date { get; }
    }
}
