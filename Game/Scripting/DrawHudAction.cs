using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class DrawHudAction : Action
    {
        private VideoService videoService;
        
        public DrawHudAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);

            Health health = (Health)cast.GetFirstActor(Constants.LIVES_DISPLAY_GROUP);
            videoService.DrawImage(health.GetHealthDisplay(stats.GetLives()), health.GetPosition());

            DrawLabel(cast, Constants.SCRAP_DISPLAY_GROUP, Constants.SCRAP_DISPLAY_FORMAT, stats.GetScrapCount());
        }

        private void DrawLabel(Cast cast, string group, string format, int data)
        {
            string theValueToDisplay = string.Format(format, data);
            
            Label label = (Label)cast.GetFirstActor(group);
            Text text = label.GetText();
            text.SetValue(theValueToDisplay);
            Point position = label.GetPosition();
            videoService.DrawText(text, position);
        }
    }
}