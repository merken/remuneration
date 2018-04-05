using Merken.Core.Remuneration.Common;
using Merken.Core.Remuneration.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merken.Core.Remuneration.Models
{
    public class Performance : IPerformance
    {
        public Performance(string code, string description = "", double days = 0.0d, double amount = 0.0, double hours = 0.0d, double value = 0.0d, PerformanceType type = PerformanceType.None)
        {
            this.Code = code;
            this.Description = description;
            this.Days = days;
            this.Hours = hours;
            this.Amount = amount;
            this.Value = value;
            this.Type = type;
        }

        /// <summary>
        /// The internal performance code
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Human readable description
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Amount of days for the performance
        /// </summary>
        public double Days { get; }

        /// <summary>
        /// Amount of hours for the performance
        /// </summary>
        public double Hours { get; }

        /// <summary>
        /// The amount of the performance
        /// </summary>
        public double Amount { get; }

        /// <summary>
        /// This can be the wage or the value of the performance in case of a fixed value.
        /// </summary>
        public double Value { get; }

        /// <summary>
        /// The type of performance
        /// </summary>
        public PerformanceType Type { get; }
    }
}
