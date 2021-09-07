using System.Runtime.InteropServices;

namespace Sandbox.ConsoleGame.Ui
{
    public class ConsoleUserInterface : IUserInterface
    {
        public ConsoleUserInterface(int width, int height) =>
            Resize(width, height);

        /// <inheritdoc cref="IUserInterface"/>
        public void Clear() => Console.Clear();

        /// <inheritdoc cref="IUserInterface"/>
        public void Resize(int x, int y)
        {
            // TODO - figure out if you can set the windows size on any other platforms
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.CursorVisible = false;
                Console.SetWindowSize(1, 1);
                Console.SetBufferSize(x, y);
                Console.SetWindowSize(x, y);

            }
        }

        /// <inheritdoc cref="IUserInterface"/>
        public void Print(string message, bool newline = false)
        {
            if (newline) Console.WriteLine(message);
            else Console.Write(message);
        }

        /// <inheritdoc cref="IUserInterface"/>
        public void UpdateTitle(string title) =>
            Console.Title = title;
    }
}
