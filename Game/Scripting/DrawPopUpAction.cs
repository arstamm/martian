using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class DrawPopUpAction : Action
    {
        private VideoService videoService;
        private PhysicsService physicsService;
        
        public DrawPopUpAction(VideoService videoService, PhysicsService physicsService)
        {
            this.videoService = videoService;
            this.physicsService = physicsService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Player player = (Player) cast.GetFirstActor(Constants.PLAYER_GROUP);
            Rocket rocket = (Rocket) cast.GetFirstActor(Constants.ROCKET_GROUP);

            if (physicsService.HasCollided(player.GetBody(), rocket.GetBody()))
            {
                PopUpLabel popUp = rocket.GetPopUpLabel();

                Stats stats = (Stats) cast.GetFirstActor(Constants.STATS_GROUP);
                int data = stats.GetMissingScrapCount();
                string displayValue = rocket.IsRepaired() ? Constants.ROCKET_REPAIRED_MSG : string.Format(Constants.ROCKET_UNREPAIRED_MSG_FORMAT, data);
                popUp.GetText().SetValue(displayValue);

                videoService.DrawImage(popUp.GetBackgroundImage(), popUp.GetBackgroundPosition());
                videoService.DrawText(popUp.GetText(), popUp.GetPosition());
            }
        }
    }
}