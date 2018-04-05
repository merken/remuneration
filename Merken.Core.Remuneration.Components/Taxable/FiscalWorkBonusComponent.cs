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
    public class FiscalWorkBonusComponent : IRemunCalculationComponent
    {
        public IList<IRemunCalculationResult> Calculate(IContext context, ICalculationContext calculationContext)
        {
            var calculations = new List<IRemunCalculationResult>();
            var bruto = calculationContext.AmountForCalculationArea;

            var socialWorkBonus = context.RemunCalculationResults.FirstOrDefault(r => r.Code == "SocialWorkBonus");

            if (socialWorkBonus != null)
            {
                var fiscalWorkBonus = socialWorkBonus.Value * 0.1440;
                calculations.Add(new RemunCalculationResult("FiscalWorkBonus", "Fiscale werkbonus", value: fiscalWorkBonus));

            }

            return calculations;
        }
    }
}
