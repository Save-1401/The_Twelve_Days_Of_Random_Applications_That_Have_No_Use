using System;

namespace Day_Ten
{
    class Program
    {
        static void Main(string[] args)
        {
            //Sets the random
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

            //The number of sides last used
            int lastSides = 1;
            //Infinitely loops
            while (true)
            {
                //Sets the sides that the dice has
                int sides = 1;
                Console.Write("Enter dice sides: ");
                try
                {
                    sides = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    //If the input is invalid, sets the dices sides to the last sides
                    sides = lastSides;
                }

                //Rolls the dice
                int results = rnd.Next(1, sides + 1);

                //Prints the results
                Console.WriteLine(results);

                //Adds a space
                Console.WriteLine("");

                //Sets the last sides the the sides
                lastSides = sides;
            }
        }
    }
}
