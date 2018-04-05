using Merken.Core.Remuneration.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merken.Core.Remuneration.Models
{
    public class SalaryCalculationContext : IContext
    {
        public SalaryCalculationContext(IEmployerInformation employerInformation, IEmployeeInformation employeeInformation, IPerformanceInformation performanceInformation, DateTime? date = default(DateTime?))
        {
            this.EmployerInformation = employerInformation;
            this.EmployeeInformation = employeeInformation;
            this.PerformanceInformation = performanceInformation;
            this.Date = date;

            this.RemunCalculationResults = new List<IRemunCalculationResult>();
        }

        public IEmployeeInformation EmployeeInformation { get; set; }

        public IEmployerInformation EmployerInformation { get; set; }

        public IPerformanceInformation PerformanceInformation { get; set; }

        public IList<IRemunCalculationResult> RemunCalculationResults { get; set; }

        public DateTime? Date { get; set; }
    }
}
