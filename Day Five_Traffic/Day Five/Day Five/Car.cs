using System;
using System.Numerics;
using System.Collections.Generic;
using System.Text;

namespace Day_Five
{
    class Car
    {
        /// <summary>
        /// The character that is drawn on the camera in all the places the car is located
        /// </summary>
        public char style;
        /// <summary>
        /// The position of the car
        /// </summary>
        public Vector2 position;
        /// <summary>
        /// The length of the car
        /// </summary>
        public int length;

        public Car(char style, Vector2 position, int length)
        {
            this.style = style;
            this.position = position;
            this.length = length;
        }
        /// <summary>
        /// Check if the car is at <paramref name="position"/>
        /// </summary>
        /// <param name="position"></param>
        public bool IsAtPosition(Vector2 position)
        {
            for (int i = 0; i < length; i++)
            {
                if (this.position + new Vector2(0, i) == position)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Makes the car dive forward
        /// </summary>
        public void Drive()
        {
            position -= new Vector2(0, 1);
        }
        /// <summary>
        /// Makes the car drive horizontaly in direction horizontal
        /// </summary>
        /// <param name="horizontal"></param>
        public void Drive(int horizontal, int vertical)
        {
            position += new Vector2(horizontal, vertical);
        }
    }
}
