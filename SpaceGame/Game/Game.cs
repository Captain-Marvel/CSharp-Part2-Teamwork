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
		static int playerPosX;
		static int playerPosY;
		static string direction;

		// Keeps x and y coordinates of enemies spaceships
		static List<Meteor> meteors = new List<Meteor>();

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

		// Set amount of spaceship lives
		private static int livesCount = 5;

		static void Main()
		{

			Console.BufferHeight = Console.WindowHeight = maxHeight;
			Console.BufferWidth = Console.WindowWidth = maxWidth;

			playerPosX = Console.BufferWidth / 2;
			playerPosY = Console.BufferHeight - 1;

			//Menu with instructions
			DrawMenu();
			ConsoleKeyInfo pressedKey = Console.ReadKey();
			if (pressedKey.Key == ConsoleKey.Enter || pressedKey.Key == ConsoleKey.C)
			{
				if (pressedKey.Key == ConsoleKey.C) 
				{
					GameControls();
				}


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
		   
		}


		static void GameControls() 
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("                                           /\\         ");
			Console.WriteLine("                                        | /  \\ |");
			Console.WriteLine("                                        |/ () \\|");
			Console.WriteLine("                                        / (  ) \\");
			Console.WriteLine("                                       / (    ) \\");
			Console.WriteLine("                                      / (      ) \\");
			Console.WriteLine("                                     / (        ) \\");
			Console.WriteLine("                                    / (__________) \\");
			Console.WriteLine("                                   /________________\\");
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("                                Controls in SpaceGame are: ");
			Console.WriteLine();
			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("   Left arrow  <--  for Left  ");
			Console.WriteLine("   Right arrow -->  for Right");
			Console.WriteLine("   Spacebar to shoot");
			Thread.Sleep(4000);
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("                                         Be Ready");
			Thread.Sleep(1000);
			Console.WriteLine(  );
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("                                             3");
			Thread.Sleep(1000); 
			Console.WriteLine( );
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("                                             2");
			Console.WriteLine(  );
			Thread.Sleep(1000);
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("                                             1");
			Console.WriteLine( );
			Thread.Sleep(321);
			Console.ForegroundColor = ConsoleColor.White;
			Console.ForegroundColor = ConsoleColor.White;
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
			var removeMeteors = new List<int>();
			var newMeteors = new List<Meteor>();

			for (int i = 0; i < meteors.Count; i++)
			{
				if (meteors[i].X == playerPosX && meteors[i].Y == playerPosY - 1)
				{
					removeMeteors.Add(i);
					livesCount--;
				}
			}

			for (int i = 0; i < removeMeteors.Count; i++)
			{
				meteors.RemoveAt(removeMeteors[i]);
			}

			for (int i = 0; i < meteors.Count; i++)
			{
				if (!removeMeteors.Contains(i))
				{
					newMeteors.Add(meteors[i]);
				}
			}

			meteors = newMeteors;
		}

		private static void CollisionsEnemiesShots()
		{
			var meteorsToRemove = new List<int>();
			var shotsToRemove = new List<int>();

			for (int meteor = 0; meteor < meteors.Count; meteor++)
			{
				for (int shot = 0; shot < shots.Count; shot++)
				{
					if (shots[shot].X == meteors[meteor].X && shots[shot].Y == meteors[meteor].Y) 
					{
						meteorsToRemove.Add(meteor);
						shotsToRemove.Add(shot);
					}
				}
			}

			for (int i = 0; i < meteorsToRemove.Count; i++)
			{
				meteors.RemoveAt(meteorsToRemove[i]);
				shots.RemoveAt(shotsToRemove[i]);
			}

			var newMeteors = new List<Meteor>();

			for (int i = 0; i < meteors.Count; i++)
			{
				if (!meteorsToRemove.Contains(i))
				{
					newMeteors.Add(meteors[i]);
				}
			}

			var newShots = new List<Shot>();

			for (int i = 0; i < shots.Count; i++)
			{
				if (!shotsToRemove.Contains(i))
				{
					newShots.Add(shots[i]);
				}
			}
			
			meteors = newMeteors;
			shots = newShots;
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
	   
		static void DrawMenu()
		{
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("                                           /\\         ");
			Console.WriteLine("                                        | /  \\ |");
			Console.WriteLine("                                        |/ () \\|");
			Console.WriteLine("                                        / (  ) \\");
			Console.WriteLine("                                       / (    ) \\");
			Console.WriteLine("                                      / (      ) \\");
			Console.WriteLine("                                     / (        ) \\");
			Console.WriteLine("                                    / (__________) \\");
			Console.WriteLine("                                   /________________\\");
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("                                Welcome to SpaceGame");
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("   Press Enter for New Game");
			Console.WriteLine("   Press C to see the game controls");
			Console.WriteLine("   Press Esc to exit");
			Console.ForegroundColor = ConsoleColor.White;
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