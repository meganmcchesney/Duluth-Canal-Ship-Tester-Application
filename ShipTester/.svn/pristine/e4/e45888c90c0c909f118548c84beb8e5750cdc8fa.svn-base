namespace ShipTester.Model
{
    using ShipTester.Extensions;

    /// <summary>
    /// Defines all relevant ports in Lake Superior. Each port is defined as a position with latitude, longitude, and a name.
    /// </summary>
    public static class Ports
    {
        /// <summary>
        /// The port of Duluth
        /// </summary>
        public static readonly Position Duluth = new Position("Duluth", 46.779066, -92.092389);

        /// <summary>
        /// The port of Superior
        /// </summary>
        public static readonly Position Superior = new Position("Superior", 46.706075, -92.016733);

        /// <summary>
        /// The port of ThunderBay
        /// </summary>
        public static readonly Position ThunderBay = new Position("ThunderBay", 48.399537, -89.222818);

        /// <summary>
        /// The port of SaultSaintMarie (SouthEast Lake Superior)
        /// </summary>
        public static readonly Position SaultSteMarie = new Position("SaultSteMarie", 46.500474, -84.375107);

        /// <summary>
        /// The port of Silver Bay
        /// </summary>
        public static readonly Position SilverBay = new Position("SilverBay", 47.269668, -91.266915);

        /// <summary>
        /// The port of Two Harbors
        /// </summary>
        public static readonly Position TwoHarbors = new Position("TwoHarbors", 47.016193, -91.673390);

        /// <summary>
        /// Returns all ports in the class via reflection
        /// </summary>
        public static readonly Position[] All = typeof(Ports).GetFieldValues<Position>();
    }
}
