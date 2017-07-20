using MyobChallenge.Core.Models;

namespace MyobChallenge.Core.Abstract
{
    /// <summary>
    /// Input validator interface
    /// </summary>
    public interface IInputValidator
    {
        /// <summary>
        /// Validates input object
        /// </summary>
        /// <param name="input">Input object</param>
        /// <returns>Valid or not</returns>
        bool Validate(Input input);
    }
}
