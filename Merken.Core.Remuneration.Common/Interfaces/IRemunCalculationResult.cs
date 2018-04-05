using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merken.Core.Remuneration.Common
{
    public interface IRemunCalculationResult
    {
        string Code { get; }

        string Description { get; }

        double Days { get; }

        double Hours { get; }

        double Amount { get; }

        double Value { get; }
    }
}
