using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MyobChallenge.Core.Abstract;
using MyobChallenge.Core.Implementation;
using MyobChallenge.Core.Models;

namespace MyobChallenge
{
    public class Program
    {
        private const string TaxOptionsFile = "taxOptions.csv";

        public static int Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Wrong args! Please enter input and output file names");
                return 1;
            }

            IDataOperations dataOperations = new CsvDataOperations(args[0], args[1]);
            IInputValidator inputValidator = new InputValidator();
            
            var inputs = dataOperations.GetData();
            if (inputs.Any(x => !inputValidator.Validate(x)))
            {
                Console.WriteLine("Wrong input data! Please correct your data");
                return 2;
            }

            Console.WriteLine("Calculating...");

            ISalaryCalculator calculator = new SalaryCalculator(GetTaxOptions());
            var ouputs = inputs.Select(calculator.Calculate);

            dataOperations.SaveData(ouputs);

            Console.WriteLine($"Data was processed and saved to file {args[1]}");

            return 0;
        }

        private static IEnumerable<TaxOption> GetTaxOptions()
        {
            var lines = File.ReadAllLines(TaxOptionsFile);
            return lines.Select(x => x.Split(',')).Select(x => new TaxOption
            {
                Min = int.Parse(x[0]),
                Max = string.IsNullOrEmpty(x[1]) ? int.MaxValue : int.Parse(x[1]),
                BaseTax = int.Parse(x[2]),
                CentsOnEachDollar = double.Parse(x[3]),
            }).ToList();
        }
    }
}
