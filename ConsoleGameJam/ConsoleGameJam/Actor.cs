using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGameJam
{
    class Actor
    {
        private char _icon;
        private string _name;

        public string GetName
        {
            get{ return _name; }
        }

        public Actor(string ActorName, char Sprite)
        {
            _name = ActorName;
            _icon = Sprite;
        }

        public virtual void Start()
        {
            
        }

        public virtual void Update()
        { 

        }

        public virtual void Draw()
        {
            
        }

        public void End()
        { 
        }

        public virtual void PrintStats()
        {
            Console.WriteLine("NAME: " + _name);
        }
    }
}
