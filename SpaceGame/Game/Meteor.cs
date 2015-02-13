using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
	public class Meteor : IPrintable
	{
		// private fields

		// Holds X coordinate for the meteor
		public int X { get; set; }

		// Holds Y coordinate for the meteor
		public int Y { get; set; }

		// Different symbol for each meteor
		private char Symbol { get; set; }

		// Set color of current meteor
		public ConsoleColor Color { get; set; }

		// Set position of each meteor
		public void Print()
		{
			Console.SetCursorPosition(this.X, this.Y);
			Console.ForegroundColor = this.Color;
			Console.Write(this.Symbol);
		}

		// Random place generator
		public void SetRandom(int width)
		{
			Random generator = new Random();
		   
			// We start from top of the console coordinate system
			this.Y = 0;
			// Get random X coordinatie
			this.X = generator.Next(0, width);
			this.Color = Game.enemiesColors[generator.Next(0, Game.enemiesColors.Length)];
			this.Symbol = Game.enemyIcons[generator.Next(0, Game.enemyIcons.Length)];
		}
	}
}
