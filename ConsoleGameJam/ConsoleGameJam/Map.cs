using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGameJam
{
    class Map
    {
        public static string[,] map = new string[5, 5];
        int X = 2;
        int Y = 2;

        public void Start() 
        {
            ClearMap();
            bool test = false;
            while (test == false)
            {
                ClearMap();
                DrawActors();
                DrawMap();
                Movement();
                Console.Clear();
            }
        }

        void ClearMap() 
        {
            map = new string[5, 5] { { " ", " ", " ", " ", " " },
                                    { " ", " ", " ", " ", " " },
                                    { " ", " ", " ", " ", " " },
                                    { " ", " ", " ", " ", " " },
                                    { " ", " ", " ", " ", " " } };
            //map = new string[5, 5] { { ".", ".", ".", ".", "." },
            //                        { ".", ".", ".", ".", "." },
            //                        { ".", ".", ".", ".", "." },
            //                        { ".", ".", ".", ".", "." },
            //                        { ".", ".", ".", ".", "." } };
        }

        void DrawMap() 
        {
            int x, y;
            for (x = 0; x < 5; x++)
            {
                Console.Write("\n");
                for (y = 0; y < 5; y++)
                    Console.Write("{0}\t", map[x, y]);
            }
            Console.Write("\n\n");
        }

        void DrawActors() 
        {
            map[X, Y] = "P";
        }

        void Movement() 
        {
            ConsoleKeyInfo input = Console.ReadKey(true);
            if (input.Key == ConsoleKey.W && X > 0 && map[Y, X - 1] != "[]")
                X--;
            if (input.Key == ConsoleKey.S && X < 4 && map[Y, X + 1] != "[]")
                X++;
            if (input.Key == ConsoleKey.A && Y > 0 && map[Y - 1, X] != "[]")
                Y--;
            if (input.Key == ConsoleKey.D && Y < 4 && map[Y + 1, X] != "[]")
                Y++;
        }
    }
}
