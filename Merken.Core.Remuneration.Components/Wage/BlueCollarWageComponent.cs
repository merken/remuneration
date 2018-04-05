using Merken.Core.Remuneration.Common;
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
    public class BlueCollarWageComponent : IRemunCalculationComponent
    {
        public IList<IRemunCalculationResult> Calculate(IContext context, ICalculationContext calculationContext)
        {
            var calculations = new List<IRemunCalculationResult>();

            var bruto = 0.0;

            var performanceCodes = context.PerformanceInformation.Performances.Select(p => p.Code).Distinct();
            foreach (var performanceCode in performanceCodes)
            {
                var performances = context.PerformanceInformation.Performances.Where(p => p.Code == performanceCode);

                var wage = performances.FirstOrDefault()?.Value;
                var description = performances.FirstOrDefault()?.Description;
                var hours = performances.Sum(p => p.Hours);
                var days = performances.Sum(p => p.Days);
                var value = hours * wage;

                //Add a calculation result for this area
                calculations.Add(new RemunCalculationResult(performanceCode.ToString(), description,
                    days: days,
                    hours: hours,
                    value: value.HasValue ? value.Value : 0));

                bruto += value.HasValue ? value.Value : 0.0;
            }

            //Update the amount for further calculations
            calculationContext.AmountForCalculationArea = bruto;

            return calculations;
        }
    }
}
