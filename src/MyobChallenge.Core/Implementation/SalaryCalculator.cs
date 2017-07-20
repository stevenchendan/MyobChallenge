using System;
using System.Collections.Generic;
using System.Linq;
using MyobChallenge.Core.Abstract;
using MyobChallenge.Core.Models;

namespace MyobChallenge.Core.Implementation
{
    /// <summary>
    /// Salary calculator
    /// </summary>
    public class SalaryCalculator : ISalaryCalculator
    {
        private readonly IEnumerable<TaxOption> _taxOptions;

        /// <summary>
        /// Ctr
        /// </summary>
        /// <param name="taxOptions">Tax options</param>
        public SalaryCalculator(IEnumerable<TaxOption> taxOptions)
        {
            _taxOptions = taxOptions;
        }

        public Output Calculate(Input input)
        {
            var taxOption = _taxOptions.Single(x => x.Min <= input.Salary && x.Max >= input.Salary);

            var additionalTax = (input.Salary - (taxOption.Min > 0 ? taxOption.Min - 1 : 0)) * taxOption.CentsOnEachDollar * 0.01;
            var totalTax = taxOption.BaseTax + additionalTax;

            var gross = (int)Math.Round(input.Salary/12d, MidpointRounding.AwayFromZero);
            var tax = (int)Math.Round(totalTax/12d, MidpointRounding.AwayFromZero);
            var net = gross - tax;
            var super = (int)Math.Round(gross * input.Super * 0.01, MidpointRounding.AwayFromZero);

            return new Output
            {
                FullName = input.FirstName + " " + input.LastName,
                Gross = gross,
                Tax = tax,
                Net = net,
                Super = super,
                Period = input.Period
            };
        }
    }
}
