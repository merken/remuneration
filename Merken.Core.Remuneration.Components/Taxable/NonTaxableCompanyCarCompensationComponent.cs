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
    public class NonTaxableCompanyCarCompensationComponent : IRemunCalculationComponent
    {
        public IList<IRemunCalculationResult> Calculate(IContext context, ICalculationContext calculationContext)
        {
            var calculations = new List<IRemunCalculationResult>();

            //TODO calculate compensation
            var compensation = 32.50d;

            calculations.Add(new RemunCalculationResult("NonTaxableCompanyCarCompensation", "Onbelast voordeel natura wagen", amount: 1, value: compensation));

            return calculations;

        }
    }
}
