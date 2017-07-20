namespace MyobChallenge.Core.Models
{
    /// <summary>
    /// Tax option
    /// </summary>
    public class TaxOption
    {
        /// <summary>
        /// Min salary
        /// </summary>
        public int Min { get; set; }

        /// <summary>
        /// Max salary
        /// </summary>
        public int Max { get; set; }

        /// <summary>
        /// Base tax
        /// </summary>
        public int BaseTax { get; set; }

        /// <summary>
        /// Additional cent on each dollar over Min sum - 1$
        /// </summary>
        public double CentsOnEachDollar { get; set; }

        /// <summary>
        /// Ctr
        /// </summary>
        public TaxOption() { }

        /// <summary>
        /// Ctr
        /// </summary>
        /// <param name="min">Min salary</param>
        /// <param name="max">Max salary</param>
        /// <param name="baseTax">Base tax</param>
        /// <param name="centsOnEachDollar">Additional cent on each dollar over Min sum - 1$</param>
        public TaxOption(int min, int max, int baseTax, double centsOnEachDollar)
        {
            Min = min;
            Max = max;
            BaseTax = baseTax;
            CentsOnEachDollar = centsOnEachDollar;
        }
    }
}
