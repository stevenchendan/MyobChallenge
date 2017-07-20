namespace MyobChallenge.Core.Models
{
    /// <summary>
    /// Output model
    /// </summary>
    public class Output
    {
        /// <summary>
        /// Full name
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Period (i.e. 1 March - 31 March)
        /// </summary>
        public string Period { get; set; }

        /// <summary>
        /// Gross income
        /// </summary>
        public int Gross { get; set; }

        /// <summary>
        /// Tax
        /// </summary>
        public int Tax { get; set; }

        /// <summary>
        /// Net income
        /// </summary>
        public int Net { get; set; }

        /// <summary>
        /// Super value
        /// </summary>
        public int Super { get; set; }
    }
}
