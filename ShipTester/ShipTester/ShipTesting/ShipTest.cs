namespace ShipTester.ShipTesting
{
    using System;
    using Model;

    /// <summary>
    /// This object acts as the ship object in the Duluth Canal Application, holds the ship properties
    /// </summary>
    [Serializable]
    public class ShipTest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShipTest"/> class
        /// ShipTest.Eta must always be in the future 
        /// </summary>
        public ShipTest()
        {
            this.Eta = DateTime.UtcNow.AddDays(1);
        }

        /// <summary>
        /// Gets or sets Location of ship
        /// </summary>
        public Position Position { get; set; }

        /// <summary>
        /// Gets or sets Speed of ship
        /// </summary>
        public double Speed { get; set; }

        /// <summary>
        /// Gets or sets Navigation Status of a ship
        /// </summary>
        public NavigationalStatus NavigationalStatus { get; set; }

        /// <summary>
        /// Gets or sets Ship heading / course in degrees
        /// </summary>
        public double Heading { get; set; }

        /// <summary>
        /// Gets or sets Reported ship destination
        /// </summary>
        public Position Destination { get; set; }

        /// <summary>
        /// Gets or sets Time a ship will arrive at port
        /// </summary>
        public DateTime? Eta { get; set; }

        /// <summary>
        /// Gets or sets Timestamp for when a ship first reports its position inside Duluth Harbor
        /// </summary>
        public DateTime? CanalEntryTimestamp { get; set; }

        /// <summary>
        /// Gets or sets Calculated time of arrival for a ship at Duluth Canal
        /// </summary>
        public DateTime? DerivedEta { get; set; }

        /// <summary>
        /// Gets or sets Property for testing purposes only, was being used before the Derived Eta was populated
        /// </summary>
        public DuluthCanalEtaResult? DuluthCanalEtaResult { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a Pass / fail property for test results
        /// </summary>
        public bool Evaluation { get; set; }

        /// <summary>
        /// Gets or sets Count of passing evaluations
        /// </summary>
        public int Tally { get; set; }

        /// <summary>
        /// Gets or sets Notes on a shiptest object
        /// </summary>
        public string Note { get; set; }
    }
}