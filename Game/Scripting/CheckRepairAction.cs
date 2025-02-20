using Unit06.Game.Casting;


namespace Unit06.Game.Scripting
{
    public class CheckRepairAction : Action
    {
        public CheckRepairAction()
        {
        }
        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Rocket rocket = (Rocket) cast.GetFirstActor(Constants.ROCKET_GROUP);
            Stats stats = (Stats) cast.GetFirstActor(Constants.STATS_GROUP);

            if (stats.GetMissingScrapCount() <= 0)
            {
                rocket.SetRepaired(true);
            }
        }
    }
}