using Sandbox.ConsoleGame.Engine.Core;
using Sandbox.ConsoleGame.Engine.Ui;
using System.Text;

namespace Sandbox.ConsoleGame.Engine
{
    public class Game
    {
        private readonly AutoResetEvent _autoResetEvent;
        private readonly GameLoop _gameLoop;
        private int _loopCounter = 0;

        public readonly int TimerCallbackDelayMs = Constants.DefaultTimerCallbackDelayMs;
        public readonly int TimerCallbackIntervalWaitMs = Constants.DefaultTimerCallbackIntervalWaitMs;

        public StringBuilder DisplayBuffer { get; }
        public List<string> DisplayFrames { get; }
        public int Height { get; } = Constants.DefaultGameFieldHeight;
        public GameSettings Settings { get; }
        public IUserInterface UserInterface { get; }
        public int Width { get; } = Constants.DefaultGameFieldWidth;

        public Location? PlayerLocation { get; private set; }

        /// <summary> Create a new instance of the <see cref="Game"/>. </summary>
        /// <param name="settings"><see cref="GameSettings"/>.</param>
        /// <param name="userInterface"><see cref="IUserInterface"/> (will create a standard Console based UI if non is provided).</param>
        public Game(GameSettings settings, IUserInterface? userInterface = null)
        {
            Settings = settings;
            UserInterface = userInterface ?? new ConsoleUserInterface(Width, Height);

            Width = settings.Width;
            Height = settings.Height;
            DisplayBuffer = new StringBuilder();
            DisplayFrames = new List<string>(Height);

            DisplayBufferResetBackground();
            DisplayBufferDrawCharacter();

            // set up the user interface
            _gameLoop = new GameLoop(UserInterface, this);

            // set up the timer reset
            _autoResetEvent = new AutoResetEvent(false);
            var timer = new Timer(_gameLoop.Render, _autoResetEvent, TimerCallbackDelayMs, TimerCallbackIntervalWaitMs);

            // start a thred to read Key.Press
            Task.Factory.StartNew(() => Key.Press());
        }


        #region Display functionality

        // todo - extract to a provider

        /// <summary> Render the display. </summary>
        /// <param name="stateInfo"></param>
        public void DisplayRender()
        {
            DisplayBuffer.Clear();
            DisplayFrames.ForEach(frame => DisplayBuffer.Append(frame));

            UserInterface.Clear();
            UserInterface.Print(DisplayBuffer.ToString());

            UserInterface.UpdateTitle(_loopCounter++.ToString());
        }

        /// <summary> Reset the background in the display buffer to the current <see cref="Settings"/>. </summary>
        public void DisplayBufferResetBackground()
        {
            // initialize game field
            for (int i = 0; i < Height; i++)
            {
                string line = string.Empty.Stuff(0, Width, Settings.Background);
                DisplayFrames.Add(line);
            }
        }

        public void DisplayBufferDrawCharacter()
        {
            DisplayFrames[Settings.PlayerLocation.Y] =
                DisplayFrames[Settings.PlayerLocation.Y].Substring(0, Settings.PlayerLocation.X)
                + Settings.Character
                + DisplayFrames[Settings.PlayerLocation.Y].Substring(Settings.PlayerLocation.X + 1, Settings.Width - (Settings.PlayerLocation.X + 2));
        }

        #endregion Display functionality

        /// <summary> Set the player's current location. </summary>
        /// <param name="playerLocation"><see cref="Location"/></param>
        public void SetPlayerLocation(Location playerLocation)
        {
            if (playerLocation.X > Width || playerLocation.X < 0 || playerLocation.Y > Height || playerLocation.Y < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(playerLocation));
            }

            PlayerLocation = playerLocation;
        }

        /// <summary> Start the <see cref="Game"/>. </summary>
        public void Start() => _autoResetEvent.WaitOne();

        /// <summary> End the <see cref="Game"/>. </summary>
        public static void End() => Environment.Exit(-1);

    }
}
