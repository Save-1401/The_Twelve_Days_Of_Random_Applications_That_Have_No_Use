using System;
using System.Collections.Generic;
using System.Numerics;

namespace Day_Six
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd;
            Console.Write("Enter a seed: ");
            try
            {
                rnd = new Random(Convert.ToInt32(Console.ReadLine()));
            }
            catch
            {
                rnd = new Random(1401);
            }
            //Loops infinitely
            while (true)
            {
                //All of the variables needed
                int width = 10;
                int height = 5;
                int length = 20;
                //Resets the console color
                Console.ForegroundColor = ConsoleColor.White;
                //Asks the user for deatails about how they want the river to be.
                Console.Write("River area width: ");
                try
                {
                    width = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {

                }
                Console.Write("River area height: ");
                try
                {
                    height = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {

                }
                Console.Write("River length: ");
                try
                {
                    length = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {

                }
                //Gets how the river looks
                char[,] river = DrawRiver(width, height, length, rnd);
                //Writes the river to the console
                WriteRiver(river, width, height);
            }
        }
        /// <summary>
        /// Draws the river
        /// </summary>
        /// <returns></returns>
        static char[,] DrawRiver(int width, int height, int length, Random rnd)
        {
            //The river area
            char[,] riverArea = new char[width, height];

            //Fi the river is longer than there are spaces for, colors in the entire river area
            if (riverArea.Length > width * height)
            {
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        riverArea[x, y] = '1';
                    }
                }
                return riverArea;
            }
            //Otherwise it draws the river
            else
            {
                //Makes the entire river area 0s
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        riverArea[x, y] = '0';
                    }
                }
                //randomly draws the river
                Vector2 startingPoint = new Vector2(rnd.Next(0, width), rnd.Next(0, height));
                Vector2 riverPoint = startingPoint;
                for (int i = 0; i < length; i++)
                {
                    //Makes sure the river is not being placed in a spot that there is already river
                    if (riverArea[(int)riverPoint.X, (int)riverPoint.Y] == '1')
                    {
                        i--;
                    }
                    else
                    {
                        //Puts the part of the river into the river area char array
                        riverArea[(int)riverPoint.X, (int)riverPoint.Y] = '1';
                    }
                    //Changes the river point
                    riverPoint = ChangeRiverPoint(riverPoint, width, height, rnd);
                }
            }
            return riverArea;
        }
        /// <summary>
        /// Changes the river point and makes sure it stays in the bounds
        /// </summary>
        /// <param name="riverPoint"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        static Vector2 ChangeRiverPoint(Vector2 riverPoint, int width, int height, Random rnd)
        {
            //Checks wich direction sthe river can go in
            List<Vector2> changesThatCanBeMade = new List<Vector2>();
            if (riverPoint.X > 0)
            {
                changesThatCanBeMade.Add(new Vector2(-1, 0));
            }
            if (riverPoint.X < width - 1)
            {
                changesThatCanBeMade.Add(new Vector2(1, 0));
            }
            if (riverPoint.Y > 0)
            {
                changesThatCanBeMade.Add(new Vector2(0, -1));
            }
            if (riverPoint.Y < height - 1)
            {
                changesThatCanBeMade.Add(new Vector2(0, 1));
            }
            //Returns the river point turned in a random direction
            return riverPoint + changesThatCanBeMade[rnd.Next(0, changesThatCanBeMade.Count)];
        }
        /// <summary>
        /// Writes the river out to the console
        /// </summary>
        static void WriteRiver(char[,] river, int width, int height)
        {
            //Iterates through the river array and draws it
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    char riverChar = river[x, y];
                    //Checks if a river is being drawn, and if so turns the text being drawn blue, otherwise turns it green
                    if (riverChar == '1')
                        Console.ForegroundColor = ConsoleColor.Blue;
                    else
                        Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(riverChar);
                }
                //Goes to the next line
                Console.WriteLine("");
            }
        }
    }
}
