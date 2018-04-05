using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merken.Core.Remuneration.Interfaces
{
    /// <summary>
    /// This represents a remuneration calculation area.
    /// Examples of an area are:
    /// - Bruto
    /// - Taxable
    /// - Netto
    /// </summary>
    public interface IRemunArea
    {
        /// <summary>
        /// The order of the remuneration area.
        /// Example:
        /// - Bruto     : 100
        /// - Taxable   : 200
        /// - Netto     : 300
        /// </summary>
        int Order { get; set; }

        /// <summary>
        /// Description of the area (human readable)
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// The components related to this area.
        /// </summary>
        IList<IRemunComponent> RemunComponents { get; set; }
    }
}
