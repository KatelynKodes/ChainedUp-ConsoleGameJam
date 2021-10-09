using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGameJam
{
    class Entity : Actor
    {
        private float _health;
        private float _attkPowr;
        private float _defensePowr;

        //Properties returning the values of health, attkPowr and defensePowr
        public float GetHealth
        {
            get { return _health; }
        }
        public float GetAttk
        {
            get { return _attkPowr; }
        }
        public float GetDefense
        {
            get { return _defensePowr; }
        }

        //Constructor
        public Entity(string name, char icon, float hp, float attack, float defense) : base(name, icon)
        {
            _health = hp;
            _attkPowr = attack;
            _defensePowr = defense;
        }

        /// <summary>
        /// Decreases the health value by a certain amount
        /// </summary>
        /// <param name="decreasevalue"> The number the value is being decreased by</param>
        public void DecreaseHealth(float decreasevalue)
        {
            _health -= decreasevalue;
        }

        /// <summary>
        /// Returns a float depending on the current enemy's attackpower subtracted by the defensepower
        /// of an Entity that is passed into the method
        /// </summary>
        /// <param name="Enemy"> the entity the current entity is fighting</param>
        /// <returns></returns>
        public float Attack(Entity Enemy)
        {
            float damagedealt = this._attkPowr - Enemy._defensePowr;

            if (damagedealt <= 0)
            {
                damagedealt = 0;
            }

            return damagedealt;
        }

        /// <summary>
        /// Prints stats to the console.
        /// </summary>
        public override void PrintStats()
        {
            base.PrintStats();
            Console.WriteLine("HP: " + _health);
            Console.WriteLine("ATTACK: " + _attkPowr);
            Console.WriteLine("DEFENSE: " + _defensePowr);
        }
    }
}
