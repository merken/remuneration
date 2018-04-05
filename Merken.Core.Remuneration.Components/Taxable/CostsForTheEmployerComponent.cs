using Merken.Core.Remuneration.Common;
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
    public class CostsForTheEmployerComponent : IRemunCalculationComponent
    {
        public IList<IRemunCalculationResult> Calculate(IContext context, ICalculationContext calculationContext)
        {
            var calculations = new List<IRemunCalculationResult>();

            var costs = 110.50d;

            if (context.EmployeeInformation.FirstName == "Jan")
            {
                costs = 110.50d;
            }

            if (context.EmployeeInformation.FirstName == "Peter")
            {
                costs = 150.00d;
            }

            calculations.Add(new RemunCalculationResult("CostsForTheEmployer", "Kosten eigen aan de werkgever", amount: 1, value: costs));

            return calculations;

        }
    }
}
