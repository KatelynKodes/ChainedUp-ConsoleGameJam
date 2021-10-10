using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGameJam
{
    enum Scene
    {
        MAINMENU,
        INTRO,
        BATTLE,
        REPLAYMENU
    }

    class Game
    {
        private bool _gameOver;
        private Scene _currentScene;
        private Enemy _currentEnemy;
        private Player _player;

        private Enemy _dwarfEnemy;
        private Enemy _TrollEnemy;
        private Enemy _goblinEnemy;
        private Enemy _OrcWarden;
        private Enemy[] _Enemies;

        private int CurrentEnemyIndex;


        /// <summary>
        /// Called when the game runs
        /// </summary>
        public void Run()
        {
            Start();
            while (!_gameOver)
            {
                Update();
            }
            End();
        }

        private void InitializeEnemies()
        {
            _dwarfEnemy = new Enemy("Dwarf", 'D', 200, 20, 30);
            _TrollEnemy = new Enemy("Troll", 'T', 300, 40, 20);
            _goblinEnemy = new Enemy("Goblin", 'G', 300, 30, 30);
            _OrcWarden = new Enemy("Orc Warden", 'O', 400, 20, 30);
            _Enemies = new Enemy[] { _dwarfEnemy, _TrollEnemy, _goblinEnemy, _OrcWarden };
        }

        /// <summary>
        /// Called at the start of the game
        /// </summary>
        private void Start()
        {
            _gameOver = false;
            _currentScene = Scene.MAINMENU;
            _player = new Player("The Prisoner", 'P', 400, 40, 30);
            CurrentEnemyIndex = 0;
            InitializeEnemies();
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
                case Scene.INTRO:
                    IntroScene();
                    break;
                case Scene.BATTLE:
                    Fight();
                    CheckMonsterHealth();
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
            int PlayGame = GetInput("CHAINED UP: A Console Game Jam Game", "Play Game", "Quit");
            switch (PlayGame)
            {
                case 1:
                    _currentScene = Scene.INTRO;
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
                    _currentScene = Scene.INTRO;
                    _player = new Player("The Prisoner", 'P', 400, 40, 30);
                    CurrentEnemyIndex = 0;
                    InitializeEnemies();
                    break;
                case 2:
                    _gameOver = true;
                    break;
            }
        }

        public void Fight()
        {
            float damageDealt = 0;
            string previousEnemyState = "free";
            int turn = 1;
            _currentEnemy = _Enemies[CurrentEnemyIndex];

            while (_currentEnemy.GetHealth > 0 && _player.GetHealth > 0)
            {
                Console.Clear();
                _player.PrintStats();
                Console.WriteLine("");
                _currentEnemy.PrintStats();
                Console.ReadKey(true);

                if (turn == 1)
                {
                    int playerchoice = GetInput("What does " + _player.GetName + " do??", "Attack", "Restrain");
                    switch (playerchoice)
                    {
                        case 1:
                            damageDealt = _player.Attack(_currentEnemy);
                            _currentEnemy.DecreaseHealth(damageDealt);
                            Console.WriteLine(_player.GetName + " Attacked " + _currentEnemy.GetName +
                                "And did " + damageDealt + " damage");
                            Console.ReadKey(true);
                            turn = 2;
                            break;
                        case 2:
                            _currentEnemy.ChangeRestrainState(true);
                            Console.WriteLine(_player.GetName + " restrained the " + _currentEnemy.GetName);
                            Console.ReadKey(true);
                            turn = 2;
                            break;
                    }
                }
                else if (turn == 2)
                {
                    if (!_currentEnemy.GetRestraintBool)
                    {
                        Console.Clear();
                        damageDealt = _currentEnemy.Attack(_player);
                        _player.DecreaseHealth(damageDealt);
                        Console.WriteLine("The " + _currentEnemy.GetName + " Attacked " + _player.GetName +
                            "And did " + damageDealt + " damage");
                        Console.ReadKey(true);
                        turn = 1;
                    }
                    else
                    {
                        if (previousEnemyState.ToLower() == "restrained")
                        {
                            Console.Clear();
                            Console.WriteLine("The " + _currentEnemy.GetName + " freed itself!");
                            Console.ReadKey(true);
                            damageDealt = _currentEnemy.Attack(_player);
                            _currentEnemy.DecreaseHealth(damageDealt);
                            Console.WriteLine("The " + _currentEnemy.GetName + " Attacked " + _player.GetName +
                                "And did " + damageDealt + " damage");
                            Console.ReadKey(true);
                            turn = 1;
                        }
                        else
                        {
                            Console.Clear();
                            _currentEnemy.ChangeRestrainState(false);
                            Console.WriteLine("The " + _currentEnemy.GetName + " is restrained.");
                            Console.ReadKey(true);
                            turn = 1;
                        }
                    }
                }
            }
        }

        public void CheckMonsterHealth()
        {
            if (_currentEnemy.GetHealth <= 0)
            {
                if (!IncreaseIndex())
                {
                    Console.Clear();
                    Console.WriteLine("YOU WON");
                    Console.ReadKey(true);
                    Console.WriteLine("Running towards the door of the dungeon you manage to escape" +
                        " fleeing out into the night.");
                    Console.ReadKey(true);
                    _currentScene = Scene.REPLAYMENU;
                    return;
                }
                CurrentEnemyIndex++;
            }
            if (_player.GetHealth <= 0)
            {
                Console.Clear();
                Console.WriteLine("YOU LOST");
                Console.ReadKey();
                _currentScene = Scene.REPLAYMENU;
            }
        }

        public bool IncreaseIndex()
        {
            bool CanIncrease = true;
            if ((CurrentEnemyIndex + 1) > _Enemies.Length)
            {
                CanIncrease = false;
            }
            return CanIncrease;
        }

        public void IntroScene()
        {
            Console.Clear();
            Console.WriteLine("After being imprisoned for their crimes, " + _player.GetName 
                + " Has been shoved into a dungeon filled with monsters and trolls");
            Console.ReadKey(true);
            Console.WriteLine("Now they have to escape only using the chains they were locked up with");
            Console.ReadKey(true);
            _currentScene = Scene.BATTLE;
        }
    }
}
