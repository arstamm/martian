using System;
using Unit06.Game.Casting;
using Unit06.Game.Services;
using System.Collections.Generic;


namespace Unit06.Game.Scripting
{
    public class AddDebreeAction : Action
    {
        private int frequency;
        private int counter = 1;
        
        public AddDebreeAction(int frequency)
        {
            this.frequency = frequency;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            if (counter%frequency == 0)
            {
                counter = 1;
                Random r = new Random();

                int min_x = -Constants.DEBREE_WIDTH;
                int max_x = Constants.ROOM_WIDTH;
                int y = Constants.GROUND_Y - Constants.DEBREE_HEIGHT;

                int dx = r.Next(Constants.DEBREE_MIN_X_VELOCITY, Constants.DEBREE_MAX_X_VELOCITY);
                int choice = r.Next(0,2);

                Point position = choice == 0 ? new Point(min_x, y) : new Point(max_x, y);
                Point size = new Point(Constants.DEBREE_WIDTH, Constants.DEBREE_HEIGHT);
                Point velocity = choice == 0 ? new Point(dx, 0) : new Point(-dx, 0);

                Body body = new Body(position, size, velocity);
                Image image = new Image(Constants.DEBREE_IMAGE);
                Item item = new Item(body, image, Constants.DEBREE_VALUE);       

                cast.AddActor(Constants.DEBREE_GROUP, item);

            }
            else
            {
                counter += 1;
            }
        }
    }
}