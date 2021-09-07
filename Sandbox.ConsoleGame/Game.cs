using Sandbox.ConsoleGame.Ui;

namespace Sandbox.ConsoleGame
{
    public class Game
    {
        private readonly AutoResetEvent _autoResetEvent;
        private readonly Timer _timer;
        private readonly GameLoop _gameLoop;

        public int TimerCallbackDelayMs = Constants.DefaultTimerCallbackDelayMs;
        public int TimerCallbackIntervalWaitMs = Constants.DefaultTimerCallbackIntervalWaitMs;

        public Game()
        {
            _autoResetEvent = new AutoResetEvent(false);
            var ui = new ConsoleUserInterface(GameState.Width, GameState.Height);
            _gameLoop = new GameLoop(ui);
            _timer = new Timer(_gameLoop.Render, _autoResetEvent, TimerCallbackDelayMs, TimerCallbackIntervalWaitMs);
        }

        public Game(int width, int height)
        {
            GameState.Width = width;
            GameState.Height = height;

            _autoResetEvent = new AutoResetEvent(false);
            var ui = new ConsoleUserInterface(GameState.Width, GameState.Height);
            _gameLoop = new GameLoop(ui);
            _timer = new Timer(_gameLoop.Render, _autoResetEvent, TimerCallbackDelayMs, TimerCallbackIntervalWaitMs);
        }

        public void Start() => _autoResetEvent.WaitOne();

    }
}
