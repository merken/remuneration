using Merken.Core.Remuneration.Common;
using Merken.Core.Remuneration.Models;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merken.Core.Remuneration.Components.Netto
{
    [Export(typeof(IRemunCalculationComponent))]
    public class AdvancesComponent : IRemunCalculationComponent
    {
        public IList<IRemunCalculationResult> Calculate(IContext context, ICalculationContext calculationContext)
        {
            var calculations = new List<IRemunCalculationResult>();

            //TODO get the advances from the context

            if (context.EmployeeInformation.FirstName == "Jan")
            {
                calculations.Add(new RemunCalculationResult("Advances", "Voorschot", value: -(1700.00d)));
            }

            if (context.EmployeeInformation.FirstName == "Steven")
            {
            }

            return calculations;
        }
    }
}
