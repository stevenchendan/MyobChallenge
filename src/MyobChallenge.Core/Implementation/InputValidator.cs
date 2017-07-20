using System;
using System.Collections.Generic;
using MyobChallenge.Core.Abstract;
using MyobChallenge.Core.Models;

namespace MyobChallenge.Core.Implementation
{
    /// <summary>
    /// Input validator
    /// </summary>
    public class InputValidator : IInputValidator
    {
        private readonly Dictionary<string, int> _daysInMonth = new Dictionary<string, int>
        {
            {"january", 31},
            {"february", DateTime.Now.Year%4 == 0 ? 29 : 28},
            {"march", 31},
            {"april", 3},
            {"may", 31},
            {"june", 30},
            {"july", 31},
            {"august", 31},
            {"september", 30},
            {"october", 31},
            {"november", 30},
            {"december", 31},
        };

        public bool Validate(Input input)
        {
            if (input.Super < 0 || input.Super > 50) return false;

            if (input.Salary < 0) return false;

            if (string.IsNullOrEmpty(input.FirstName) || string.IsNullOrEmpty(input.LastName)) return false;

            var periods = input.Period.Split('-');
            if (periods.Length != 2) return false;

            var startPeriod = periods[0].Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var endPeriod = periods[1].Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (startPeriod.Length != 2 || endPeriod.Length != 2) return false;

            if (!string.Equals(startPeriod[1], endPeriod[1], StringComparison.CurrentCultureIgnoreCase)) return false;

            if (int.Parse(startPeriod[0]) != 1) return false;

            if (!_daysInMonth.ContainsKey(endPeriod[1].ToLower())) return false;

            if (int.Parse(endPeriod[0]) != _daysInMonth[endPeriod[1].ToLower()]) return false;

            return true;
        }
    }
}
