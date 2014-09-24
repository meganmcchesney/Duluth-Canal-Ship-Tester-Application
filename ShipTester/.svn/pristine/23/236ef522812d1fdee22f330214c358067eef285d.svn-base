namespace ShipTester.Model
{
    using ShipTester.Extensions;

    /// <summary>
    /// Represents a ship on the globe. Uses the position class. Each ship has a name, latitude, and longitude.
    /// </summary>
    public static class ShipPositions
    {
        /// <summary>
        /// A position inside St. Louis Bay
        /// </summary>
        public static readonly Position StLouisBay = new Position("StLouisBay", 46.746459, -92.125560);

        /// <summary>
        /// A position that is farther than 50 miles out of Duluth
        /// </summary>
        public static readonly Position EastLakeSuperior = new Position("EastLakeSuperior", 46.809366, -84.816787);

        /// <summary>
        /// A position roughly fifty miles from the Duluth canal.
        /// </summary>
        public static readonly Position FiftyMilesFromDuluthCanal = new Position("FiftyMilesFromDuluthCanal", 46.965166, -91.339919);

        /// <summary>
        /// A position roughly twenty miles from the Duluth canal.
        /// </summary>
        public static readonly Position TwentyMilesFromDuluthCanal = new Position("TwentyMilesFromDuluthCanal", 46.8797, -91.7072);

        /// <summary>
        /// A position outside the Duluth canal.
        /// </summary>
        public static readonly Position OutsideDuluthCanal = new Position("OutsideDuluthCanal", 46.77897, -92.05072);

        /// <summary>
        /// A position roughly half-way between the Duluth canal and Superior.
        /// </summary>
        public static readonly Position HalfwayBetweenDuluthAndSuperior = new Position("HalfwayBetweenDuluthAndSuperior", 46.785017, -92.024231);

        /// <summary>
        /// A position outside the Superior canal.
        /// </summary>
        public static readonly Position OutsideSuperiorCanal = new Position("OutsideSuperiorCanal", 46.747390, -91.974793);

        /// <summary>
        /// A position that is roughly halfway between the Duluth and Superior canals, within the harbor.
        /// </summary>
        public static readonly Position DuluthSuperiorDeadZone = new Position("DuluthSuperiorDeadZone", 46.745576, -92.078250);

        /// <summary>
        /// Returns all ship positions in the class via reflection
        /// </summary>
        public static readonly Position[] All = typeof(ShipPositions).GetFieldValues<Position>();
    }
}
