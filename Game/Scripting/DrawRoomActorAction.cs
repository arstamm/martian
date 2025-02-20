using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class DrawRoomActorAction : Action
    {
        private VideoService videoService;
        private string group;
        
        public DrawRoomActorAction(VideoService videoService, string group)
        {
            this.videoService = videoService;
            this.group = group;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            RoomActor actor = (RoomActor) cast.GetFirstActor(group);
            Screen screen = (Screen) cast.GetFirstActor(Constants.SCREEN_GROUP);
            Body body = actor.GetBody();

            Image image = actor.GetImage();
            Point position = body.GetPosition().Subtract(screen.GetBody().GetPosition());
            videoService.DrawImage(image, position);
        }
    }
}