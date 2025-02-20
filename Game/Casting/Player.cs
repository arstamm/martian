namespace Unit06.Game.Casting
{
    /// <summary>
    /// This is the player for the game.
    /// </summary>
    public class Player : RoomActor
    {
        private string rightImgFile;
        private string leftImgFile; 
        public Player(Body body, string rightImgFile, string leftImgFile, bool debug = false) : base(debug)
        {
            base.SetBody(body);
            this.rightImgFile = rightImgFile;
            this.leftImgFile = leftImgFile;
            base.SetImage(new Image(rightImgFile));
        }

        public void MoveLeft()
        {
            base.GetBody().GetVelocity().SetX(-Constants.PLAYER_MOVE_VELOCITY);
            base.SetImage(new Image(leftImgFile));
        }

        public void MoveRight()
        {
            base.GetBody().GetVelocity().SetX(Constants.PLAYER_MOVE_VELOCITY);
            base.SetImage(new Image(rightImgFile));
        }
        public void StopMoving()
        {
            base.GetBody().GetVelocity().SetX(0);
        }
        
        public void Jump(int dy)
        {
            if (!IsAirBorne())
            {
                SetAirBorne(true);
                base.GetBody().GetVelocity().SetY(-dy);
            }
        }
    }
}