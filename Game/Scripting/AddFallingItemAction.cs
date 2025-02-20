using System;
using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class AddFallingItemAction : Action
    {
        private string group;
        private string imagePath;
        private int width;
        private int height;
        private int value;
        private int frequency;
        private int counter = 1;
        
        public AddFallingItemAction(string group, string imagePath, int width, int height, int value, int frequency)
        {
            this.group = group;
            this.imagePath = imagePath;
            this.width = width;
            this.height = height;
            this.value = value;
            this.frequency = frequency;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            if (counter%frequency == 0)
            {
                counter = 1;
                Random random = new Random();

                int x = random.Next(0, Constants.ROOM_WIDTH - width);
                int y = Constants.ITEM_SPAWN_Y;

                Point position = new Point(x, y);
                Point size = new Point(width, height);
                Point velocity = new Point(0, 0);

                Body body = new Body(position, size, velocity);
                Image image = new Image(imagePath);
                Item item = new Item(body, image, value);

                item.SetAirBorne(true);   

                cast.AddActor(group, item);
            }
            else
            {
                counter += 1;
            }
        }
    }
}