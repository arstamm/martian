namespace Unit06.Game.Casting
{
    /// <summary>
    /// A thing that participates in the game that is in the room.
    /// </summary>
    public class RoomActor : Actor
    {
        private bool airBorne = false;
        private Body body;
        private Image image;

        /// <summary>
        /// Constructs a new instance of Room Actor.
        /// </summary>
        public RoomActor(bool debug = false) : base(debug)
        {
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

        /// <summary>
        /// Gets the image.
        /// </summary>
        /// <returns>The image.</returns>
        public Image GetImage()
        {
            return image;
        }

        /// <summary>
        /// Sets the image.
        /// </summary>
        public void SetImage(Image image)
        {
            this.image = image;
        }

        public void FallOn(int ground_y, int d2y)
        {
            if (airBorne)
            {  
                Point v = this.GetBody().GetVelocity().Add(new Point(0, d2y));
                if (this.GetBody().GetPosition().GetY() + this.GetBody().GetSize().GetY() >= ground_y)
                {
                    this.airBorne = false;
                    GetBody().GetVelocity().SetY(0);
                    GetBody().GetPosition().SetY(ground_y - this.GetBody().GetSize().GetY());
                }
                else
                {
                    GetBody().SetVelocity(v);
                }
            }
        }
        public void SetAirBorne(bool airBorne)
        {
            this.airBorne = airBorne;
        }
        public bool IsAirBorne()
        {
            return airBorne;
        }

    }
}