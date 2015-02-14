using System;

namespace SpaceGame
{
	class Shot : IPrintable
	{
		public int X { get; set; }

		public int Y { get; set; }

		//symbol for shots
		private const char Symbol = '"';

		//color for shots
		public ConsoleColor Color { get; set;}

		//constructor with parameters
		public Shot(int x, int y)
		{
			this.X = x;
			this.Y = y;
			this.Color = ConsoleColor.Red;
		}

		public void Print()
		{
			Console.SetCursorPosition(this.X, this.Y);
			Console.ForegroundColor = this.Color;
			Console.Write(Symbol);
		}
	}
}
