using System;
using System.Collections.Generic;
using System.Threading;

namespace SpaceGame
{
	public class Game
	{
		// Set console max width and height
		private const int maxWidth = 80;
		private const int maxHeight = 35;

		// Keeps the x coordinate of our spaceship position 
		static int playerPosX = 0;
		static int playerPosY = 0;
		static string direction = null;

		// Keeps x and y coordinates of enemies spaceships
		static List<List<int>> enemies = new List<List<int>>();

		static readonly List<Meteor> meteors = new List<Meteor>();

		// Keeps x and y coordinates of our shots
		static List<Shot> shots = new List<Shot>();

		// Set spaceships and shots icons
		private const char playerIcon = 'Ä';

		// Multiple meteors
		public static readonly char[] enemyIcons = { '#', '*', '@' };
		private const char shotIcon = '"';

		// Set spaceships and shots colors
		private const ConsoleColor playerColor = ConsoleColor.Cyan;

		public static readonly ConsoleColor[] enemiesColors =  
		{
			ConsoleColor.Blue, 
			ConsoleColor.Magenta,
			ConsoleColor.DarkYellow,
			ConsoleColor.DarkRed,
			ConsoleColor.DarkGreen, 
			ConsoleColor.DarkBlue
		};

		private const ConsoleColor shotsColor = ConsoleColor.DarkYellow;

		// Set amount of spaceship lives
		private const int livesCount = 5;

		// Make global random variable
		static readonly Random rnd = new Random();

		static void Main()
		{
			Console.BufferHeight = Console.WindowHeight = maxHeight;
			Console.BufferWidth = Console.WindowWidth = maxWidth;

			playerPosX = Console.BufferWidth / 2;
			playerPosY = Console.BufferHeight - 1;



			//Menu with instructions
			DrawMenuScreen();

			while (livesCount >= 0)
			{
				// Game World

				GenerateEnemyAtRandomPosition();

				Update();

				Draw();

				if (Console.KeyAvailable)
				{
					// Set player game keys
					ControlPlayer();
				}

				// After certain amount of falling objects was detroyed, new game level reached
				IncreaseLevel();

				Console.Clear();
			}

			// Store points per meteor hit
			StorePoints();

			// Draw final scores
			DrawScoreBoard();
			Console.WriteLine("You are dead! Continue (Y/N):");
		}




		private static void Update()
		{
			// Update Game World
			UpdateEnemies();
			UpdateShots();
			CollisionsEnemiesShots();
			CollisionsEnemiesPlayer();
		}

		private static void CollisionsEnemiesPlayer()
		{

		}

		private static void CollisionsEnemiesShots()
		{

		}

		private static void UpdateShots()
		{
            for (int i = 0; i < shots.Count; i++)
            {
                shots[i].Y -= 1;

                if (shots[i].Y <= 0)
                {
                    shots.Remove(shots[i]);
                }
            }
		}

		private static void UpdateEnemies()
		{

		}

		private static void GenerateEnemyAtRandomPosition()
		{
			Meteor meteor = new Meteor();
			meteor.SetRandom(maxWidth);
			meteors.Add(meteor);

			for (int meteorIndex = 0; meteorIndex < meteors.Count; meteorIndex++)
			{
				meteors[meteorIndex].Y += 1;
				if (meteors[meteorIndex].Y >= maxHeight)
				{
					meteors.Remove(meteors[meteorIndex]);
				}
			}
		}

		private static void Shoot()
		{
            Shot shot = new Shot(playerPosX, playerPosY - 1);

            shots.Add(shot);

          
		}

		private static void Draw()
		{
			DrawPlayer();
			DrawEnemies();
			DrawShots();
		}

		private static void DrawShots()
		{
            for (int i = 0; i < shots.Count; i++ )
            {
                shots[i].Print();
            }

        }

		private static void DrawEnemies()
		{
			foreach (var meteor in meteors)
			{
				meteor.Print();
			}
		}

		private static void DrawPlayer()
		{
			List<int> playerCoordinates = new List<int>() { playerPosX, playerPosY };
			


			DrawSymbolAtSpecificCoordinates(playerCoordinates, playerIcon);
		}

		private static void DrawSymbolAtSpecificCoordinates(List<int> playerCoordinates, char c)
		{
			Console.SetCursorPosition(playerPosX, playerPosY);
			Console.ForegroundColor = playerColor;
			Console.WriteLine(c);
		}

		private static void ControlPlayer()
		{
			ConsoleKeyInfo userInput = Console.ReadKey(true);
			while (Console.KeyAvailable)
			{
				Console.ReadKey(true);
			}
			if (userInput.Key == ConsoleKey.Spacebar)
			{
				Shoot();
			}
			else if (userInput.Key == ConsoleKey.LeftArrow)
			{
				direction = "left";
				MovePlane();
			}

			else if (userInput.Key == ConsoleKey.RightArrow)
			{
				direction = "right";
				MovePlane();
			}

			else if (userInput.Key == ConsoleKey.UpArrow)
			{
				direction = "up";
				MovePlane();
			}

			else if (userInput.Key == ConsoleKey.DownArrow)
			{
				direction = "down";
				MovePlane();
			}
            else if (userInput.Key == ConsoleKey.Spacebar)
            {
                Shoot();
            }
		}

		private static void MovePlane()
		{
			if (direction == "left")
			{
				if (playerPosX - 1 > 0)
				{
					playerPosX--;
				}
			}

			if (direction == "right")
			{
				if (playerPosX + 1 < maxWidth - 1)
				{
					playerPosX++;
				}
			}

			// Adding extra extra spaceship movement abilities

			//if (direction == "up")
			//{
			//    if (playerPosY - 1 > 0)
			//    {
			//        playerPosY--;
			//    }
			//}
			//if (direction == "down")
			//{
			//    if (playerPosY + 1 < maxHeight - 1)
			//    {
			//        playerPosY++;
			//    }
			//}
		}
		private static void DrawMenuScreen()
		{

		}

		private static void IncreaseLevel()
		{

			// Thread sleep will be changed when level is increased
			Thread.Sleep(100);
		}

		private static void DrawScoreBoard()
		{
		}

		private static void StorePoints()
		{

		}
	}
}