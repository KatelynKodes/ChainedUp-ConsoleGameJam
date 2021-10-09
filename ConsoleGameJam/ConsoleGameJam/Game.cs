using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGameJam
{
    class Game
    {
        private bool _gameOver;
        Map map = new Map();

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
            map.Start();
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
