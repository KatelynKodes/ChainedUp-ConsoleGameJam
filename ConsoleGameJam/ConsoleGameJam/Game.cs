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
        private Scene _scene;

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
        }

        private void Draw()
        { 
        }

        /// <summary>
        /// Displays the current scene based on the current enum in the _scene variable
        /// </summary>
        private void DisplayCurrentScene()
        {
            switch (_scene)
            {
                case Scene.MAINMENU:
                    break;
                case Scene.PRISON:
                    break;
                case Scene.BATTLE:
                    break;
                case Scene.REPLAYMENU:
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
                    //If not, 
                    if (CurrentInput > Options.Length || CurrentInput < 0)
                    {
                        CurrentInput = -1;
                    }
                }
                else
                {
                    for (int i = 0; i < Options.Length; i++)
                    {
                        if (PlayerInput.ToLower() == Options[i].ToLower())
                        {
                            CurrentInput = i + 1;
                            break;
                        }
                        else
                        {
                            CurrentInput = -1;
                        }
                    }

                    if (CurrentInput == -1)
                    {
                        Console.WriteLine("Invalid Input");
                        Console.ReadKey(true);
                    }
                }
            }

            return CurrentInput;
        }

    }
}
