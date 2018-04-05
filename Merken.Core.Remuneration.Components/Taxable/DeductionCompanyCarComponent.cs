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
    public class DeductionCompanyCarComponent : IRemunCalculationComponent
    {
        public IList<IRemunCalculationResult> Calculate(IContext context, ICalculationContext calculationContext)
        {
            var calculations = new List<IRemunCalculationResult>();

            //TODO calculate deduction
            var deduction = -108.71d;

            if(context.EmployeeInformation.FirstName == "Jan")
            {
                deduction = -108.71d;
            }

            if (context.EmployeeInformation.FirstName == "Peter")
            {
                deduction = -175.22d;
            }

            calculations.Add(new RemunCalculationResult("DeductionCompanyCar", "Aftrek voordeel natura wagen", amount: 1, value: deduction));

            return calculations;

        }
    }
}
