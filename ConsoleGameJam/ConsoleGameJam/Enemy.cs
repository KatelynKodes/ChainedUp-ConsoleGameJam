using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGameJam
{
    class Enemy : Entity
    {
        private bool _restrained;

        public bool GetRestraintBool
        {
            get { return _restrained; }
        }

        //Constructor
        public Enemy(string EnemyName, char EnemyIcon, float EnemyHealth, float EnemyAttk, float EnemyDef) : base(EnemyName, EnemyIcon, EnemyHealth, EnemyAttk, EnemyDef)
        {
            
        }

        /// <summary>
        /// Changes the enemy's restrain state to a bool
        /// </summary>
        /// <param name="RestrainState"> The bool the restraint variable is changed to</param>
        public void ChangeRestrainState(bool RestrainState)
        {
            _restrained = RestrainState;
        }
    }
}
