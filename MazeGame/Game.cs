﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MazeGame
{
    class Game
    {

        private World MyWorld;
        private Player CurrentPlayer;
        private World2 MyWorld2;


        public void Start()
        {
            //This will set our console title
            Console.Title = "Silly Maze";
            //This will set our cursor to invisible
            Console.CursorVisible = false;

            MainMenu();

            //FirstMaze(); <--------This was the old way we ran it (we can revert to this if we dont want the menu)
            //SecondMaze(); <--------This was the old way we ran it (we can revert to this if we dont want the menu)
        }

        private void MainMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Welcome to Silly Maze\n" +
                    " \n" +
                    "To get started please select a number from the options below:\n" +
                    " \n" +
                    "1. Start Game\n" +
                    "2. Skip to Second Level\n" +
                    "3. Exit.");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        FirstMaze();
                        SecondMaze();
                        break;
                    case "2":
                        SecondMaze();
                        break;
                    case "3":
                        isRunning = false;
                        Console.WriteLine("Thank you for playing...");
                        Console.ReadKey();
                        break;
                    default:
                        break;
                }
                Console.Clear();
            }
        }

        //the SetCursorPosition sets x position and y position on console
        //Console.SetCursorPosition(4, 2);
        //X should move 5 positions from the left and 3 positions from the top
        //Console.Write("X");
        //We should be able to create more mazes and the code shouldnt change as long as the staring point is assigned and there is an "X".
        //We used ASCII symbols for a more pleasing look! we used "▀" for the bottom border and "▄" for the top border, we also used "█" as the walls and "§" as the player.
        public void FirstMaze()
        {
            // Array string[,]
            string[,] grid =
            {
                { "▄", "▄", "▄", "▄", "▄", "▄", "▄", "▄", "▄", "▄", "▄", "▄", "▄", "▄", "▄", "▄", "▄", },
                { "█", "█", "█", " ", " ", " ", " ", "█", "█", "█", "█", " ", "█", " ", " ", " ", "█", },
                { " ", " ", " ", " ", "█", "█", " ", "█", "█", "█", "█", " ", "█", " ", "█", " ", "█", },
                { "█", " ", "█", "█", " ", "█", " ", " ", " ", " ", "█", " ", "█", " ", "█", " ", "█", },
                { "█", " ", "█", "█", " ", "█", "█", "█", "█", " ", " ", " ", "█", " ", "█", " ", "█", },
                { "█", " ", "█", "█", " ", "█", "█", "█", "█", "█", "█", "█", "█", " ", "█", " ", "█", },
                { "█", " ", "█", " ", " ", " ", "█", "█", "█", "█", " ", " ", " ", " ", "█", " ", "X", },
                { "█", " ", "█", " ", "█", " ", "█", "█", "█", "█", " ", "█", "█", "█", "█", "█", "█", },
                { "█", " ", " ", " ", "█", " ", "█", "█", "█", "█", " ", "█", " ", " ", " ", " ", "█", },
                { "█", " ", "█", "█", "█", " ", "█", " ", " ", " ", " ", "█", "█", " ", "█", " ", "█", },
                { "█", " ", "█", " ", "█", " ", "█", " ", "█", "█", "█", "█", "█", " ", "█", " ", "█", },
                { "█", " ", " ", " ", "█", " ", "█", " ", " ", " ", " ", " ", "█", " ", "█", " ", "█", },
                { "█", " ", "█", "█", "█", " ", " ", " ", "█", "█", "█", " ", " ", " ", "█", " ", "█", },
                { "█", " ", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", " ", "█", },
                { "█", " ", " ", "█", "█", "█", " ", " ", " ", "█", "█", "█", " ", " ", " ", " ", "█", },
                { "█", "█", " ", " ", " ", " ", " ", "█", " ", " ", " ", " ", " ", "█", "█", "█", "█", },
                { "▀", "▀", "▀", "▀", "▀", "▀", "▀", "▀", "▀", "▀", "▀", "▀", "▀", "▀", "▀", "▀", "▀", },
            };


            MyWorld = new World(grid);

            CurrentPlayer = new Player(0, 2);

            RunGameLoop();

        }


        private void DrawFrame() 
        {
            Console.Clear();
            MyWorld.Draw();
            CurrentPlayer.Draw();
        }

        // This will allow us to set how the player will move the §
        public void HandlePlayerInput()
        {
            //This should prevent logging key strokes if the key is being held down.
            //this eliminated the lag response from the keys being held down and just registers the last key pressed!
            ConsoleKey key;
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                key = keyInfo.Key;

            } while (Console.KeyAvailable);

            //this is logging the key press even when held down
            //its registering the hold down as seperate key strokes creating lagged input and output.
            //ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            //ConsoleKey key = keyInfo.Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (MyWorld.isPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y - 1))// this will check if bool is met 
                    {
                        CurrentPlayer.Y -= 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (MyWorld.isPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y + 1))// this will check if bool is met 
                    {
                        CurrentPlayer.Y += 1;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (MyWorld.isPositionWalkable(CurrentPlayer.X - 1, CurrentPlayer.Y)) // this will check if bool is met 
                    {
                        CurrentPlayer.X -= 1;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (MyWorld.isPositionWalkable(CurrentPlayer.X + 1, CurrentPlayer.Y))// this will check if bool is met 
                    {
                        CurrentPlayer.X += 1;
                    }
                    break;
                default:
                    break;
            }

        }


        private void RunGameLoop()
        {
            //Stopwatch sw = Stopwatch.StartNew(); <-----------Didnt work
            /*public static void Timer() <------- This didnt work
            {
                Timer t = new Timer(TimerCallBack, null, 0, 2000);
                Console.ReadKey();
            }

            public static void TimerCallBack(Object O)
            {
                Console.WriteLine("Time Taken: " + DateTime.Now);

            }*/ // this whole timer didnt work but might work in another application. here for ref.

            //THIS FINALLY WORKED!!!! capturing the time taken to complete the level!!
            //This section of the Stopwatch will start when game starts
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Thread.Sleep(2000);


            DisplayIntro(); //this will always start before the level actually starts
            while (true)
            {
                //Draw everything
                DrawFrame();


                //Check for player input from the keyboard
                HandlePlayerInput();




                string elementAtPlayerPosition = MyWorld.GetElementAt(CurrentPlayer.X, CurrentPlayer.Y);
                if (elementAtPlayerPosition == "X")
                {
                    break;
                }
                /*get the console to render.
                We are controlling how fast the computer is going to render the map by ms*/
                System.Threading.Thread.Sleep(20);


            }
            //var watch = System.Diagnostics.Stopwatch.StartNew();<---------- This didnt work
            /*watch.Stop(); <------------Didnt Work
            var elapsedMs = watch.ElapsedMilliseconds;*/
            //sw.Stop();<---------This didnt work 
            //Console.WriteLine("Time Taken: {0}ms", sw.Elapsed.TotalMilliseconds);<---- this didnt work
            //THIS WORKED!
            //This part of the Stopwatch will stop when player gets to the end.
            DisplayOutro(); // this will always show after the level ends 
            stopwatch.Stop();
            TimeSpan stopwatchElapsed = stopwatch.Elapsed;
            Console.WriteLine(Convert.ToInt32(stopwatchElapsed.TotalSeconds) + " " + "seconds! You can do better!");
            Console.WriteLine("Press any Key to move on to the next level!\n" +
                "Please allow Maze to load this may take a couple seconds.....");
            Console.ReadKey();

        }
        private void DisplayIntro() // <-------- this will start on the FirstMaze()
        {
            Console.WriteLine("Instructions:\n" +
                "Use the Arrow Keys on your Keyboard to move");
            Console.Write("Try to get to X which will be green as shown ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("X");
            Console.ResetColor();
            Console.WriteLine("Press any Key to Start");
            Console.ReadKey();

        }

        private void DisplayOutro() // <-------- this will start on the FirstMaze() 
        {
            Console.Clear();
            Console.WriteLine("You Made it! That wasn't hard now was it??");
            Console.WriteLine("Press any Key to check your time.......");

            Console.ReadKey();

        }

        private void SecondMaze()
        {

            string[,] grid2 =
            {
                    { "▄", "▄", "▄", "▄", "▄", "▄", "▄", "▄", "▄", "▄", "▄", "▄", "▄", "▄", "▄", "▄", "▄", },
                    { "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", "█", " ", " ", " ", "█", },
                    { "█", "█", "█", "█", " ", " ", " ", " ", " ", "█", "█", "█", "█", " ", "█", " ", "█", },
                    { "█", "█", "█", "█", " ", "█", "█", "█", " ", "█", " ", " ", " ", " ", "█", " ", "█", },
                    { "█", " ", " ", " ", " ", "█", " ", " ", " ", "█", " ", "█", "█", "█", "█", " ", "█", },
                    { "█", " ", "█", "█", "█", " ", "█", "█", "█", "█", " ", "█", "█", "█", "█", "█", "█", },
                    { "█", " ", " ", " ", " ", " ", "█", "█", "█", "█", " ", "█", "█", " ", " ", " ", "█", },
                    { "█", " ", "█", "█", "█", "█", " ", " ", " ", " ", " ", "█", " ", " ", "█", " ", "█", },
                    { "█", " ", "█", "█", "█", "█", " ", "█", "█", "█", "█", "█", " ", "█", "█", " ", "█", },
                    { "█", " ", " ", " ", " ", "█", " ", " ", " ", "█", "█", "█", " ", " ", "█", " ", "█", },
                    { "█", "█", " ", "█", " ", " ", " ", "█", "█", " ", " ", " ", " ", "█", "█", " ", "█", },
                    { "█", "█", " ", "█", " ", "█", "█", "█", " ", " ", "█", "█", "█", " ", "█", " ", "█", },
                    { "█", "█", " ", "█", " ", "█", "█", "█", " ", "█", "█", "█", "█", " ", "█", " ", "█", },
                    { "█", "█", " ", "█", " ", "█", "█", "█", " ", "█", "█", " ", " ", " ", "█", " ", "█", },
                    { "█", "█", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "█", "█", " ", "█", },
                    { "█", "█", " ", "█", "█", "█", "█", "█", "█", "█", "█", "█", " ", " ", "█", " ", "X", },
                    { "▀", "▀", " ", "▀", "▀", "▀", "▀", "▀", "▀", "▀", "▀", "▀", "▀", "▀", "▀", "▀", "▀", },
            };

            MyWorld2 = new World2(grid2);

            CurrentPlayer = new Player(2, 16);

            RunGameLoop2();
        }
        private void DrawFrame2()
        {
            Console.Clear();
            MyWorld2.Draw();
            CurrentPlayer.Draw();
        }

        // This will allow us to set how the player will move the §
        public void HandlePlayerInput2()
        {
            
            ConsoleKey key;
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                key = keyInfo.Key;

            } while (Console.KeyAvailable);

            //this is logging the key press even when held down
            //its registering the hold down as seperate key strokes creating lagged input and output.
            //ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            //ConsoleKey key = keyInfo.Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (MyWorld2.isPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y - 1))// this will check if bool is met 
                    {
                        CurrentPlayer.Y -= 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (MyWorld2.isPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y + 1))// this will check if bool is met 
                    {
                        CurrentPlayer.Y += 1;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (MyWorld2.isPositionWalkable(CurrentPlayer.X - 1, CurrentPlayer.Y)) // this will check if bool is met 
                    {
                        CurrentPlayer.X -= 1;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (MyWorld2.isPositionWalkable(CurrentPlayer.X + 1, CurrentPlayer.Y))// this will check if bool is met 
                    {
                        CurrentPlayer.X += 1;
                    }
                    break;
                default:
                    break;
            }

        }


        private void RunGameLoop2()
        {

            //This section of the Stopwatch will start when game starts
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Thread.Sleep(2000); // this is counting by 2 seconds. We could test it at 1 second intervals but its working so ya lol


            DisplayIntro2();
            while (true)
            {
                //Draw everything
                DrawFrame2();


                //Check for player input from the keyboard
                HandlePlayerInput2();




                string elementAtPlayerPosition = MyWorld2.GetElementAt(CurrentPlayer.X, CurrentPlayer.Y);
                if (elementAtPlayerPosition == "X")
                {
                    break;
                }
                /*get the console to render.
                We are controlling how fast the computer is going to render itself by ms*/
                System.Threading.Thread.Sleep(20);


            }

            //This part of the Stopwatch will stop when player gets to the end.
            DisplayOutro2();
            stopwatch.Stop();
            TimeSpan stopwatchElapsed = stopwatch.Elapsed;
            Console.WriteLine(Convert.ToInt32(stopwatchElapsed.TotalSeconds) + " " + "seconds! You can do better!");
            Console.WriteLine("Press any Key to Exit");
            Console.ReadKey();

        }
        private void DisplayIntro2() // <-------- this will start on the SecondMaze()
        {
            Console.Write("Try to get to X which will be Cyan as shown ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("X");
            Console.ResetColor();
            Console.WriteLine("Press any Key to Start");
            Console.ReadKey();

        }

        private void DisplayOutro2() // <-------- this will start on the SecondMaze()
        {
            Console.Clear();
            Console.WriteLine("You Made it! That wasnt hard now was it?");
            Console.WriteLine("Thanks for playing!");
            Console.WriteLine("Press any Key to check your time.......");
            Console.ReadKey();
        }
    }
}
