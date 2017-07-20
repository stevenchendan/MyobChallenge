using MyobChallenge.Core.Models;

namespace MyobChallenge.Core.Abstract
{
    /// <summary>
    /// Salary calculator interface
    /// </summary>
    public interface ISalaryCalculator
    {
        /// <summary>
        /// Calculates salary and tax
        /// </summary>
        /// <param name="input">Input model</param>
        /// <returns>Output model</returns>
        Output Calculate(Input input);
    }
}
