using Sandbox.ConsoleGame.Core;
using Sandbox.ConsoleGame.Ui;
using System.Text;

namespace Sandbox.ConsoleGame
{
    public class Game
    {
        private readonly AutoResetEvent _autoResetEvent;
        private readonly Timer _timer;
        private readonly GameLoop _gameLoop;

        public int TimerCallbackDelayMs = Constants.DefaultTimerCallbackDelayMs;
        public int TimerCallbackIntervalWaitMs = Constants.DefaultTimerCallbackIntervalWaitMs;

        public List<string> DisplayFrames { get; set; }
        public StringBuilder DisplayBuffer { get; set; }
        public int Height { get; set; } = Constants.DefaultGameFieldHeight;
        public int Width { get; set; } = Constants.DefaultGameFieldWidth;


        /// <summary> Create a new instance of the <see cref="Game"/>. </summary>
        /// <param name="width">Width of the play screen.</param>
        /// <param name="height">Height of the play screen.</param>
        /// <param name="userInterface"><see cref="IUserInterface"/> (will create a standard Console based UI if non is provided).</param>
        public Game(int width, int height, IUserInterface? userInterface = null)
        {
            Width = width;
            Height = height;
            DisplayBuffer = new StringBuilder();
            DisplayFrames = new List<string>(Height);

            // initialize game field
            for (int i = 0; i < Height; i++)
            {
                string line = string.Empty.Stuff(0, Width, Constants.DefaultBackgroundChar);
                DisplayFrames.Add(line);
            }

            // set up the user interface
            var ui = userInterface ?? new ConsoleUserInterface(Width, Height);
            _gameLoop = new GameLoop(ui, this);

            // set up the timer reset
            _autoResetEvent = new AutoResetEvent(false);
            _timer = new Timer(_gameLoop.Render, _autoResetEvent, TimerCallbackDelayMs, TimerCallbackIntervalWaitMs);
        }

        public void Start() => _autoResetEvent.WaitOne();

    }
}
