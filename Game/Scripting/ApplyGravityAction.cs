using Unit06.Game.Casting;
using System.Collections.Generic;

namespace Unit06.Game.Scripting
{
    public class ApplyGravityAction : Action
    {
        private string group;
        public ApplyGravityAction(string group)
        {
            this.group = group;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            List<Actor> actors = cast.GetActors(group);
            foreach (RoomActor roomActor in actors)
            {
                roomActor.FallOn(Constants.GROUND_Y, Constants.GRAVITY_ACCELERATION);
            }      
        }
    }
}