using Merken.Core.Remuneration.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merken.Core.Remuneration.Models
{
    public class RemunCalculationResult : IRemunCalculationResult
    {
        public RemunCalculationResult(string code, string description, double days = 0, double hours = 0, double amount = 0, double value = 0)
        {
            this.Code = code;
            this.Description = description;
            this.Days = days;
            this.Hours = hours;
            this.Amount = amount;
            this.Value = Math.Round(value, 2);
        }

        public string Code { get; }

        public string Description { get; }

        public double Days { get; }

        public double Hours { get; }

        public double Amount { get; }

        public double Value { get; }
    }
}
