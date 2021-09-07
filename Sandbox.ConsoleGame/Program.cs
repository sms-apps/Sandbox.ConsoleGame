using Sandbox.ConsoleGame;
using Sandbox.ConsoleGame.Core;

var game = new Game(20, 10);
GameState.DisplayFrames = new List<string>(GameState.Height);

var backGround = '.';
var character = '*';

// initialize game field
for (int i = 0; i < GameState.Height; i++)
{
    string line = string.Empty.Stuff(0, GameState.Width, backGround);

    if (i == 5)
    {
        line = line.Substring(0, 9) + character + line.Substring(11, 9);
    }

    GameState.DisplayFrames.Add(line);
}

game.Start();