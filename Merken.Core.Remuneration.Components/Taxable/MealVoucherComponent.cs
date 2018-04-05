using Merken.Core.Remuneration.Common;
using Merken.Core.Remuneration.Common.Enum;
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
    public class MealVoucherComponent : IRemunCalculationComponent
    {
        public IList<IRemunCalculationResult> Calculate(IContext context, ICalculationContext calculationContext)
        {
            var calculations = new List<IRemunCalculationResult>();

            var amountOfMealVouchers = context.PerformanceInformation.Performances.Count(p =>
                //1 mealvoucher per business day, or a day in the weekend or working on a holiday
                (p.Type == PerformanceType.BusinessDay || p.Type == PerformanceType.Weekend || p.Type == PerformanceType.WorkingHoliday)
                //Only in case the employee worked 4 hours or more
                && p.Hours >= 4);

            //TODO Get the meal voucher rate from the context
            var mealVoucherValue = 0.0d;

            if (context.EmployeeInformation.FirstName == "Jan")
            {
                mealVoucherValue = 1.24;
            }

            if (context.EmployeeInformation.FirstName == "Steven")
            {
                mealVoucherValue = 1.12;
            }

            calculations.Add(new RemunCalculationResult("MealVoucher", "Afhouding maaltijdcheques", value: -(amountOfMealVouchers * mealVoucherValue)));

            return calculations;
        }
    }
}
