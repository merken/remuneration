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
    public class SpecialContributionForSocialSecurityComponent : IRemunCalculationComponent
    {
        public IList<IRemunCalculationResult> Calculate(IContext context, ICalculationContext calculationContext)
        {
            var calculations = new List<IRemunCalculationResult>();

            var isPersonAllowedForSpecialContribution = true;
            if (isPersonAllowedForSpecialContribution)
            {
                if (context.EmployeeInformation.FirstName == "Jan")
                {
                    calculations.Add(new RemunCalculationResult("SpecialContributionForSocialSecurity", "Bijzondere bijdrage voor de sociale zekerheid", value: -(2.77d)));
                }

                if (context.EmployeeInformation.FirstName == "Peter")
                {
                    calculations.Add(new RemunCalculationResult("SpecialContributionForSocialSecurity", "Bijzondere bijdrage voor de sociale zekerheid", value: -(25.80d)));
                }

                if (context.EmployeeInformation.FirstName == "Steven")
                {
                    calculations.Add(new RemunCalculationResult("SpecialContributionForSocialSecurity", "Bijzondere bijdrage voor de sociale zekerheid", value: -(19.31d)));
                }
            }

            return calculations;
        }
    }
}
