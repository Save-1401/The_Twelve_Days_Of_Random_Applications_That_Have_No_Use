using System;
using System.Collections.Generic;
using System.Numerics;

namespace Day_Seven
{
    class Program
    {
        /// <summary>
        /// The color to turn the console based off the char
        /// </summary>
        static Dictionary<char, ConsoleColor> colors = new Dictionary<char, ConsoleColor> { { '0', ConsoleColor.White }, { '1', ConsoleColor.Red }, { '2', ConsoleColor.Magenta }, 
            { '3', ConsoleColor.Blue }, { '4', ConsoleColor.Green }, { '5', ConsoleColor.Yellow }, { '6', ConsoleColor.DarkRed }, { '7', ConsoleColor.DarkBlue }, { '8', ConsoleColor.DarkYellow },
            { '9', ConsoleColor.Cyan } };
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
                int width = 100;
                int height = 50;
                char filter = ' ';
                //Resets the console color
                Console.ForegroundColor = ConsoleColor.White;
                //Asks the user how big they want their art to be.
                Console.Write("Width: ");
                try
                {
                    width = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {

                }
                Console.Write("Height: ");
                try
                {
                    height = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {

                }
                Console.Write("Filter (leave blank for none): ");
                try
                {
                    filter = Console.ReadLine().ToCharArray()[0];
                }
                catch
                {

                }
                //Gets how the river looks
                char[,] art = DrawArt(width, height, rnd);
                //Writes the river to the console
                WriteArt(art, width, height, filter);
            }
        }
        /// <summary>
        /// Draws the art
        /// </summary>
        /// <returns></returns>
        static char[,] DrawArt(int width, int height, Random rnd)
        {
            //The river area
            char[,] art = new char[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    art[x, y] = rnd.Next(0, 10).ToString().ToCharArray()[0];
                }
            }
            return art;
        }
        /// <summary>
        /// Writes the art out to the console
        /// </summary>
        static void WriteArt(char[,] art, int width, int height, char filter)
        {
            //Iterates through the river array and draws it
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    char artChar = art[x, y];
                    //Checks if the character should be printed
                    if (artChar == filter || filter == ' ')
                    {
                        //Turns the console forground color to the color for the char and writes it to the console
                        Console.ForegroundColor = colors[artChar];
                        Console.Write(artChar);
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                //Goes to the next line
                Console.WriteLine("");
            }
        }
    }
}
