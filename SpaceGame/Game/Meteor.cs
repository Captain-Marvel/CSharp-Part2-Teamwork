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
        private int x;
        private int y;
        private char symbol;
        private ConsoleColor color;

        // Holds X coordinate for the rock
        public int X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        // Holds Y coordinate for the rock
        public int Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        // Different symbol for each meteor
        public char Symbol
        {
            get { return this.symbol;}
            set {this.symbol = value; }
        }

        // Set color of current meteor
        public ConsoleColor Color
        {
            get { return this.color; }
            set { this.color = value; }
        }

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
