using Unit06.Game.Casting;
using System.Collections.Generic;

namespace Unit06.Game.Scripting
{
    public class MoveRocketAction : Action
    {
        public MoveRocketAction()
        {
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Rocket rocket = (Rocket) cast.GetFirstActor(Constants.ROCKET_GROUP);

            Body body = rocket.GetBody();
            Point position = body.GetPosition();
            Point velocity = body.GetVelocity();
            body.SetPosition(position.Add(velocity));
        }
    }
}