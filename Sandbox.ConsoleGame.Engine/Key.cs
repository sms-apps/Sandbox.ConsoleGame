namespace Sandbox.ConsoleGame.Engine
{
    public class Key
    {
        public enum Direction
        {
            North,
            South,
            East,
            West
        }

        /// <summary> Valid keys with their equivalent direction. </summary>
        private static Dictionary<ConsoleKey, Direction> directionKeys = new()
        {
            { ConsoleKey.UpArrow, Direction.North },
            { ConsoleKey.W, Direction.North },

            { ConsoleKey.LeftArrow, Direction.West },
            { ConsoleKey.A, Direction.West },

            { ConsoleKey.DownArrow, Direction.South },
            { ConsoleKey.S, Direction.South },

            { ConsoleKey.RightArrow, Direction.East },
            { ConsoleKey.D, Direction.East }
        };

        public static void Press()
        {
            while (true)
            {
                var Key = Console.ReadKey().Key;

                switch (Key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        break;

                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.A:
                        break;

                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        //Speed.Set.Delay /= 5;
                        //Speed.Set.Drop = true;
                        break;

                    case ConsoleKey.RightArrow:
                    case ConsoleKey.D:
                        break;

                    case ConsoleKey.Escape:
                        Game.End();
                        break;
                }
            }
        }
    }
}