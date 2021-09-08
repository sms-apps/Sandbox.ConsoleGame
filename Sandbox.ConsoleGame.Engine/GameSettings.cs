namespace Sandbox.ConsoleGame.Engine
{
    public struct GameSettings
    {
        public char Background { get; }
        public char Character { get; }
        public short Height { get; }
        public Location PlayerLocation { get; }
        public short Width { get; }

        private GameSettings(short width, short height, char background, char chatacter, Location playerLocation)
        {
            Background = background;
            Character = chatacter;
            Height = height;
            PlayerLocation = playerLocation;
            Width = width;
        }

        public static GameSettings Create(short width, short height, char background, char chatacter, Location playerLocation)
        {
            // todo - sanity check
            return new GameSettings(width, height, background, chatacter, playerLocation);
        }
    }
}
