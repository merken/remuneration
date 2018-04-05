using Merken.Common;
using Merken.Common.Util;
using Merken.Core.Remuneration.Common;
using Merken.Core.Remuneration.Enum;
using Merken.Core.Remuneration.Interfaces;
using Merken.Core.Remuneration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Merken.Core.Remuneration.Services
{
    public class SalaryCalculationService : ISalaryCalculationService
    {
        public IList<IRemunCalculationResult> CalculateSalaryForEmployee(int employerId, int employeeId, DateTime? date = default(DateTime?))
        {
            //Repository injections
            var employeeRepo = IOCContainer.Resolve<IEmployeeRepository>();
            var employerRepo = IOCContainer.Resolve<IEmployerRepository>();
            var performanceRepo = IOCContainer.Resolve<IPerformanceRepository>();
            var remunRepo = IOCContainer.Resolve<IRemunerationRepository>();
            var componentRepo = IOCContainer.Resolve<IRemunCalculationRepository>();

            //Data retrieval
            var employee = employeeRepo.GetEmployeeInformation(employeeId, date);
            var employer = employerRepo.GetEmployerInformation(employerId, date);
            var performanceInformation = performanceRepo.GetPerformanceInformation(employerId, employeeId, date);
            var remunAreas = remunRepo.GetRemunerationAreas(employer);
            var components = componentRepo.GetRemunCalculationComponents();
            var remunComponentTypes = remunAreas.SelectMany(r => r.RemunComponents).Distinct();
            var remunCalculationComponents = components
                                                .Join(remunComponentTypes,
                                                    c => c.GetType().FullName?.ToLower(),
                                                    rc => rc.ComponentType?.ToLower(),
                                                    (c, rc) => c);

            var context = new SalaryCalculationContext(employer, employee, performanceInformation);
            var calculationResult = 0.0d;
            var remunCalculationResults = new List<IRemunCalculationResult>();

            //An area can be the following:
            //- Wage
            //- Bruto
            //- Taxable
            //- Netto
            //Loop through all areas, in order
            foreach (var area in remunAreas.OrderBy(a => a.Order))
            {
                //Create a context for the calculation and set the output of the previous calculation as the input of the current area
                var areaContext = new AreaCalculationContext
                {
                    AmountForCalculationArea = calculationResult
                };

                //Execute all the calculation components in order
                foreach (var remunComponent in area.RemunComponents.OrderBy(r => r.Order))
                {
                    var componentType = remunComponent.ComponentType;
                    var calculationComponent = remunCalculationComponents.FirstOrDefault(c => c.GetType()?.FullName.ToLower() == componentType?.ToLower());

                    if (calculationComponent == null)
                        throw new NotSupportedException($"Calculation of area {area.Description} failed, because remun component {componentType} was not found");

                    calculationComponent.Calculate(context, areaContext)
                        .ToList()
                        .ForEach(r => context.RemunCalculationResults.Add(r));
                }

                var newCalculationResult = 0.0;
                //Add all the results up to the input from this area, so it can be used for the next area
                foreach (var calculation in context.RemunCalculationResults)
                {
                    newCalculationResult += calculation.Value;
                }

                calculationResult = newCalculationResult;
            }

            return context.RemunCalculationResults;
        }

        private double ApplyRemunComponent(double input, IRemunComponent component)
        {
            var preCalc = input;

            if (component.PreCalculations.IsNotNullAndAny())
                foreach (var preCalculationComponent in component.PreCalculations)
                    preCalc += ApplyRemunComponent(input, preCalculationComponent);

            var amount = GetRemunAmount(preCalc, component.Amount, component.CalculationType);

            var postCalc = amount;
            switch (component.OperatorType)
            {
                case RemunOperatorType.Add:
                    if (component.PostCalculations.IsNotNullAndAny())
                        foreach (var postCalculationComponent in component.PostCalculations)
                            postCalc += ApplyRemunComponent(input, postCalculationComponent);

                    return postCalc;

                case RemunOperatorType.Subtract:
                    if (component.PostCalculations.IsNotNullAndAny())
                        foreach (var postCalculationComponent in component.PostCalculations)
                            postCalc += ApplyRemunComponent(input, postCalculationComponent);

                    return -postCalc;
            }

            return 0.0d;
        }

        private double GetRemunAmount(double input, double amount, RemunCalculationType calculationType)
        {
            switch (calculationType)
            {
                case RemunCalculationType.Percentage:
                    return input *= amount;

                case RemunCalculationType.Fixed:
                    return amount;
            }

            return 0.0d;
        }
    }
}
