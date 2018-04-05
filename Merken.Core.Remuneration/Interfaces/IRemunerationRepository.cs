using Merken.Common.Interfaces;
using Merken.Core.Remuneration.Common;
using Merken.Core.Remuneration.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merken.Core.Remuneration.Interfaces
{
    public interface IRemunerationRepository : ICanBeResolved
    {
        /// <summary>
        /// Gets the remuneration areas for a specific employer.
        /// </summary>
        /// <param name="employerInformation">Information regarding the employer</param>
        /// <param name="date"></param>
        /// <returns>A list of areas, including their remuncomponents.</returns>
        List<IRemunArea> GetRemunerationAreas(IEmployerInformation employerInformation, DateTime? date = default(DateTime?));

        /// <summary>
        /// Get the remuneration components for a specific employee based on its information and the date of the calculation.
        /// </summary>
        /// <param name="employeeInformation">Information regarding the employee.</param>
        /// <param name="date">Date of the calculation, if none provided, this will be DateTime.Now</param>
        /// <returns>A list of all the applicable remuneration components.</returns>
        List<IRemunComponent> GetRemunerationComponents(IEmployeeInformation employeeInformation, DateTime? date = default(DateTime?));
    }
}
