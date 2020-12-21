using System;
using System.Collections.Generic;

namespace Day_Eight
{
    public enum BurgerSize { Single, Double, DoubleDouble };
    class Program
    {
        /// <summary>
        /// The color that each char is writen in
        /// </summary>
        static Dictionary<char, ConsoleColor> colors = new Dictionary<char, ConsoleColor> { { 'P', ConsoleColor.DarkGray }, { 'V', ConsoleColor.Green }, { 'C', ConsoleColor.Yellow }, 
            { 'T', ConsoleColor.Red }, { 'L', ConsoleColor.Green }, { 'W', ConsoleColor.White }, { 'H', ConsoleColor.Gray }, { 'B', ConsoleColor.DarkYellow }, { ' ', ConsoleColor.White } };
        static void Main(string[] args)
        {
            //Writes the menu
            Console.WriteLine("MENU");
            Console.WriteLine("Order in a list of letters (e.g. SVH, DMW)");
            Console.WriteLine("BURGER SIZES");
            Console.WriteLine("S: Single");
            Console.WriteLine("D: Double");
            Console.WriteLine("U: Double-Double");
            Console.WriteLine("BURGER TYPES");
            Console.WriteLine("P: Plain");
            Console.WriteLine("C: Cheese");
            Console.WriteLine("V: Veggie");
            Console.WriteLine("F: Full");
            Console.WriteLine("BUN TYPES");
            Console.WriteLine("W: White");
            Console.WriteLine("H: Wheat");
            Console.WriteLine("B: Bisket");
            while(true)
            {
                //Gets the users order
                string orderString = "";
                do
                {
                    Console.Write("Enter your order: ");
                    orderString = Console.ReadLine();
                    // If the user ordered wrong, tells them so
                    if (orderString.Length != 3)
                    {
                        Console.WriteLine("Invalid order. Order must be three letters long.");
                    }
                } while (orderString.Length != 3);

                Order order = new Order(orderString);

                DrawOrder(order);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        /// <summary>
        /// Draws the order
        /// </summary>
        /// <param name="order"></param>
        static void DrawOrder(Order order)
        {
            //The array of the contants of the burger
            char[] contents = new char[order.GetContentLength()];

            //Sets the contents
            for (int i = 0; i < contents.Length; i++)
            {
                contents[i] = order.GetContent(i);
            }

            //Draws the order
            for (int i = 0; i < contents.Length; i++)
            {
                Console.ForegroundColor = colors[contents[i]];
                //Makes the burger more than one character wide
                for (int n = 0; n < 25; n++)
                {
                    Console.Write(contents[i]);
                }
                Console.WriteLine("");
            }
        }
    }
}
