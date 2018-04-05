using Merken.Core.Remuneration.Common;
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
    public class MobilePhoneCompensationComponent : IRemunCalculationComponent
    {
        public IList<IRemunCalculationResult> Calculate(IContext context, ICalculationContext calculationContext)
        {
            var calculations = new List<IRemunCalculationResult>();
            var bruto = calculationContext.AmountForCalculationArea;

            //TODO add to context if the employee is eligable for compensation and add amount + value
            var amount = 1.0d;
            var compensation = 12.5d;
            var value = amount * compensation;

            calculations.Add(new RemunCalculationResult("MobilePhoneCompensation", "Bruto waarde GSM voordeel", amount: 1, value: value));

            //Add this value to the final bruto wage
            calculationContext.AmountForCalculationArea += value;

            return calculations;
        }
    }
}
