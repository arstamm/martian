using System;
using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class LaunchRocketAction : Action
    {
        private string nextScene;
        private bool imageChanged = false;
        private double imageChangeDelay;
        private bool isLaunched = false;
        private double launchDelay;
        private double sceneChangeDelay;
        private DateTime start;
        
        public LaunchRocketAction(string nextScene, double imageChangeDelay, double launchDelay, double sceneChangeDelay, DateTime start)
        {
            this.nextScene = nextScene;
            this.imageChangeDelay = imageChangeDelay;
            this.launchDelay = launchDelay;
            this.sceneChangeDelay = sceneChangeDelay;
            this.start = start;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            DateTime currentTime = DateTime.Now;
            TimeSpan elapsedTime = currentTime.Subtract(start);
            Rocket rocket = (Rocket) cast.GetFirstActor(Constants.ROCKET_GROUP);
            if (elapsedTime.Seconds > imageChangeDelay && imageChanged == false)
            {
                rocket.SetImage(new Image(Constants.ROCKET_LAUNCH_IMAGE));
                this.imageChanged = true;
            }
            if (elapsedTime.Seconds > launchDelay && isLaunched == false)
            {
                rocket.GetBody().SetVelocity(new Point(0, -Constants.ROCKET_LAUNCH_VELOCITY));
                this.isLaunched = true;
            }
            if (elapsedTime.Seconds > sceneChangeDelay)
            {
                callback.OnNext(nextScene);
            }
        }
    }
}