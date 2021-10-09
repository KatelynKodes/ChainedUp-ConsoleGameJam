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
