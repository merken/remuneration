using Merken.Core.Remuneration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merken.Core.Remuneration.Models
{
    public class RemunArea : IRemunArea
    {
        public int Order { get; set; }

        public string Description { get; set; }

        public IList<IRemunComponent> RemunComponents { get; set; }
    }
}
