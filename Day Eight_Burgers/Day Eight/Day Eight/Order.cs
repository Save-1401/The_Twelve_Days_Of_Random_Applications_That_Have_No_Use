using System;
using System.Collections.Generic;
using System.Text;

namespace Day_Eight
{
    class Order
    {
        /// <summary>
        /// The size of the burger ordered
        /// </summary>
        public BurgerSize burgerSize;
        /// <summary>
        /// The type of butger ordered
        /// </summary>
        public Burger burgerType;
        /// <summary>
        /// The type of bun ordered
        /// </summary>
        public char bunType;

        /// <summary>
        /// The types of burger sizes and their corresponding order characters
        /// </summary>
        static Dictionary<char, BurgerSize> burgerSizes = new Dictionary<char, BurgerSize> { { 'S', BurgerSize.Single }, { 'D',BurgerSize.Double },
            { 'U', BurgerSize.DoubleDouble } };
        /// <summary>
        /// The types of burgers and their corresponding order characters
        /// </summary>
        static Dictionary<char, Burger> burgers = new Dictionary<char, Burger> { { 'P', new Burger(new List<char> { 'P' }) }, { 'C', new Burger(new List<char> { 'P', 'C' }) },
            { 'V', new Burger(new List<char> { 'V', 'C', 'T' }) }, { 'F', new Burger(new List<char> { 'P', 'C', 'L', 'T' }) } };
        /// <summary>
        /// The types of buns and their corresponding order characters
        /// </summary>
        static Dictionary<char, char> buns = new Dictionary<char, char> { { 'W', 'W' }, { 'H', 'H' },
            { 'B', 'B' } };

        public Order(string order)
        {
            //The order in a char array
            char[] orderCA = order.ToCharArray();
            //Processes the order
            burgerSize = burgerSizes[orderCA[0]];
            burgerType = burgers[orderCA[1]];
            bunType = buns[orderCA[2]];
        }
        //Gets how many things this burger has in it
        public int GetContentLength()
        {
            //The content length of the burger
            int length = 0;

            //Gets how many buns and patties are in the burger
            if (burgerSize == BurgerSize.Single)
            {
                length = 2;
            }
            else if (burgerSize == BurgerSize.Double)
            {
                length = 3;
            }
            else if (burgerSize == BurgerSize.DoubleDouble)
            {
                length = 3;
            }

            //Add the contents of the burger to the length
            length += burgerType.contents.Count;

            //If the burger is a double double, adds them again
            if (burgerSize == BurgerSize.DoubleDouble)
            {
                length += burgerType.contents.Count;
            }

            //Returns the length
            return length;
        }
        public char GetContent(int index)
        {
            //The content at index
            char content = ' ';

            //Checks if it is the first or last part of the burger
            if (index == 0)
            {
                content = bunType;
            }
            else if (index == GetContentLength() - 1)
            {
                content = bunType;
            }
            //Otherwise checks the size of the burger to continue
            else if (burgerSize == BurgerSize.Single)
            {
                //Reads from the content of the burger
                content = burgerType.contents[burgerType.contents.Count - (index)];
            }
            else if (burgerSize == BurgerSize.Double)
            {
                if (index == burgerType.contents.Count + 1)
                {
                    //Reads from the patty to double it if the index is one
                    content = burgerType.contents[0];
                }
                else
                {
                    //Reads from the content of the burger
                    //Console.WriteLine(burgerType.contents.Count - index);
                    content = burgerType.contents[burgerType.contents.Count - (index)];
                }
            }
            else if (burgerSize == BurgerSize.DoubleDouble)
            {
                if (index <= burgerType.contents.Count)
                {
                    //Reads from top half of the burger
                    content = burgerType.contents[burgerType.contents.Count - index];
                }
                else if (index == burgerType.contents.Count + 1)
                {
                    //Adds a bun in the middle
                    content = bunType;
                }
                else
                {
                    //Reads from bottom half of the burger
                    //Console.WriteLine(burgerType.contents.Count - (index - (burgerType.contents.Count + 1)));
                    content = burgerType.contents[burgerType.contents.Count - (index - (burgerType.contents.Count + 1))];
                }
            }

            //Returns the content
            return content;
        }
    }
}
