using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGameJam
{
    class Player : Entity
    {
        public Player(string playerName, char playerIcon, float playerHP, float playerAttk, float playerDef) : base(playerName, playerIcon, playerHP, playerAttk, playerDef)
        {
            
        }
    }
}
