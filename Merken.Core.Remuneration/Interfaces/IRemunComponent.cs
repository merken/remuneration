using Merken.Core.Remuneration.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merken.Core.Remuneration.Interfaces
{
    public interface IRemunComponent
    {
        int Order { get; set; }
        string Description { get; set; }
        RemunType RemunType { get; set; }
        RemunOperatorType OperatorType { get; set; }
        RemunCalculationType CalculationType { get; set; }
        double Amount { get; set; }
        List<IRemunComponent> PreCalculations { get; set; }
        List<IRemunComponent> PostCalculations { get; set; }
        string ComponentType { get; set; }
    }
}
