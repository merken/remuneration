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
    public class DeductionMobilePhoneComponent : IRemunCalculationComponent
    {
        public IList<IRemunCalculationResult> Calculate(IContext context, ICalculationContext calculationContext)
        {
            var calculations = new List<IRemunCalculationResult>();

            //TODO calculate deduction
            var deduction = -12.50;

            calculations.Add(new RemunCalculationResult("DeductionMobilePhone", "Aftrek voordeel natura GSM", amount: 1, value: deduction));

            return calculations;
        }
    }
}
