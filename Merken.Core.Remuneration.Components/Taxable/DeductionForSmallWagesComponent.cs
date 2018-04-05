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
    public class DeductionForSmallWagesComponent : IRemunCalculationComponent
    {
        public IList<IRemunCalculationResult> Calculate(IContext context, ICalculationContext calculationContext)
        {
            var calculations = new List<IRemunCalculationResult>();
           
            if (calculationContext.AmountForCalculationArea <= 2291.80d)
            {
                calculations.Add(new RemunCalculationResult("DeductionForSmallWages", "Vermindering BV van 6.46", value: 6.46d));
            }

            return calculations;

        }
    }
}
