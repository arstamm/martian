using Unit06.Game.Casting;


namespace Unit06.Game.Scripting
{
    public class CheckGameOverAction : Action
    {
        public CheckGameOverAction()
        {
        }
        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Stats stats = (Stats) cast.GetFirstActor(Constants.STATS_GROUP);

            if (stats.GetLives() <= 0)
            {
                callback.OnNext(Constants.GAME_OVER);
            }
        }
    }
}