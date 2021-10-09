using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGameJam
{
    enum Scene
    {
        MAINMENU,
        PRISON,
        BATTLE,
        REPLAYMENU
    }

    class Game
    {
        private bool _gameOver;
        private Scene _currentScene;

        /// <summary>
        /// Called when the game runs
        /// </summary>
        public void Run()
        {
            Start();
            while (!_gameOver)
            {
                Draw();
                Update();
            }
            End();
        }

        /// <summary>
        /// Called at the start of the game
        /// </summary>
        private void Start()
        {
            _gameOver = false;
            _currentScene = Scene.MAINMENU;
        }

        /// <summary>
        /// Called every time the game loops
        /// </summary>
        private void Update()
        {
            DisplayCurrentScene();
        }

        /// <summary>
        /// Called at the end of the game
        /// </summary>
        private void End()
        {
            Console.WriteLine("The application has ended, please close the console window");
        }

        private void Draw()
        { 
        }

        /// <summary>
        /// Displays the current scene based on the current enum in the _scene variable
        /// </summary>
        private void DisplayCurrentScene()
        {
            switch (_currentScene)
            {
                case Scene.MAINMENU:
                    DisplayMainMenu();
                    break;
                case Scene.PRISON:
                    break;
                case Scene.BATTLE:
                    break;
                case Scene.REPLAYMENU:
                    DisplayReplayMenu();
                    break;
            }
        }

        /// <summary>
        /// Displays options for the player to choose from
        /// </summary>
        /// <param name="Desc"> The prompt the player must answer </param>
        /// <param name="Options"> The options the player can choose from </param>
        /// <returns></returns>
        private int GetInput(string Desc, params string[] Options)
        {
            int CurrentInput = -1;
            string PlayerInput;

            while (CurrentInput == -1)
            {
                //Prints the options onto the console
                Console.Clear();
                Console.WriteLine(Desc);
                for (int i = 0; i < Options.Length; i++)
                {
                    Console.WriteLine("[" + (i + 1) + "] " + Options[i]);
                }

                // Allows the player to type their input
                Console.Write(">");
                PlayerInput = Console.ReadLine();

                //Checks if the input is a number
                if (int.TryParse(PlayerInput, out CurrentInput))
                {
                    //If it is, check if the currentInput is not greator than the options length
                    //Or less than 0
                    if (CurrentInput > Options.Length || CurrentInput < 0)
                    {
                        CurrentInput = -1;
                    }
                }
                else
                {
                    //If not, check if the input when set to lowercase
                    //is equal to one of the options when set to lowercase
                    for (int i = 0; i < Options.Length; i++)
                    {
                        if (PlayerInput.ToLower() == Options[i].ToLower())
                        {
                            //If it is, sets the currentinput to i+1
                            CurrentInput = i + 1;
                            break;
                        }
                        else
                        {
                            //If not, set CurrentInput to -1
                            CurrentInput = -1;
                        }
                    }

                    //If CurrentInput is still equal to -1, return invalid input and repeat the loop
                    if (CurrentInput == -1)
                    {
                        Console.WriteLine("Invalid Input");
                        Console.ReadKey(true);
                    }
                }
            }

            return CurrentInput;
        }

        /// <summary>
        /// Displays main menu to player and allows them to play or quit the game
        /// </summary>
        private void DisplayMainMenu()
        {
            int PlayGame = GetInput("[Game Name title]: A Console Game Jam Game", "Play Game", "Quit");
            switch (PlayGame)
            {
                case 1:
                    _currentScene = Scene.PRISON;
                    break;
                case 2:
                    _gameOver = true;
                    break;
            }
        }

        /// <summary>
        /// Displays the replay menu and resets values so player can replay game
        /// </summary>
        private void DisplayReplayMenu()
        {
            int RestartGame = GetInput("PLAY AGAIN?", "Yes", "No");
            switch (RestartGame)
            {
                case 1:
                    _currentScene = Scene.PRISON;
                    break;
                case 2:
                    _gameOver = true;
                    break;
            }
        } 
    }
}
