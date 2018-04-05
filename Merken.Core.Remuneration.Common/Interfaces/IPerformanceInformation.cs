using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merken.Core.Remuneration.Common
{
    public interface IPerformanceInformation
    {
        /// <summary>
        /// The bruto base salary of the employee.
        /// </summary>
        double BaseSalary { get; }

        /// <summary>
        /// The number of days that the employee is supposed to work.
        /// Number of working days in the month.
        /// </summary>
        double PerformanceBaseline { get; }

        /// <summary>
        /// The amount of hours/day that the employee is supposed to work, according to the agreement.
        /// </summary>
        double ContractualHoursPerDay { get; }

        /// <summary>
        /// The performances delivered by the employee.
        /// </summary>
        IList<IPerformance> Performances { get; }
    }
}
