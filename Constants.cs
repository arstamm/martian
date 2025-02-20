using System.Collections.Generic;
using Unit06.Game.Casting;


namespace Unit06
{
    public class Constants
    {
        // ----------------------------------------------------------------------------------------- 
        // GENERAL GAME CONSTANTS
        // ----------------------------------------------------------------------------------------- 

        // GAME
        public static string GAME_NAME = "Martian";
        public static int FRAME_RATE = 60;

        // SCREEN
        public static int SCREEN_WIDTH = 1040;
        public static int SCREEN_HEIGHT = 680;
        public static int CENTER_X = SCREEN_WIDTH / 2;
        public static int CENTER_Y = SCREEN_HEIGHT / 2;
        public static int GROUND_Y = SCREEN_HEIGHT - 80;
        public static int ITEM_SPAWN_Y = SCRAP_HEIGHT / 3;

        // FONT
        public static string FONT_FILE = "Assets/Fonts/PressStart2P-Regular.ttf";
        public static int FONT_SIZE = 20;

        // SOUND
        // public static string BOUNCE_SOUND = "Assets/Sounds/boing.wav";
        // public static string WELCOME_SOUND = "Assets/Sounds/start.wav";
        // public static string OVER_SOUND = "Assets/Sounds/over.wav";

        // TEXT
        public static int ALIGN_LEFT = 0;
        public static int ALIGN_CENTER = 1;
        public static int ALIGN_RIGHT = 2;


        // COLORS
        public static Color BLACK = new Color(0, 0, 0);
        public static Color WHITE = new Color(255, 255, 255);


        // KEYS
        public static string LEFT = "left";
        public static string RIGHT = "right";
        public static string UP = "up";
        public static string DOWN = "down";
        public static string SPACE = "space";
        public static string ENTER = "enter";
        public static string PAUSE = "p";

        // SCENES
        public static string NEW_GAME = "new_game";
        public static string TRY_AGAIN = "try_again";
        public static string NEXT_LEVEL = "next_level";
        public static string IN_PLAY = "in_play";
        public static string GAME_OVER = "game_over";
        public static string YOU_WIN = "you_win";
        public static string LAUNCH_ROCKET = "launch_rocket";



        // ----------------------------------------------------------------------------------------- 
        // SCRIPTING CONSTANTS
        // ----------------------------------------------------------------------------------------- 

        // PHASES
        public static string INITIALIZE = "initialize";
        public static string LOAD = "load";
        public static string INPUT = "input";
        public static string UPDATE = "update";
        public static string OUTPUT = "output";
        public static string UNLOAD = "unload";
        public static string RELEASE = "release";

        // ----------------------------------------------------------------------------------------- 
        // CASTING CONSTANTS
        // ----------------------------------------------------------------------------------------- 

        //Gravity
        public static int GRAVITY_ACCELERATION = 2;

        // Stats
        public static string STATS_GROUP = "stats";
        public static int STATS_STARTING_LIVES = 6;
        public static int STATS_MAX_LIVES = STATS_STARTING_LIVES;
        public static int STATS_NUM_SCRAP = 0;
        public static int STATS_MAX_SCRAP = 10;

        // HUD
        public static int HUD_MARGIN = 20;
        public static string LIVES_DISPLAY_GROUP = "lives_display";
        public static string SCRAP_DISPLAY_GROUP = "scrap_display";
        public static string SCRAP_DISPLAY_FORMAT = "SCRAP COUNT - {0}";
        public static string TIME_DISPLAY_GROUP = "time_display";
        public static Dictionary<int, string> LIVES_IMAGES = new Dictionary<int, string> () {
            {0, "Assets/Images/Health/0.png"},
            {1, "Assets/Images/Health/1.png"},
            {2, "Assets/Images/Health/2.png"},
            {3, "Assets/Images/Health/3.png"},
            {4, "Assets/Images/Health/4.png"},
            {5, "Assets/Images/Health/5.png"},
            {6, "Assets/Images/Health/6.png"}
        };
        
        // Player
        public static string PLAYER_GROUP = "player";
        public static string PLAYER_RIGHT_IMAGE = "Assets/Images/Player/right.png";
        public static string PLAYER_LEFT_IMAGE = "Assets/Images/Player/left.png";
        public static int PLAYER_WIDTH = 100;
        public static int PLAYER_HEIGHT = 200;
        public static int PLAYER_MOVE_VELOCITY = 13;
        public static int PLAYER_JUMP_VELOCITY = 30;
        public static int PLAYER_DIST_FROM_CENTER_X = 150;
        public static int PLAYER_MIN_RANGE_X = CENTER_X - PLAYER_DIST_FROM_CENTER_X;
        public static int PLAYER_MAX_RANGE_X = CENTER_X + PLAYER_DIST_FROM_CENTER_X;


        // Rocket
        public static string ROCKET_GROUP = "rocket";
        public static string ROCKET_IMAGE = "Assets/Images/Rocket/rocket.png";
        public static string ROCKET_LAUNCH_IMAGE = "Assets/Images/Rocket/rocket-launch.png";
        public static string ROCKET_UNREPAIRED_MSG_FORMAT = "{0} more scrap piece(s)\nneeded to repair ship.";
        public static string ROCKET_REPAIRED_MSG = "Press ENTER to leave.";
        public static int ROCKET_WIDTH = 240;
        public static int ROCKET_HEIGHT = 410;
        public static int ROCKET_DIST_FROM_GROUND = 40;
        public static int ROCKET_LAUNCH_VELOCITY = 2;
        public static int ROCKET_IMG_CHANGE_DELAY = 1;
        public static int ROCKET_LAUNCH_DELAY = 2;
        public static int ROCKET_SCENE_CHANGE_DELAY = 8;

        // Pop Up Label
        public static string POP_UP_BACKGROUND = "Assets/Images/pop-up-background.png";
        public static int POP_UP_FONTSIZE = 18;
        public static int POP_UP_MARGIN = 15;
        public static int POP_UP_Y_MARGIN = 65;



        // Debree
        public static string DEBREE_GROUP = "debree";
        public static string DEBREE_IMAGE = "Assets/Images/Items/debris.png";
        public static int DEBREE_VALUE = -1;
        public static int DEBREE_FREQUENCY = 100;
        public static int DEBREE_WIDTH = 80;
        public static int DEBREE_HEIGHT = 80;
        public static int DEBREE_MIN_X_VELOCITY = 5;
        public static int DEBREE_MAX_X_VELOCITY = 10;

        // Food
        public static string FOOD_GROUP = "food";
        public static string FOOD_IMAGE = "Assets/Images/Items/potato.png";
        public static int FOOD_VALUE = 2;
        public static int FOOD_FREQUENCY = 500;
        public static int FOOD_WIDTH = 50;
        public static int FOOD_HEIGHT = 42;

        // Water
        public static string WATER_GROUP = "water";
        public static string WATER_IMAGE = "Assets/Images/Items/water-bottle.png";
        public static int WATER_VALUE = 1;
        public static int WATER_FREQUENCY = 300;
        public static int WATER_WIDTH = 49;
        public static int WATER_HEIGHT = 60;

        // Scrap
        public static string SCRAP_GROUP = "scrap";
        public static string SCRAP_IMAGE = "Assets/Images/Items/battery.png";
        public static int SCRAP_VALUE = 1;
        public static int SCRAP_FREQUENCY = 500;
        public static int SCRAP_WIDTH = 25;
        public static int SCRAP_HEIGHT = 50;


        // Room
        public static string ROOM_GROUP = "room";
        public static string ROOM_IMAGE = "Assets/Images/background.png";
        public static int ROOM_HEIGHT = SCREEN_HEIGHT;
        public static int ROOM_WIDTH = 3317;
        public static int ROOM_CENTER_X = ROOM_WIDTH / 2;


        // SCREEN
        public static string SCREEN_GROUP = "screen";


        // DIALOG
        public static string DIALOG_GROUP = "dialogs";
        public static string ENTER_TO_START = "PRESS ENTER TO START";
        public static string WAS_GOOD_GAME = "GAME OVER";
        public static string YOU_WIN_MSG = "YOU WIN!";

    }
}