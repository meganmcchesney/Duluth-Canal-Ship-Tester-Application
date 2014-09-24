namespace ShipTester.Model
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A polygon represents an area defined by an array of positions. This implementation by Patrick Mullen
    /// is useful when you have many points that need to be tested against the same polygon. For efficiency
    /// purposes please make the polygon convex.
    /// </summary>
    public class Polygon
    {
        /// <summary>
        /// Initializes a new instance of the Polygon class.
        /// </summary>
        /// <param name="name">The name of the polygon</param>
        /// <param name="positions">the corners of the polygon</param>
        public Polygon(string name, Position[] positions )
        {
            this.Name = name;

            // the amount of corners the polygon has
            this.PolySides = positions.Length;
            
            this.PolyX = new List<float>();
            this.PolyY = new List<float>();

            foreach (Position pos in positions)
            {
                this.PolyX.Add((float)pos.Longitude);
                this.PolyY.Add((float)pos.Latitude);
            }
        }

        #region public properties

        /// <summary>
        /// Gets or sets the name of the polygon
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Gets or sets how many sides the polygon has
        /// </summary>
        public int PolySides { get; protected set; }

        /// <summary>
        /// Gets or sets the X coordinates of a vertice
        /// </summary>
        public IList<float> PolyX { get; protected set; }

        /// <summary>
        /// Gets or sets Y coordinate of a vertice
        /// </summary>
        public IList<float> PolyY { get; protected set; }

        #endregion

        /// <summary>
        /// Overloaded == operator
        /// </summary>
        /// <param name="a">Left side</param>
        /// <param name="b">Right side</param>
        /// <returns>True if equal</returns>
        public static bool operator ==(Polygon a, Polygon b)
        {
            if ((object)a == null)
            {
                throw new ArgumentNullException();
            }
            return a.Equals(b);
        }

        /// <summary>
        /// Overloaded != operator
        /// </summary>
        /// <param name="a">Left side</param>
        /// <param name="b">Right Side</param>
        /// <returns>True if not equal</returns>
        public static bool operator !=(Polygon a, Polygon b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Gets hash code of Name
        /// </summary>
        /// <returns>Numeric hash value</returns>
        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        /// <summary>
        /// Compares the polygon object to another object.
        /// </summary>
        /// <param name="obj">the object to be compared</param>
        /// <returns>true if the two objects are the same</returns>
        public override bool Equals(object obj)
        {
            return obj is Polygon && this.Equals((Polygon)obj);
        }

        /// <summary>
        /// Compares the polygon's name to another polygon's name
        /// </summary>
        /// <param name="other">the polygon to be compared</param>
        /// <returns>true if the two polygons share a name</returns>
        public bool Equals(Polygon other)
        {
            if (ReferenceEquals(null, other))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return this.Name.Equals(other.Name);
        }

        /// <summary>
        /// Converts the polygon to a string
        /// </summary>
        /// <returns>The name of the polygon</returns>
        public override string ToString()
        {
            return this.Name;
        }
    }
}
