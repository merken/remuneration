using Merken.Core.Remuneration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merken.Core.Remuneration.Enum;

namespace Merken.Core.Remuneration.Models
{
    public class RemunComponent : IRemunComponent
    {
        public double Amount { get; set; }

        public RemunCalculationType CalculationType { get; set; }

        public string Description { get; set; }

        public RemunOperatorType OperatorType { get; set; }

        public int Order { get; set; }

        public RemunType RemunType { get; set; }

        public List<IRemunComponent> PreCalculations { get; set; }

        public List<IRemunComponent> PostCalculations { get; set; }

        public string ComponentType { get; set; }

    }
}
