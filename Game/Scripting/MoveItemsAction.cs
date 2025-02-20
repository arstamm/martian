using Unit06.Game.Casting;
using System.Collections.Generic;

namespace Unit06.Game.Scripting
{
    public class MoveFallingItemsAction : Action
    {
        public MoveFallingItemsAction()
        {
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            MoveItems(cast, Constants.WATER_GROUP);
            MoveItems(cast, Constants.FOOD_GROUP);
            MoveItems(cast, Constants.SCRAP_GROUP);
        }

        private void MoveItems(Cast cast, string group)
        {
            List<Actor> items = cast.GetActors(group);

            foreach (Item item in items)
            {
                Body body = item.GetBody();
                Point position = body.GetPosition();
                Point velocity = body.GetVelocity();
                body.SetPosition(position.Add(velocity));
            }      
        }
    }
}