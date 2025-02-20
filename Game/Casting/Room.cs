namespace Unit06.Game.Casting
{
    /// <summary>
    /// This is the room/background for the game.
    /// </summary>
    public class Room : RoomActor
    {
        public Room(Body body, Image image, bool debug = false) : base(debug)
        {
            base.SetBody(body);
            base.SetImage(image);
        }
    }
}

