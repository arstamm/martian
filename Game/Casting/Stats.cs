namespace Unit06.Game.Casting
{
    /// <summary>
    /// Stores stats info for the game.
    /// </summary>
    public class Stats : Actor
    {
        private int maxLives;
        private int lives;
        private int scrap;
        private int maxScrap;

        /// <summary>
        /// Constructs a new instance stats.
        /// </summary>
        public Stats(int startingLives, int maxLives, int scrap, int maxScrap, bool debug = false) : base(debug)
        {
            this.lives = startingLives;
            this.maxLives = maxLives;
            this.scrap = scrap;
            this.maxScrap = maxScrap;
        }


        /// <summary>
        /// Adds lives to the player
        /// </summary>
        public void AddLives(int lives)
        {   
            if (this.lives + lives >= maxLives)
            {
                this.lives = maxLives;
            }
            else if (this.lives + lives <= 0)
            {
                this.lives = 0;
            }
            else
            {
                this.lives += lives;
            }
        }

        /// <summary>
        /// Adds a scrap piece.
        /// </summary>
        public void AddScrap(int scrap = 1)
        {
            this.scrap += scrap;
        }

        /// <summary>
        /// Gets the lives.
        /// </summary>
        /// <returns>The lives.</returns>
        public int GetLives()
        {
            return lives;
        }

        /// <summary>
        /// Gets the max lives.
        /// </summary>
        /// <returns>The max lives.</returns>
        public int GetMaxLives()
        {
            return maxLives;
        }

        /// <summary>
        /// Gets the scrap count.
        /// </summary>
        /// <returns>The scrap.</returns>
        public int GetScrapCount()
        {
            return scrap;
        }

        /// <summary>
        /// Gets the maximum scrap count (amoount needed to repair the ship).
        /// </summary>
        /// <returns>The scrap.</returns>
        public int GetMaxScrapCount()
        {
            return maxScrap;
        }

        public int GetMissingScrapCount()
        {
            return maxScrap - scrap;
        }

        /// <summary>
        /// Removes a life.
        /// </summary>
        public void RemoveLives(int lives)
        {
            this.lives -= lives;
            if (this.lives <= 0)
            {
                this.lives = 0;
            }
        }
        
    }
}