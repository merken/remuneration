using Merken.Core.Remuneration.Common;
using Merken.Core.Remuneration.Common.Enum;
using Merken.Core.Remuneration.Models;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merken.Core.Remuneration.Components.Taxable
{
    [Export(typeof(IRemunCalculationComponent))]
    public class CompensationForBusinessTravelComponent : IRemunCalculationComponent
    {
        public IList<IRemunCalculationResult> Calculate(IContext context, ICalculationContext calculationContext)
        {
            var calculations = new List<IRemunCalculationResult>();

            var businessTravels = context.PerformanceInformation.Performances.Where(p => p.Type == PerformanceType.BusinessTravel);
            //Todo grouping
            if (businessTravels.Any())
            {
                var businessTravel = businessTravels.FirstOrDefault();
                var amountOfTravels = businessTravels.Count();
                var value = amountOfTravels * businessTravel.Value;

                calculations.Add(new RemunCalculationResult(businessTravel.Code.ToString(), businessTravel.Description,
                   amount: amountOfTravels,
                   value: value));
            }

            return calculations;
        }
    }
}
