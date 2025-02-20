using System.Collections.Generic;

namespace Unit06.Game.Casting
{
    /// <summary>
    /// Displays health for the Game.
    /// </summary>
    public class Health : Actor
    {
        private Point position;
        private Dictionary<int, string> imgDict;

        /// <summary>
        /// Constructs a new instance of a Health actor.
        /// </summary>
        public Health(Point position, Dictionary<int, string> imgDict, bool debug = false) : base(debug)
        {
            this.position = position;
            this.imgDict = imgDict;
        }

        /// <summary>
        /// Gets the position.
        /// </summary>
        /// <returns>The position.</returns>
        public Point GetPosition()
        {
            return position;
        }

        /// <summary>
        /// Gets the health display image given a specific number of lives.
        /// </summary>
        /// <returns>The image.</returns>
        public Image GetHealthDisplay(int numLives)
        {
            return new Image(imgDict[numLives]);
        }
    }
}
