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
    /// <summary>
    /// This component will calculate the employee contribution on top of the bruto wage.
    /// </summary>
    [Export(typeof(IRemunCalculationComponent))]
    public class SocialSecurityComponent : IRemunCalculationComponent
    {
        public IList<IRemunCalculationResult> Calculate(IContext context, ICalculationContext calculationContext)
        {
            var calculations = new List<IRemunCalculationResult>();
            var bruto = calculationContext.AmountForCalculationArea;

            var contributionPct = 1d;

            if (context.EmployeeInformation.EmployeeType == Common.Enum.EmployeeType.BlueCollar)
                contributionPct = 1.08d;

            bruto = bruto * contributionPct;

            var contribution = -(bruto * 13.07 / 100);

            calculations.Add(new RemunCalculationResult("RSZ", "RSZ bijdrage", value: contribution));

            return calculations;
        }
    }
}
