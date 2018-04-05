using Merken.Core.Remuneration.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merken.Core.Remuneration.Common
{
    /// <summary>
    /// A performance represents a service from an employee.
    /// If he worked 1 full day, the performance will be :
    /// -Code 001
    /// -Description Work
    /// -Days 1
    /// -Hours 8
    /// -Amount 1
    /// -Value 12.00d (Euro/hour)
    /// -Type BusinessDay
    /// 
    /// For a fixed performance (compensation for a business travel or a compensation for working out of office)
    /// -Code 010
    /// -Description Compensation
    /// -Days 1
    /// -Hours 8
    /// -Amount 1
    /// -Value 14.00 (per day)
    /// -Type BusinessTravel or BusinessDayOnSite 
    /// </summary>
    public interface IPerformance
    {
        /// <summary>
        /// The internal performance code
        /// </summary>
        string Code { get; }

        /// <summary>
        /// Human readable description
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Amount of days for the performance
        /// </summary>
        double Days { get; }

        /// <summary>
        /// Amount of hours for the performance
        /// </summary>
        double Hours { get; }

        /// <summary>
        /// The amount of the performance
        /// </summary>
        double Amount { get; }

        /// <summary>
        /// This can be the wage or the value of the performance in case of a fixed value.
        /// </summary>
        double Value { get; }

        /// <summary>
        /// The type of performance
        /// </summary>
        PerformanceType Type { get; }
    }
}
