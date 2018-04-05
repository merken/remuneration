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
    public class ChildrenOnChargeComponent : IRemunCalculationComponent
    {
        public IList<IRemunCalculationResult> Calculate(IContext context, ICalculationContext calculationContext)
        {
            var calculations = new List<IRemunCalculationResult>();
            var bruto = calculationContext.AmountForCalculationArea;

            var childrenOnCharge = context.EmployeeInformation.NumberOfChildrenOnCharge;
            var amount = 92.00d;

            calculations.Add(new RemunCalculationResult("ChildrenOnCharge", "vermindering BV voor kinderen ten laste", value: amount));

            return calculations;
        }
    }
}
