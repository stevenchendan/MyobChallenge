using System.Collections.Generic;
using MyobChallenge.Core.Models;

namespace MyobChallenge.Core.Abstract
{
    /// <summary>
    /// Operations for getting/saving data
    /// </summary>
    public interface IDataOperations
    {
        /// <summary>
        /// Gets data
        /// </summary>
        /// <returns>Inputs</returns>
        IEnumerable<Input> GetData();

        /// <summary>
        /// Saves data
        /// </summary>
        /// <param name="data">Outputs</param>
        void SaveData(IEnumerable<Output> data);
    }
}
