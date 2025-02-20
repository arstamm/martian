using Unit06.Game.Casting;

namespace Unit06.Game.Scripting
{
    public class MoveScreenAction : Action
    {
        // This action allows the screen to follow the player
        public MoveScreenAction()
        {
        }
        // This method moves the screen to follow the player
        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Screen screen = (Screen) cast.GetFirstActor(Constants.SCREEN_GROUP);
            Player player = (Player) cast.GetFirstActor(Constants.PLAYER_GROUP);

            int screenMinX = screen.GetBody().GetPosition().GetX();
            int screenMaxX = screen.GetBody().GetSize().GetX() + screenMinX;
            int playerMinX = player.GetBody().GetPosition().GetX();
            int playerMaxX = player.GetBody().GetSize().GetX() + playerMinX;

            if (screenMinX > 0 && playerMinX < (Constants.PLAYER_MIN_RANGE_X + screenMinX))
            {
                int dx = playerMinX - (Constants.PLAYER_MIN_RANGE_X + screenMinX);
                if (screenMinX + dx <= 0)
                {
                    screen.GetBody().SetPosition(new Point(0, 0)); 
                }
                else
                {
                    screen.GetBody().SetPosition(screen.GetBody().GetPosition().Add(new Point(dx, 0)));
                }

            }
            if (screenMaxX < Constants.ROOM_WIDTH && playerMaxX > (Constants.PLAYER_MAX_RANGE_X + screenMinX))
            {
                int dx = playerMaxX - (Constants.PLAYER_MAX_RANGE_X + screenMinX);
                if (screenMaxX + dx >= Constants.ROOM_WIDTH)
                {
                    screen.GetBody().SetPosition(new Point(Constants.ROOM_WIDTH - Constants.SCREEN_WIDTH, 0)); 
                }
                else
                {
                    screen.GetBody().SetPosition(screen.GetBody().GetPosition().Add(new Point(dx, 0)));
                }
            }
        }
    }
}