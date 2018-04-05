using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merken.Core.Remuneration.Common
{
    /// <summary>
    /// This class represents a calculation on top of the remuneration.
    /// To create a new calculation, inherit this interface and provide an implementation for the Calculate method.
    /// The calculation engine will scan all implementations of this interface through reflection and execute them for each calculation area, in order.
    /// Please see Merken.Core.Remuneration.Interfaces.RemunComponent.
    /// The ComponentType will link to an implementation of this class, which is resolved via reflection.
    /// </summary>
    public interface IRemunCalculationComponent
    {
        /// <summary>
        /// This method will be called from the calculation engine, the context and calculation context will be injected.
        /// The implementation can access theses contexts in a read-only fashion.
        /// 
        /// </summary>
        /// <param name="context">The general context, this contains information regarding the employee, employer and the performances delivered by that employee for the employer.</param>
        /// <param name="calculationContext">The context for the current calculation area.
        /// These areas can be :
        /// - Bruto
        /// - Taxable
        /// - Netto
        /// 
        /// In case the amount needs to be adjusted (addition, subtraction), the implementation is allowed to do so.
        /// </param>
        /// <returns>A calculation result, which translates in a line on the employee payslip.</returns>
        IList<IRemunCalculationResult> Calculate(IContext context, ICalculationContext calculationContext);
    }
}
