using System.Collections.Generic;
using System.IO;
using System.Linq;
using MyobChallenge.Core.Abstract;
using MyobChallenge.Core.Models;

namespace MyobChallenge.Core.Implementation
{
    /// <summary>
    /// Operating data in CSV files
    /// </summary>
    public class CsvDataOperations : IDataOperations
    {
        private readonly string _inputFile;
        private readonly string _outputFile;

        /// <summary>
        /// Ctr
        /// </summary>
        /// <param name="inputFile">Input file path</param>
        /// <param name="outputFile">Output file path</param>
        public CsvDataOperations(string inputFile, string outputFile)
        {
            _inputFile = inputFile;
            _outputFile = outputFile;
        }

        public IEnumerable<Input> GetData()
        {
            var lines = File.ReadAllLines(_inputFile);
            return lines.Select(x => x.Split(',')).Select(x => new Input
            {
                FirstName = x[0],
                LastName = x[1],
                Salary = int.Parse(x[2]),
                Super = int.Parse(x[3].Replace("%", "")),
                Period = x[4]
            }).ToList();
        }

        public void SaveData(IEnumerable<Output> data)
        {
            var lines = data.Select(x => $"{x.FullName},{x.Period},{x.Gross},{x.Tax},{x.Net},{x.Super}");
            File.WriteAllLines(_outputFile, lines);
        }
    }
}
