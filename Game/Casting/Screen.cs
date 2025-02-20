namespace Unit06.Game.Casting
{
    /// <summary>
    /// This is the room/background for the game.
    /// </summary>
    public class Screen : Actor
    {
        private Body body;
        public Screen(Body body, bool debug = false) : base(debug)
        {
            this.body = body;
        }

        /// <summary>
        /// Gets the body.
        /// </summary>
        /// <returns>The body.</returns>
        public Body GetBody()
        {
            return body;
        }

        /// <summary>
        /// Gets the body.
        /// </summary>
        /// <returns>The body.</returns>
        public void SetBody(Body body)
        {
            this.body = body;
        }

    }
}
