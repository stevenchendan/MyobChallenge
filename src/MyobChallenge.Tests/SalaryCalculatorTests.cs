using System;
using System.Collections.Generic;
using MyobChallenge.Core.Implementation;
using MyobChallenge.Core.Models;
using NUnit.Framework;

namespace MyobChallenge.Tests
{
    [TestFixture]
    public class SalaryCalculatorTests
    {
        private SalaryCalculator _salaryCalculator;

        [SetUp]
        public void SetUp()
        {
            var taxes = new List<TaxOption>
            {
                new TaxOption(0, 18200, 0, 0),
                new TaxOption(18201, 37000, 0, 19),
                new TaxOption(37001, 80000, 3572, 32.5),
                new TaxOption(80001, 180000, 17547, 37),
                new TaxOption(180001, int.MaxValue, 54457, 45)
            };

            _salaryCalculator = new SalaryCalculator(taxes);
        }

        [TestCase(0)]
        [TestCase(1000)]
        [TestCase(11000)]
        [TestCase(18000)]
        [TestCase(18200)]
        public void Calculate_OnLowSalary_NoTaxes(int salary)
        {
            var result = _salaryCalculator.Calculate(new Input
            {
                Salary = salary
            });

            Assert.AreEqual(0, result.Tax);
            Assert.AreEqual(0, result.Super);
            Assert.AreEqual(Math.Round(salary / 12d, MidpointRounding.AwayFromZero), result.Gross);
            Assert.AreEqual(result.Gross, result.Net);
        }

        [TestCase(60050, 9, 5004, 922, 450)]
        [TestCase(120000, 1, 10000, 2696, 100)]
        [TestCase(190000, 15, 15833, 4913, 2375)]
        [TestCase(18000, 50, 1500, 0, 750)]
        [TestCase(180000, 0, 15000, 4546, 0)]
        [TestCase(180001, 3, 15000, 4538, 450)]
        public void Calculate_OnSalaryAndSuper_CorrectResult(int salary, int super, int expectedGross, int expectedTax, int expectedSuper)
        {
            var result = _salaryCalculator.Calculate(new Input
            {
                Salary = salary,
                Super = super
            });

            Assert.AreEqual(expectedTax, result.Tax);
            Assert.AreEqual(expectedSuper, result.Super);
            Assert.AreEqual(expectedGross, result.Gross);
            Assert.AreEqual(expectedGross - expectedTax, result.Net);
        }
    }
}
