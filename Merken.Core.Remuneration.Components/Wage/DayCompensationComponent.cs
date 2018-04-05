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
    [Export(typeof(IRemunCalculationComponent))]
    public class DayCompensationComponent : IRemunCalculationComponent
    {
        public IList<IRemunCalculationResult> Calculate(IContext context, ICalculationContext calculationContext)
        {
            var calculations = new List<IRemunCalculationResult>();

            var dayCompensations = context.PerformanceInformation.Performances.Where(p => p.Type == PerformanceType.BusinessDayOnSite);

            //TODO group by value
            if (dayCompensations.Any())
            {
                var amountOfDays = dayCompensations.Count();
                var compensationRate = dayCompensations.FirstOrDefault().Value;
                var value = amountOfDays * compensationRate;

                calculations.Add(new RemunCalculationResult("DayCompensation", "Bruto Dagvergoeding", value: value));

                //Add this value to the final bruto wage
                calculationContext.AmountForCalculationArea += value;
            }

            return calculations;
        }
    }
}
