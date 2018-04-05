using Merken.Core.Remuneration.Common;
using Merken.Core.Remuneration.Common.Enum;
using Merken.Core.Remuneration.Models;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merken.Core.Remuneration.Components.Wage
{
    /// <summary>
    /// This remun component will calculate the bruto wage for a blue collar worker
    /// </summary>
    [Export(typeof(IRemunCalculationComponent))]
    public class WhiteCollarWageComponent : IRemunCalculationComponent
    {
        public IList<IRemunCalculationResult> Calculate(IContext context, ICalculationContext calculationContext)
        {
            var calculations = new List<IRemunCalculationResult>();

            var bruto = 0.0;

            //The bruto base salary for the employee
            var brutoSalary = context.PerformanceInformation.BaseSalary;
            //The number of days that the employee is supposed to work 
            var performanceBaseline = context.PerformanceInformation.PerformanceBaseline;
            //The amount of hours/day that the employee is supposed to work 
            var contractualHoursPerDay = context.PerformanceInformation.ContractualHoursPerDay;
            //The hourly rate for the employee
            var hourlyRateForEmployee = (brutoSalary / performanceBaseline) / contractualHoursPerDay;

            var performanceCodes = context.PerformanceInformation.Performances
                .Where(p=>
                    p.Type == PerformanceType.BusinessDay ||
                    p.Type == PerformanceType.Illness ||
                    p.Type == PerformanceType.WorkingHoliday ||
                    p.Type == PerformanceType.Holiday)
                .Select(p => p.Code)
                .Distinct();

            foreach (var performanceCode in performanceCodes)
            {
                var performances = context.PerformanceInformation.Performances.Where(p => p.Code == performanceCode);
                var hours = performances.Sum(p => p.Hours);
                var description = performances.FirstOrDefault()?.Description;
                var days = performances.Sum(p => p.Days);

                var value = hourlyRateForEmployee * hours;

                //Add a calculation result for this area
                calculations.Add(new RemunCalculationResult(performanceCode.ToString(), description,
                    days: days,
                    hours: hours,
                    value: value));

                bruto += value;
            }

            //Update the amount for further calculations
            calculationContext.AmountForCalculationArea = bruto;

            return calculations;
        }
    }
}
