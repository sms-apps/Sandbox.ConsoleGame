using Sandbox.ConsoleGame.Engine.Ui;

namespace Sandbox.ConsoleGame.Engine
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

            // todo - something with stateInfo?
            // todo - hook up events for "prerender" and "postrender" and call them here somewhere

            _game.DisplayRender();
        }
    }
}
