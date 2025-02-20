using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class ControlPlayerAction : Action
    {
        private KeyboardService keyboardService;

        public ControlPlayerAction(KeyboardService keyboardService)
        {
            this.keyboardService = keyboardService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Player player = (Player) cast.GetFirstActor(Constants.PLAYER_GROUP);
            if (keyboardService.IsKeyDown(Constants.LEFT))
            {
                player.MoveLeft();
            }
            else if (keyboardService.IsKeyDown(Constants.RIGHT))
            {
                player.MoveRight();
            }
            else
            {
                player.StopMoving();
            }

            if (keyboardService.IsKeyDown(Constants.UP) || keyboardService.IsKeyDown(Constants.SPACE))
            {
                player.Jump(Constants.PLAYER_JUMP_VELOCITY);
            }

        }
    }
}