using Merken.Core.Remuneration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merken.Core.Remuneration.Common;
using Merken.Core.Remuneration.Models;
using Merken.Core.Remuneration.Common.Enum;

namespace Merken.Core.Remuneration.Tests.Repositories
{
    public class FakePerformanceRepositoryBlueCollar : IPerformanceRepository
    {
        public IPerformanceInformation GetPerformanceInformation(int employerId, int employeeId, DateTime? date = default(DateTime?))
        {
            var performanceInformation = new PerformanceInformation();

            //Adding 17 business days of work (8hr)
            for(int i = 0; i < 17; i++)
            {
                performanceInformation.Performances.Add(new Performance("000", description: "prestaties arbeider",
                days: 1,
                hours: 8.00,
                amount: 8.0,
                value: 12.00,
                type: PerformanceType.BusinessDay));
            }

            //Adding 5 business days of work (6hr)
            for (int i = 0; i < 5; i++)
            {
                performanceInformation.Performances.Add(new Performance("000", description: "prestaties arbeider",
                days: 1,
                hours: 6.00,
                amount: 6.0,
                value: 12.00,
                type: PerformanceType.BusinessDay));
            }

            //1 payed holiday
            performanceInformation.Performances.Add(new Performance("220", description: "Betaalde feestdag",
                days: 1,
                hours: 8.00,
                amount: 8.00,
                value: 12.00,
                type: PerformanceType.Holiday));

            return performanceInformation;
        }
    }

    public class FakePerformanceRepositoryWhiteCollar : IPerformanceRepository
    {
        public IPerformanceInformation GetPerformanceInformation(int employerId, int employeeId, DateTime? date = default(DateTime?))
        {
            //Setting up the base salary, baseline (23 days of performances) and hours per day according to the agreement
            var performanceInformation = new PerformanceInformation(baseSalary: 3000.00d, performanceBaseLine: 23.00d, contractualHoursPerDay: 8);

            //Adding 19 business days of work (8hr)
            for (int i = 0; i < 19; i++)
            {
                performanceInformation.Performances.Add(new Performance("000", description: "Werken",
                days: 1,
                hours: 8.00,
                amount: 8.00,
                type: PerformanceType.BusinessDay));
            }

            //Adding 19 days of compensation (working out of office, at the site of the client)
            for (int i = 0; i < 19; i++)
            {
                performanceInformation.Performances.Add(new Performance("010", description: "Bruto dagvergoeding",
                days: 1,
                hours: 8.00,
                amount: 8.00,
                value: 14.00,
                type: PerformanceType.BusinessDayOnSite));
            }

            //Adding 2 days of business travel, for a compensation of 50
            for (int i = 0; i < 2; i++)
            {
                performanceInformation.Performances.Add(new Performance("TRVL", description: "Forfaitaire verblijfsvergoeding",
                days: 1,
                amount: 1,
                value: 50,
                type: PerformanceType.BusinessTravel));
            }

            //4 days of illness
            for (int i = 0; i < 4; i++)
            {
                performanceInformation.Performances.Add(new Performance("220", description: "Maandloon ziekte",
                days: 1,
                hours: 8.00,
                amount: 8.00,
                type: PerformanceType.Illness));
            }

            return performanceInformation;
        }
    }

    public class FakePerformanceRepositoryWhiteCollar2 : IPerformanceRepository
    {
        public IPerformanceInformation GetPerformanceInformation(int employerId, int employeeId, DateTime? date = default(DateTime?))
        {
            //Setting up the base salary, baseline (23 days of performances) and hours per day according to the agreement
            var performanceInformation = new PerformanceInformation(baseSalary: 2844.64d, performanceBaseLine: 22.00d, contractualHoursPerDay: 8);

            //Adding 22 business days of work (8hr)
            for (int i = 0; i < 22; i++)
            {
                performanceInformation.Performances.Add(new Performance("000", description: "Werken",
                days: 1,
                hours: 8.00,
                amount: 8.00,
                type: PerformanceType.BusinessDay));
            }

            return performanceInformation;
        }
    }
}
