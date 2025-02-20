namespace Unit06.Game.Casting
{
    /// <summary>
    /// This is the player for the game.
    /// </summary>
    public class Item : RoomActor
    {
        private int value;
        public Item(Body body, Image image, int value, bool debug = false) : base(debug)
        {
            this.value = value;
            base.SetBody(body);
            base.SetImage(image);
        }

        public int GetValue()
        {
            return value;
        }
    
    }
}