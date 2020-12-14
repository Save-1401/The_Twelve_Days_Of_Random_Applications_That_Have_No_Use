using System;
using System.Collections.Generic;
using System.Text;

namespace Day_Two
{
    /// <summary>
    /// A class for storing how likely a character is to be used
    /// </summary>
    class WeightedChar
    {
        /// <summary>
        /// The character that is being weighted
        /// </summary>
        public char c;
        /// <summary>
        /// The weight of the character
        /// </summary>
        public int weight;

        public WeightedChar(char c, int weight)
        {
            this.c = c;
            this.weight = weight;
        }
    }
}
