using System;
using System.Collections.Generic;
using System.Threading;

namespace SpaceGame
{
    public class Game
    {
        // Set console max width and height
        private const int maxWidth = 40;
        private const int maxHeight = 40;

        // Keeps the x coordinate of our spaceship position 
        static readonly int playerPosX = Console.BufferWidth / 2;
        static readonly int playerPosY = Console.BufferHeight - 1;

        // Keeps x and y coordinates of enemies spaceships
        static List<List<int>> enemies = new List<List<int>>();

        static List<Meteor> meteors = new List<Meteor>();

        // Keeps x and y coordinates of our shots
        static List<List<int>> shots = new List<List<int>>();

        // Set spaceships and shots icons
        private const char playerIcon = 'Ä';
        public  static char[] enemyIcons =  new char[] {'#', '*', '@'};
        private const char shotIcon = '"';

        // Set spaceships and shots colors
        private const ConsoleColor playerColor = ConsoleColor.Cyan;
        public static ConsoleColor[] enemiesColors =  {ConsoleColor.Red, ConsoleColor.DarkCyan,
                                                      ConsoleColor.Blue, ConsoleColor.Magenta,
                                                      ConsoleColor.DarkYellow, ConsoleColor.DarkRed,
                                                      ConsoleColor.DarkGreen, ConsoleColor.DarkBlue};

        private const ConsoleColor shotsColor = ConsoleColor.DarkYellow;

        // Set amount of spaceship lives
        private const int livesCount = 5;

        // Make global random variable
        static readonly Random rnd = new Random();

        static void Main()
        {
            Console.BufferHeight = Console.WindowHeight = maxHeight;
            Console.BufferWidth = Console.WindowWidth = maxWidth;


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
            foreach (var meteor in meteors)
            {
                meteor.Print();
            }
        }

        private static void DrawPlayer()
        {
            List<int> playerCoordinates = new List<int>() { playerPosX, playerPosY };


            DrawSymbolAtSpecificCoordinates(playerCoordinates, playerIcon, playerColor);
        }

        private static void DrawSymbolAtSpecificCoordinates(List<int> playerCoordinates, char c, ConsoleColor playerColor)
        {

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
                MovePlane();
            }

            else if (userInput.Key == ConsoleKey.RightArrow)
            {
                MovePlane();
            }

            else if (userInput.Key == ConsoleKey.UpArrow)
            {
                MovePlane();
            }

            else if (userInput.Key == ConsoleKey.DownArrow)
            {
                MovePlane();
            }
        }

        private static void MovePlane()
        {

        }
        private static void DrawMenuScreen()
        {

        }

        private static void IncreaseLevel()
        {

            // Thread sleep will be changed when level is increased
            Thread.Sleep(300);
        }

        private static void DrawScoreBoard()
        {
        }

        private static void StorePoints()
        {

        }
    }
}