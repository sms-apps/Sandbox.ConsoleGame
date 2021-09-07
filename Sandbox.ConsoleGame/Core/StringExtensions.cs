using System.Text;

namespace Sandbox.ConsoleGame.Core
{
    static class StringExtensions
    {
        public static string Stuff(this string str, int location, int length, char ch)
        {
            if (str == null) throw new ArgumentNullException(nameof(str));

            StringBuilder result = new(str.Length + length);
            result.Append(str.AsSpan(0, location));
            for (int i = 0; i < length; i++) result.Append(ch);
            result.Append(str.AsSpan(location, str.Length));
            return result.ToString();
        }

        public static string Splice(this string str, int start, int length, string replacement) =>
            string.Concat(str.AsSpan(0, start), replacement, str.AsSpan(start + length));

    }
}
