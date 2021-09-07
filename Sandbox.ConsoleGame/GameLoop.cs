using Sandbox.ConsoleGame.Ui;

namespace Sandbox.ConsoleGame
{
    public class GameLoop
    {
        private readonly IUserInterface _userInterface;

        private int _loopCount;
        private DateTime _started = DateTime.Now;

        public GameLoop(IUserInterface userInterface)
        {
            _userInterface = userInterface;
            _loopCount = 0;
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

            GameState.DisplayBuffer.Clear();
            GameState.DisplayFrames.ForEach(frame => GameState.DisplayBuffer.Append(frame));

            _userInterface.Clear();
            _userInterface.Print(GameState.DisplayBuffer.ToString());
        }
    }
}
