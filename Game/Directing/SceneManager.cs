using System;
using System.Collections.Generic;
using System.IO;
using Unit06.Game.Casting;
using Unit06.Game.Scripting;
using Unit06.Game.Services;


namespace Unit06.Game.Directing
{
    public class SceneManager
    {
        public static AudioService AudioService = new RaylibAudioService();
        public static KeyboardService KeyboardService = new RaylibKeyboardService();
        public static MouseService MouseService = new RaylibMouseService();
        public static PhysicsService PhysicsService = new RaylibPhysicsService();
        public static VideoService VideoService = new RaylibVideoService(Constants.GAME_NAME,
            Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT, Constants.BLACK);

        public SceneManager()
        {
        }

        public void PrepareScene(string scene, Cast cast, Script script)
        {
            if (scene == Constants.NEW_GAME)
            {
                PrepareNewGame(cast, script);
            }
            else if (scene == Constants.LAUNCH_ROCKET)
            {
                PrepareLaunchRocket(cast, script);
            }
            else if (scene == Constants.IN_PLAY)
            {
                PrepareInPlay(cast, script);
            }
            else if (scene == Constants.YOU_WIN)
            {
                PrepareYouWin(cast, script);
            }
            else if (scene == Constants.GAME_OVER)
            {
                PrepareGameOver(cast, script);
            }
        }

        private void PrepareNewGame(Cast cast, Script script)
        {
            cast.ClearAllActors();

            AddRoom(cast);
            AddScreen(cast);
            AddDialog(cast, Constants.ENTER_TO_START);

            script.ClearAllActions();
            AddInitActions(script);
            AddLoadActions(script);

            ChangeSceneAction a = new ChangeSceneAction(KeyboardService, Constants.IN_PLAY);
            script.AddAction(Constants.INPUT, a);

            AddSceneOutputActions(script);
            AddUnloadActions(script);
            AddReleaseActions(script);
        }

        private void PrepareInPlay(Cast cast, Script script)
        {
            cast.ClearActors(Constants.DIALOG_GROUP);

            AddRocket(cast);
            AddPlayer(cast);
            AddStats(cast);
            AddHealthDisplay(cast);
            AddScrapCountDisplay(cast);

            script.ClearAllActions();
            AddInitActions(script);
            AddLoadActions(script);

            ControlPlayerAction c = new ControlPlayerAction(KeyboardService);
            script.AddAction(Constants.INPUT, c);

            EnterRocketAction l = new EnterRocketAction(KeyboardService, PhysicsService, Constants.LAUNCH_ROCKET);
            script.AddAction(Constants.INPUT, l);

            AddUpdateActions(script);
            AddInPlayOutputActions(script);
            AddUnloadActions(script);
            AddReleaseActions(script);
        }

        private void PrepareLaunchRocket(Cast cast, Script script)
        {
            ClearInPlayActors(cast);

            AddRocket(cast);

            script.ClearAllActions();
            AddInitActions(script);
            AddLoadActions(script);

            LaunchRocketAction l = new LaunchRocketAction(
                Constants.YOU_WIN, Constants.ROCKET_IMG_CHANGE_DELAY, Constants.ROCKET_LAUNCH_DELAY, 
                Constants.ROCKET_SCENE_CHANGE_DELAY, DateTime.Now);
            script.AddAction(Constants.INPUT, l);

            script.AddAction(Constants.UPDATE, new MoveRocketAction());

            script.AddAction(Constants.OUTPUT, new StartDrawingAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawRoomActorAction(VideoService, Constants.ROOM_GROUP));
            script.AddAction(Constants.OUTPUT, new DrawRoomActorAction(VideoService, Constants.ROCKET_GROUP));
            script.AddAction(Constants.OUTPUT, new EndDrawingAction(VideoService));
            AddUnloadActions(script);
            AddReleaseActions(script);
        }

        private void PrepareYouWin(Cast cast, Script script)
        {
            AddDialog(cast, Constants.YOU_WIN_MSG);

            script.ClearAllActions();
            AddInitActions(script);
            AddLoadActions(script);

            TimedChangeSceneAction t = new TimedChangeSceneAction(Constants.NEW_GAME, 3, DateTime.Now);
            script.AddAction(Constants.INPUT, t);

            AddSceneOutputActions(script);
            AddUnloadActions(script);
            AddReleaseActions(script);
        }

        private void PrepareGameOver(Cast cast, Script script)
        {
            cast.ClearActors(Constants.PLAYER_GROUP);

            AddDialog(cast, Constants.WAS_GOOD_GAME);

            script.ClearAllActions();
            AddInitActions(script);
            AddLoadActions(script);

            TimedChangeSceneAction t = new TimedChangeSceneAction(Constants.NEW_GAME, 3, DateTime.Now);
            script.AddAction(Constants.INPUT, t);

            script.AddAction(Constants.OUTPUT, new StartDrawingAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawRoomActorAction(VideoService, Constants.ROOM_GROUP));
            script.AddAction(Constants.OUTPUT, new DrawRoomActorAction(VideoService, Constants.ROCKET_GROUP));
            script.AddAction(Constants.OUTPUT, new DrawDialogAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawItemsAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawHudAction(VideoService));
            script.AddAction(Constants.OUTPUT, new EndDrawingAction(VideoService));
        }

        // -----------------------------------------------------------------------------------------
        // casting methods
        // -----------------------------------------------------------------------------------------

        private void AddPlayer(Cast cast)
        {
            cast.ClearActors(Constants.PLAYER_GROUP);

            int x = Constants.CENTER_X - Constants.PLAYER_WIDTH / 2;
            int y = Constants.GROUND_Y - Constants.PLAYER_HEIGHT;
        
            Point position = new Point(x, y);
            Point size = new Point(Constants.PLAYER_WIDTH, Constants.PLAYER_HEIGHT);
            Point velocity = new Point(0, 0);

            Body body = new Body(position, size, velocity);
            Player player = new Player(body, Constants.PLAYER_RIGHT_IMAGE, Constants.PLAYER_LEFT_IMAGE);

            cast.AddActor(Constants.PLAYER_GROUP, player);
        }
        private void AddRocket(Cast cast)
        {
            cast.ClearActors(Constants.ROCKET_GROUP);

            int x = Constants.ROOM_CENTER_X - Constants.ROCKET_WIDTH / 2;
            int y = Constants.GROUND_Y - (Constants.ROCKET_HEIGHT + Constants.ROCKET_DIST_FROM_GROUND);

            Point position = new Point(x, y);
            Point size = new Point(Constants.ROCKET_WIDTH, Constants.ROCKET_HEIGHT);
            Point velocity = new Point(0, 0);

            Body body = new Body(position, size, velocity);
            Image image = new Image(Constants.ROCKET_IMAGE);

            Text text = new Text("", Constants.FONT_FILE, Constants.POP_UP_FONTSIZE, Constants.ALIGN_LEFT, Constants.WHITE);
            Point labelPosition = new Point(Constants.HUD_MARGIN, Constants.POP_UP_Y_MARGIN);
            Image backgroundImage = new Image(Constants.POP_UP_BACKGROUND);

            PopUpLabel rocketMsg = new PopUpLabel(text, labelPosition, Constants.POP_UP_MARGIN, backgroundImage);

            Rocket rocket = new Rocket(body, image, rocketMsg);       

            cast.AddActor(Constants.ROCKET_GROUP, rocket);
        }
        private void AddRoom(Cast cast)
        {
            cast.ClearActors(Constants.ROOM_GROUP);

            Point position = new Point(0, 0);
            Point size = new Point(Constants.ROOM_HEIGHT, Constants.ROOM_WIDTH);
            Point velocity = new Point(0, 0);

            Body body = new Body(position, size, velocity);
            Image image = new Image(Constants.ROOM_IMAGE);
            Room room = new Room(body, image);

            cast.AddActor(Constants.ROOM_GROUP, room);
        }
  
        private void AddScreen(Cast cast)
        {   
            Point position = new Point(0, 0);
            Point size = new Point(Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT);
            Point velocity = new Point(0, 0);

            Screen screen = new Screen(new Body(position, size, velocity));
            cast.AddActor(Constants.SCREEN_GROUP, screen); 
        }

        private void AddStats(Cast cast)
        {
            Stats stats = new Stats(Constants.STATS_STARTING_LIVES, Constants.STATS_MAX_LIVES, Constants.STATS_NUM_SCRAP, Constants.STATS_MAX_SCRAP);
            cast.AddActor(Constants.STATS_GROUP, stats);
        }

        private void AddHealthDisplay(Cast cast)
        {
            Point position = new Point(Constants.HUD_MARGIN, Constants.HUD_MARGIN);
            Health health = new Health(position, Constants.LIVES_IMAGES);

            cast.AddActor(Constants.LIVES_DISPLAY_GROUP, health);
        }

        private void AddScrapCountDisplay(Cast cast)
        {
            cast.ClearActors(Constants.SCRAP_DISPLAY_GROUP);

            Text text = new Text(Constants.SCRAP_DISPLAY_FORMAT, Constants.FONT_FILE, Constants.FONT_SIZE, 
                Constants.ALIGN_RIGHT, Constants.BLACK);
            Point position = new Point(Constants.SCREEN_WIDTH - Constants.HUD_MARGIN, 
                Constants.HUD_MARGIN);

            Label label = new Label(text, position);
            cast.AddActor(Constants.SCRAP_DISPLAY_GROUP, label);   
        }

        private void AddDialog(Cast cast, string message)
        {
            cast.ClearActors(Constants.DIALOG_GROUP);

            Text text = new Text(message, Constants.FONT_FILE, Constants.FONT_SIZE, 
                Constants.ALIGN_CENTER, Constants.BLACK);
            Point position = new Point(Constants.CENTER_X, Constants.CENTER_Y);

            Label label = new Label(text, position);
            cast.AddActor(Constants.DIALOG_GROUP, label);   
        }

        private void ClearInPlayActors(Cast cast)
        {
            cast.ClearActors(Constants.ROCKET_GROUP);
            cast.ClearActors(Constants.PLAYER_GROUP);
            cast.ClearActors(Constants.STATS_GROUP);
            cast.ClearActors(Constants.LIVES_DISPLAY_GROUP);
            cast.ClearActors(Constants.ROCKET_GROUP);     
        }

        // -----------------------------------------------------------------------------------------
        // scriptig methods
        // -----------------------------------------------------------------------------------------

        private void AddInitActions(Script script)
        {
            script.AddAction(Constants.INITIALIZE, new InitializeDevicesAction(AudioService, 
                VideoService));
        }

        private void AddLoadActions(Script script)
        {
            script.AddAction(Constants.LOAD, new LoadAssetsAction(AudioService, VideoService));
        }

        private void AddSceneOutputActions(Script script)
        {
            script.AddAction(Constants.OUTPUT, new StartDrawingAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawRoomActorAction(VideoService, Constants.ROOM_GROUP));
            script.AddAction(Constants.OUTPUT, new DrawDialogAction(VideoService));
            script.AddAction(Constants.OUTPUT, new EndDrawingAction(VideoService));
        }

        private void AddInPlayOutputActions(Script script)
        {
            script.AddAction(Constants.OUTPUT, new StartDrawingAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawRoomActorAction(VideoService, Constants.ROOM_GROUP));
            script.AddAction(Constants.OUTPUT, new DrawRoomActorAction(VideoService, Constants.ROCKET_GROUP));
            script.AddAction(Constants.OUTPUT, new DrawRoomActorAction(VideoService, Constants.PLAYER_GROUP));
            script.AddAction(Constants.OUTPUT, new DrawItemsAction(VideoService));
            script.AddAction(Constants.OUTPUT, new DrawPopUpAction(VideoService, PhysicsService));
            script.AddAction(Constants.OUTPUT, new DrawHudAction(VideoService));
            script.AddAction(Constants.OUTPUT, new EndDrawingAction(VideoService));
        }
        private void AddUnloadActions(Script script)
        {
            script.AddAction(Constants.UNLOAD, new UnloadAssetsAction(AudioService, VideoService));
        }

        private void AddReleaseActions(Script script)
        {
            script.AddAction(Constants.RELEASE, new ReleaseDevicesAction(AudioService, 
                VideoService));
        }

        private void AddUpdateActions(Script script)
        {
            script.AddAction(Constants.UPDATE, new MovePlayerAction());
            script.AddAction(Constants.UPDATE, new MoveScreenAction());
            script.AddAction(Constants.UPDATE, new MoveFallingItemsAction());
            script.AddAction(Constants.UPDATE, new MoveDebreeAction());
            script.AddAction(Constants.UPDATE, new AddFallingItemAction(Constants.WATER_GROUP, Constants.WATER_IMAGE, Constants.WATER_WIDTH, Constants.WATER_HEIGHT, Constants.WATER_VALUE, Constants.WATER_FREQUENCY));
            script.AddAction(Constants.UPDATE, new AddFallingItemAction(Constants.FOOD_GROUP, Constants.FOOD_IMAGE, Constants.FOOD_WIDTH, Constants.FOOD_HEIGHT, Constants.FOOD_VALUE, Constants.FOOD_FREQUENCY));
            script.AddAction(Constants.UPDATE, new AddFallingItemAction(Constants.SCRAP_GROUP, Constants.SCRAP_IMAGE, Constants.SCRAP_WIDTH, Constants.SCRAP_HEIGHT, Constants.SCRAP_VALUE, Constants.SCRAP_FREQUENCY));
            script.AddAction(Constants.UPDATE, new AddDebreeAction(Constants.DEBREE_FREQUENCY));
            script.AddAction(Constants.UPDATE, new ApplyGravityAction(Constants.PLAYER_GROUP));
            script.AddAction(Constants.UPDATE, new ApplyGravityAction(Constants.WATER_GROUP));
            script.AddAction(Constants.UPDATE, new ApplyGravityAction(Constants.FOOD_GROUP));
            script.AddAction(Constants.UPDATE, new ApplyGravityAction(Constants.SCRAP_GROUP));
            script.AddAction(Constants.UPDATE, new CollideItemsAction(PhysicsService));
            script.AddAction(Constants.UPDATE, new CheckRepairAction());
            script.AddAction(Constants.UPDATE, new CheckGameOverAction());
        }
    }
}