using System;
using System.Collections.Generic;
using System.Threading;

namespace SpaceGame
{
    class Game
    {
        // Set console max width and height
        private const int maxWidth = 35;
        private const int maxHeight = 30;

        // Keeps the x coordinate of our spaceship position 
        static int playerPosX = 0;
        static int playerPosY = 0;
        static string direction = null;

        // Keeps x and y coordinates of enemies spaceships
        static List<List<int>> enemies = new List<List<int>>();

        // Keeps x and y coordinates of our shots
        static List<List<int>> shots = new List<List<int>>();

        // Set spaceships and shots icons
        private const char playerIcon = 'Ä';
        private const char enemyIcon = '#';
        private const char shotIcon = '"';

        // Set spaceships and shots colors
        private const ConsoleColor playerColor = ConsoleColor.Cyan;
        private const ConsoleColor enemiesColor = ConsoleColor.DarkRed;
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

                // After certian amount of meteors destyoed increase speed
                IncreaseLevel();

                Thread.Sleep(200);

                Console.Clear();
            }

            // Store points per meteor hit
            StorePoints();

            //Draw final scores
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

        }

        private static void UpdateEnemies()
        {

        }

        private static void GenerateEnemyAtRandomPosition()
        {
            int randomEnemyPosition = rnd.Next(0, Console.WindowWidth);
        }

        private static void Shoot()
        {

        }

        private static void Draw()
        {
            DrawPlayer();
            DrawEnemies();
            DrawShots();
        }

        private static void DrawShots()
        {

        }

        private static void DrawEnemies()
        {

        }

        private static void DrawPlayer()
        {
            List<int> playerCoordinates = new List<int>() { playerPosX, playerPosY };
            ConsoleColor playerColor = ConsoleColor.Cyan;


            DrawSymbolAtSpecificCoordinates(playerCoordinates, playerIcon, playerColor);
        }

        private static void DrawSymbolAtSpecificCoordinates(List<int> playerCoordinates, char c, ConsoleColor playerColor)
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
        }

        private static void DrawScoreBoard()
        {
        }

        private static void StorePoints()
        {

        }
    }
}