using Merken.Core.Remuneration.Common;
using Merken.Core.Remuneration.Models;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merken.Core.Remuneration.Components.Bruto
{
    [Export(typeof(IRemunCalculationComponent))]
    public class CompensationNaturaCompanyCarComponent : IRemunCalculationComponent
    {
        public IList<IRemunCalculationResult> Calculate(IContext context, ICalculationContext calculationContext)
        {
            var calculations = new List<IRemunCalculationResult>();
            var bruto = calculationContext.AmountForCalculationArea;

            //TODO VAA berekenen
            var contribution = 0.0d;

            if (context.EmployeeInformation.FirstName == "Jan")
            {
                contribution = 76.21d;
            }

            if (context.EmployeeInformation.FirstName == "Peter")
            {
                contribution = 175.22d;
            }

            calculations.Add(new RemunCalculationResult("CompensationNaturaCompanyCar", "Voordeel natura wagen", amount: 1, value: contribution));

            return calculations;
        }
    }
}
