using Unit06.Game.Casting;
using System.Collections.Generic;

namespace Unit06.Game.Scripting
{
    public class MoveDebreeAction : Action
    {
        public MoveDebreeAction()
        {
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            List<Actor> items = cast.GetActors(Constants.DEBREE_GROUP);

            foreach (Item item in items)
            {
                Body body = item.GetBody();
                Point position = body.GetPosition();
                if (position.GetX() + Constants.DEBREE_WIDTH < 0 || position.GetX() > Constants.ROOM_WIDTH)
                {
                    cast.RemoveActor(Constants.DEBREE_GROUP, item);
                }
                else
                {
                    Point velocity = body.GetVelocity();
                    body.SetPosition(position.Add(velocity));
                }
            }    
        }
    }
}