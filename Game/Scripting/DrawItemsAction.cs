using Unit06.Game.Casting;
using Unit06.Game.Services;
using System.Collections.Generic;

namespace Unit06.Game.Scripting
{
    public class DrawItemsAction : Action
    {
        private VideoService videoService;
        
        public DrawItemsAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Screen screen = (Screen) cast.GetFirstActor(Constants.SCREEN_GROUP);
            Point screenPosition = screen.GetBody().GetPosition();

            DrawItems(cast.GetActors(Constants.WATER_GROUP), screenPosition);
            DrawItems(cast.GetActors(Constants.FOOD_GROUP), screenPosition);
            DrawItems(cast.GetActors(Constants.SCRAP_GROUP), screenPosition);
            DrawItems(cast.GetActors(Constants.DEBREE_GROUP), screenPosition);
        }

        private void DrawItems(List<Actor> items, Point screenPosition)
        {

            foreach (Item item in items)
            {
                Body body = item.GetBody();

                Image image = item.GetImage();
                Point position = body.GetPosition().Subtract(screenPosition);
                videoService.DrawImage(image, position);
            }
        }
    }
}