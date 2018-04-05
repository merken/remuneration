using Merken.Common.Interfaces;
using Merken.Core.Remuneration.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merken.Core.Remuneration.Interfaces
{
    public interface IRemunCalculationRepository : ICanBeResolved
    {
        /// <summary>
        /// Returns the IRemunCalculationComponents for the current assembly domain (via composition)
        /// </summary>
        /// <returns></returns>
        IList<IRemunCalculationComponent> GetRemunCalculationComponents();
    }
}
