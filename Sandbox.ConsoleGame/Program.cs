using Sandbox.ConsoleGame.Engine;

var settings = GameSettings.Create(50, 25, '.', '*', Location.Create(25, 12));
var game = new Game(settings);
game.Start();