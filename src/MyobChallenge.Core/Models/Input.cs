namespace MyobChallenge.Core.Models
{
    /// <summary>
    /// Input model
    /// </summary>
    public class Input
    {
        /// <summary>
        /// First name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Salary
        /// </summary>
        public int Salary { get; set; }

        /// <summary>
        /// Super (0-50)
        /// </summary>
        public int Super { get; set; }

        /// <summary>
        /// Period (i.e. 1 March - 31 March)
        /// </summary>
        public string Period { get; set; }
    }
}
