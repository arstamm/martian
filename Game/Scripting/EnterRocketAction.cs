using Unit06.Game.Casting;
using Unit06.Game.Services;

namespace Unit06.Game.Scripting
{
    public class EnterRocketAction : Action
    {
        private KeyboardService keyboardService;
        private PhysicsService physicsService;
        private string nextScene;

        public EnterRocketAction(KeyboardService keyboardService, PhysicsService physicsService, string nextScene)
        {
            this.keyboardService = keyboardService;
            this.physicsService = physicsService;
            this.nextScene = nextScene;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Player player = (Player) cast.GetFirstActor(Constants.PLAYER_GROUP);
            Rocket rocket = (Rocket) cast.GetFirstActor(Constants.ROCKET_GROUP);

            if (rocket.IsRepaired() && physicsService.HasCollided(player.GetBody(), rocket.GetBody()) && keyboardService.IsKeyPressed(Constants.ENTER))
            {
                callback.OnNext(nextScene);
            }
        }
    }
}