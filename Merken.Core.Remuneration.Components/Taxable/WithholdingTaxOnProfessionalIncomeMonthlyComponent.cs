﻿using Merken.Core.Remuneration.Common;
using Merken.Core.Remuneration.Models;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merken.Core.Remuneration.Components.Taxable
{
    /// <summary>
    /// Withholding Tax On Professional Income
    /// Bedrijfsvoorheffing (2017)
    /// </summary>
    [Export(typeof(IRemunCalculationComponent))]
    public class WithholdingTaxOnProfessionalIncomeMonthlyComponent : IRemunCalculationComponent
    {
        public IList<IRemunCalculationResult> Calculate(IContext context, ICalculationContext calculationContext)
        {
            var calculations = new List<IRemunCalculationResult>();
            var taxableWage = calculationContext.AmountForCalculationArea;
            var payrollTax = 0.0d;

            //Calculate annual bruto income
            var annualBrutoWage = CalculateLeastCommonDenominator(context, calculationContext, taxableWage, 15.00d) * 12; // 

            //Calculate worker taxes
            var workerTaxes = CalculateWorkerTaxes(context, calculationContext, annualBrutoWage);

            //Netto annual wage = bruto - taxes
            var annualNettoWage = annualBrutoWage - workerTaxes;

            //Calculate basic taxes
            var basicTaxes = CalculateBasicTaxes(context, calculationContext, annualNettoWage);

            //Calculate deductions on basic taxes
            var deductions = CalculateDeductions(context, calculationContext);

            var annualTaxes = basicTaxes + deductions;

            payrollTax = annualTaxes / 12;

            calculations.Add(new RemunCalculationResult("BVH", "Bedrijfsvoorheffing", value: -payrollTax));

            return calculations;
        }

        /// <summary>
        /// This calculation will take the bruto wage and round it down to the lowest dividend of 15.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="calculationContext"></param>
        /// <param name="brutoWage"></param>
        /// <param name="dividendBase"></param>
        /// <returns></returns>
        private double CalculateLeastCommonDenominator(IContext context, ICalculationContext calculationContext, double brutoWage, double dividendBase = 15.00d)
        {
            //First take the dividend  for the current wage without rest
            var dividend = Math.Floor(brutoWage / dividendBase);
            //Next, calculate the bruto wage according to this scale
            var brutoWageAccordingToDivided = dividend * dividendBase;

            return brutoWageAccordingToDivided;
        }

        /// <summary>
        /// Based on the type of worker (employee, self employed, company directors, ...)
        /// </summary>
        /// <param name="context"></param>
        /// <param name="calculationContext"></param>
        /// <param name="annualBrutoWage"></param>
        /// <returns></returns>
        private double CalculateWorkerTaxes(IContext context, ICalculationContext calculationContext, double annualBrutoWage)
        {
            var workerTaxes = 0.0d;

            if (true) //Check if employee is an employee
            {
                workerTaxes = CalculateWorkerTaxesForEmployee(context, calculationContext, annualBrutoWage);
            }
            else if (true)//Check if employee is a company director
            {
                workerTaxes = CalculateWorkerTaxesForCompanyDirector(context, calculationContext, annualBrutoWage);
            }

            return workerTaxes;
        }

        private double CalculateWorkerTaxesForEmployee(IContext context, ICalculationContext calculationContext, double annualBrutoWage)
        {
            var workerTaxes = 0.0d;

            if (annualBrutoWage < 8620.00d)
            {
                //30pct
                workerTaxes = annualBrutoWage * 0.30;
            }
            else if (8260.00d <= annualBrutoWage && annualBrutoWage < 20360.00d)
            {
                //2586.00 + 11pct of anything above 8260.00d
                workerTaxes = 2586.00 + (annualBrutoWage - 8260.00d) * 0.11;

            }
            else if (20360.00d <= annualBrutoWage && annualBrutoWage < 35133.33d)
            {
                //2586.00 + 3pct of anything above 20360.00d
                workerTaxes = 3877.40 + (annualBrutoWage - 20360.00d) * 0.03;
            }
            else if (35133.33d <= annualBrutoWage)
            {
                workerTaxes = 4320.00d;
            }

            return workerTaxes;
        }

        private double CalculateWorkerTaxesForCompanyDirector(IContext context, ICalculationContext calculationContext, double annualBrutoWage)
        {
            var workerTaxes = 0.0d;

            if (annualBrutoWage < 81333.33d)
            {
                //3pct
                workerTaxes = annualBrutoWage * 0.03;
            }
            else if (81333.33d <= annualBrutoWage)
            {
                //2586.00 + 11pct of anything above 8260.00d
                workerTaxes = 2440.00d;
            }

            return workerTaxes;
        }

        /// <summary>
        /// Calculates the basic taxes (second scale of calculation, the basic scale)
        /// </summary>
        /// <param name="context"></param>
        /// <param name="calculationContext"></param>
        /// <param name="annualNettoWage"></param>
        /// <returns></returns>
        private double CalculateBasicTaxes(IContext context, ICalculationContext calculationContext, double annualNettoWage)
        {
            var basicTaxes = 0.0d;

            if (true) //Check if employee is a belgian citizen
            {
                basicTaxes = CalculateBasicTaxesForCitizens(context, calculationContext, annualNettoWage);
            }
            else if (true)//employee is not a citizen, 
            {
                basicTaxes = CalculateBasicTaxesByScale(context, calculationContext, annualNettoWage);
            }

            return Math.Round(basicTaxes, 2);
        }

        private double CalculateBasicTaxesByScale(IContext context, ICalculationContext calculationContext, double annualNettoWage)
        {
            var taxesByScale = 0.0d;
            if (0.01d <= annualNettoWage && annualNettoWage < 11070.00d)
            {
                taxesByScale = annualNettoWage * 0.2675;
            }
            else if (11070.00d <= annualNettoWage && annualNettoWage < 12140.00d)
            {
                taxesByScale = 2961.23 + ((annualNettoWage - 11070.00d) * 0.3210);
            }
            else if (12140.00d <= annualNettoWage && annualNettoWage < 17590.00d)
            {
                taxesByScale = 3304.70 + ((annualNettoWage - 12140.00d) * 0.4280);
            }
            else if (17590.00d <= annualNettoWage && annualNettoWage < 38840.00d)
            {
                taxesByScale = 5637.30 + ((annualNettoWage - 17590.00d) * 0.4815);
            }
            else if (38840.00d <= annualNettoWage)
            {
                taxesByScale = 15869.18 + ((annualNettoWage - 38840.00d) * 0.5350);
            }

            return taxesByScale;
        }

        private double CalculateBasicTaxesForCitizens(IContext context, ICalculationContext calculationContext, double annualNettoWage)
        {
            var basicTaxes = 0.0d;

            if (true)//Check if employee is independend or has no partner on its charge
            {
                basicTaxes = CalculateBasicTaxesForIndependendOrUnchargedPartner(context, calculationContext, annualNettoWage);
                //Deduction for belgian citizens
                basicTaxes -= 1655.83d;
            }
            else if (true)//The partner is on the employee's charge
            {
                //TODO
                //Subcalucation based on 30pct of the annualBrutoWage
                //max = 10490.00d
                //CalculateBasicTaxesByScale
                //difference between two result (from employee and partner) is subtracted
                //basicTaxes = Addition - 3311.66d
            }

            return basicTaxes;
        }

        private double CalculateBasicTaxesForIndependendOrUnchargedPartner(IContext context, ICalculationContext calculationContext, double annualNettoWage)
        {
            var taxesByScale = 0.0d;
            if (0.01d <= annualNettoWage && annualNettoWage < 11070.00d)
            {
                taxesByScale = annualNettoWage * 0.2675;
            }
            else if (11070.00d <= annualNettoWage && annualNettoWage < 12140.00d)
            {
                taxesByScale = 2961.23 + ((annualNettoWage - 11070.00d) * 0.3210);
            }
            else if (12140.00d <= annualNettoWage && annualNettoWage < 17590.00d)
            {
                taxesByScale = 3304.70 + ((annualNettoWage - 12140.00d) * 0.4280);
            }
            else if (17590.00d <= annualNettoWage && annualNettoWage < 38840.00d)
            {
                taxesByScale = 5637.30 + ((annualNettoWage - 17590.00d) * 0.4815);
            }
            else if (38840.00d <= annualNettoWage)
            {
                taxesByScale = 15869.18 + ((annualNettoWage - 38840.00d) * 0.5350);
            }

            return taxesByScale;
        }

        private double CalculateBasicTaxesDeductionOnBasicTaxes(IContext context, ICalculationContext calculationContext, double basicTaxes)
        {
            var basicTaxesWithDeduction = basicTaxes;
            if (true) //TODO Check from context whether the employee is an inhabitant of Belgium
            {
                if (true) //TODO Check from context whether the employee is single or has a partner with his/her own income (not on charge)
                {
                    basicTaxesWithDeduction -= 1655.83d;
                }
                else
                {
                    //Subcalucation based on 30pct of the annualBrutoWage
                    //max = 10490.00d
                    //calc
                }
            }
            else //The inhabitant is not a citizen of Belgium
            {
                //for reference, nothing changes
                basicTaxesWithDeduction = basicTaxes;
            }

            return basicTaxesWithDeduction;
        }

        private double CalculateDeductions(IContext context, ICalculationContext calculationContext)
        {
            var deductions = 0.0d;

            if (true) //Check if employee is a belgian citizen
            {
                deductions = CalculateDeductionsForCitizens(context, calculationContext);
            }
            else if (true)//employee is not a citizen, 
            {
                deductions = CalculateDeductionsForNonCitizens(context, calculationContext);
            }

            deductions = Math.Round(deductions, 2);

            if (false) //Employee is employed
            {
                if (deductions <= 2417.96)
                {
                    deductions -= 77.52d;
                }
            }
            else if (false) //Employee is company director
            {
                if (deductions <= 2157.12d)
                {
                    deductions -= 77.52d;
                }
            }

            return Math.Round(deductions, 2);
        }

        private double CalculateDeductionsForCitizens(IContext context, ICalculationContext calculationContext)
        {
            var deductions = 0.0d;

            //charges on family
            if (true)
            {
                deductions += CalculateDeductionForChargesOfFamily(context, calculationContext);
            }

            if (context.EmployeeInformation.NumberOfChildrenOnCharge > 0)//Check if any children on charge
            {
                deductions += CalculateDeductionChildrenOnCharge(context, calculationContext);
            }

            //personal contributions

            //overtime

            //low income

            //low income govornment sector

            //working bonus

            return deductions;
        }

        private double CalculateDeductionsForNonCitizens(IContext context, ICalculationContext calculationContext)
        {
            var deductions = 0.0d;

            if (false)//Employee has group insurance
            {

            }

            if (false)//Employee has insurance for old age or premature death
            {

            }

            if (false)//Employee has pension arrangement
            {

            }

            if (false)//Employee has overtime bonus
            {

            }

            if (false)//Employee has workbonus
            {

            }

            return deductions;
        }

        private double CalculateDeductionChildrenOnCharge(IContext context, ICalculationContext calculationContext)
        {
            var deduction = 0.0d;
            var numberOfChildrenOnCharge = context.EmployeeInformation.NumberOfChildrenOnCharge - context.EmployeeInformation.NumberOfChildrenOnChargeWithHandicap;
            var numberOfChildrenOnChargeWithHandicap = context.EmployeeInformation.NumberOfChildrenOnChargeWithHandicap;

            deduction = CalculateDeductionChildrenOnChargeScale(numberOfChildrenOnCharge);
            //Child with handicap *2
            deduction += CalculateDeductionChildrenOnChargeScale(numberOfChildrenOnChargeWithHandicap) * 2;

            return deduction;
        }

        private double CalculateDeductionChildrenOnChargeScale(int numberOfChildrenOnCharge)
        {
            var deduction = 0.0d;
            switch (numberOfChildrenOnCharge)
            {
                case 0:
                    deduction = 0.0d;
                    break;
                case 1:
                    deduction = 420.00d;
                    break;
                case 2:
                    deduction = 1140.00d;
                    break;
                case 3:
                    deduction = 2976.00d;
                    break;
                case 4:
                    deduction = 5448.00d;
                    break;
                case 5:
                    deduction = 8052.00d;
                    break;
                case 6:
                    deduction = 10644.00d;
                    break;
                case 7:
                    deduction = 13260.00d;
                    break;
                case 8:
                    deduction = 16128.00d;
                    break;
                default: //more than 8
                    var numberOfChildrenOver8 = numberOfChildrenOnCharge - 8;
                    deduction = 16128.00d + (2952.00d * numberOfChildrenOver8);
                    break;
            }

            return -deduction;
        }

        private double CalculateDeductionForChargesOfFamily(IContext context, ICalculationContext calculationContext)
        {
            var deduction = 0.0d;

            if (true)//is single or partner has income
            {
                deduction = CalculateDeductionForChargesOfFamilySingleOrPartnerIncome(context, calculationContext);
            }
            else if (false)//partner has no income
            {
                deduction = CalculateDeductionForChargesOfFamilyPartnerNoIncome(context, calculationContext);
            }

            return deduction;
        }

        private double CalculateDeductionForChargesOfFamilySingleOrPartnerIncome(IContext context, ICalculationContext calculationContext)
        {
            var deduction = 0.0d;

            if (false)//Employee is single or Partner has income
            {
                deduction = -300.0d;
            }

            return deduction;
        }

        private double CalculateDeductionForChargesOfFamilyPartnerNoIncome(IContext context, ICalculationContext calculationContext)
        {
            var deduction = 0.0d;

            //TODO

            return deduction;
        }

    }
}
