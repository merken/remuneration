using Merken.Core.Remuneration.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merken.Core.Remuneration.Models
{
    public class PerformanceInformation : IPerformanceInformation
    {
        public PerformanceInformation(double baseSalary = 0.0d, double performanceBaseLine = 0.0d, double contractualHoursPerDay = 0.0d)
        {
            this.BaseSalary = baseSalary;
            this.PerformanceBaseline = performanceBaseLine;
            this.ContractualHoursPerDay = contractualHoursPerDay;

            Performances = new List<IPerformance>();
        }

        public double BaseSalary { get; }

        public double PerformanceBaseline { get; }

        public double ContractualHoursPerDay { get; }

        public IList<IPerformance> Performances { get; set; }
    }
}
