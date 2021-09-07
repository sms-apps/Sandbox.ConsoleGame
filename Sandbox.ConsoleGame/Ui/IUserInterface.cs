namespace Sandbox.ConsoleGame.Ui
{
    public interface IUserInterface
    {
        /// <summary> Print out message. </summary>
        /// <param name="message">Message to print.</param>
        /// <param name="newline">Print a newline after the message?</param>
        void Print(string message, bool newline = false);

        /// <summary> Resize the window (if possible, depending on platform). </summary>
        /// <remarks>Currently only available on Windows.</remarks>
        void Resize(int x, int y);

        /// <summary> Clear the UI. </summary>
        void Clear();
    }
}
