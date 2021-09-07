using Sandbox.ConsoleGame.Ui;

namespace Sandbox.ConsoleGame
{
    public class GameLoop
    {
        private readonly IUserInterface _userInterface;

        private int _loopCount;
        private DateTime _started = DateTime.Now;
        private Game _game;

        public GameLoop(IUserInterface userInterface, Game game)
        {
            _userInterface = userInterface;
            _loopCount = 0;
            _game = game;
        }

        public void HandleUserInput()
        {
            // todo
            throw new NotImplementedException();
        }

        public void ProcessWorldChanges()
        {
            // todo
            throw new NotImplementedException();
        }

        public void Render(object stateInfo)
        {
            if (stateInfo is null) throw new ArgumentNullException(nameof(stateInfo));

            _game.DisplayBuffer.Clear();
            _game.DisplayFrames.ForEach(frame => _game.DisplayBuffer.Append(frame));

            _userInterface.Clear();
            _userInterface.Print(_game.DisplayBuffer.ToString());

            _userInterface.UpdateTitle(_loopCount++.ToString());
        }
    }
}
