using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGameJam
{
    class Game
    {
        private bool _gameOver;

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

        private void Start()
        {
            
        }

        private void Update()
        { 

        }

        private void End()
        { 
        }

        private void Draw()
        { 
        }
    }
}
