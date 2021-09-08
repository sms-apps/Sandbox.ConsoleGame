namespace Sandbox.ConsoleGame.Engine
{
    public struct Location
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        private Location(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Location Create(int x, int y)
        {
            // todo - sanity checking
            return new Location(x, y);
        }
    }
}
