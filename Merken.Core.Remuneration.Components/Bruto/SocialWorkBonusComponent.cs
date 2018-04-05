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
    public class SocialWorkBonusComponent : IRemunCalculationComponent
    {
        public IList<IRemunCalculationResult> Calculate(IContext context, ICalculationContext calculationContext)
        {
            var calculations = new List<IRemunCalculationResult>();
            var bruto = calculationContext.AmountForCalculationArea;

            var bonus = 0.0d;

            if (bruto <= 1501.82d)
            {
                switch (context.EmployeeInformation.EmployeeType)
                {
                    case Common.Enum.EmployeeType.WhiteCollar:
                        bonus = 183.97d;
                        break;
                    case Common.Enum.EmployeeType.BlueCollar:
                        bonus = 198.69d;
                        break;
                }
            }
            else if (1501.82d <= bruto && bruto <= 2385.41d)
            {
                switch (context.EmployeeInformation.EmployeeType)
                {
                    case Common.Enum.EmployeeType.WhiteCollar:
                        bonus = 183.97d - (0.2082 * (bruto - 1501.82d));
                        break;
                    case Common.Enum.EmployeeType.BlueCollar:
                        bonus = 198.69d - (0.2249 * (bruto - 1501.82d));
                        break;
                }
            }
            else if (2385.41d < bruto)
            {
                bonus = 0.0d;
            }

            calculations.Add(new RemunCalculationResult("SocialWorkBonus", "Sociale werkbonus", value: bonus));

            return calculations;
        }
    }
}
