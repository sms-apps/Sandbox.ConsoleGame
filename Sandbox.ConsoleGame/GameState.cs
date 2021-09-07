using System.Text;

namespace Sandbox.ConsoleGame
{
    public class GameState
    {
        public static string State { get; } = Constants.InitialGameState;

        public static List<string> DisplayFrames { get; set; } = new List<string>(Height);
        public static StringBuilder DisplayBuffer { get; set; } = new StringBuilder();

        public static int Height { get; set; } = Constants.DefaultGameFieldHeight;
        public static int Width { get; set; } = Constants.DefaultGameFieldWidth;
    }
}
