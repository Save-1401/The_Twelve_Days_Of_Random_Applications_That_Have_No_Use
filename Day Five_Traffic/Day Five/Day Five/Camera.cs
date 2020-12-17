using System;
using System.Numerics;
using System.Collections.Generic;
using System.Text;

namespace Day_Five
{
    class Camera
    {
        public Vector2 position;
        public Vector2 size;

        public Camera(Vector2 position, Vector2 size)
        {
            this.position = position;
            this.size = size;
        }
        /// <summary>
        /// Renders the cars
        /// </summary>
        /// <param name="cars"></param>
        /// <returns>A string containing the cars that can be seen's <see cref="Car.style"/></returns>
        public string Render(List<Car> cars, Car player)
        {
            char[,] screen = new char[(int)size.X, (int)size.Y];

            //Iterates through all points on the screen and chack if a car is there
            for (int x = 0; x < (int)size.X; x++)
            {
                for (int y = 0; y < (int)size.Y; y++)
                {
                    bool thereIsCar = false;
                    //Checks if there is a car at the current position being rendered
                    Vector2 posBeingRendered = new Vector2(x + position.X - (int)(size.X / 2), y + position.Y - (int)(size.Y / 2));
                    foreach (Car car in cars)
                    {
                        if (car.IsAtPosition(posBeingRendered))
                        {
                            screen[x, y] = car.style;
                            thereIsCar = true;
                        }
                    }
                    if (player.IsAtPosition(posBeingRendered))
                    {
                        screen[x, y] = player.style;
                        thereIsCar = true;
                    }
                    //If there is no car, adds a space
                    if (!thereIsCar)
                    {
                        screen[x, y] = ' ';
                    }
                }
            }
            //Iterares through the screen and adds it to a string, which will later be printed
            string render = "";
            for (int x = 0; x < (int)size.X; x++)
            {
                for (int y = 0; y < (int)size.Y; y++)
                {
                    try
                    {
                        render += screen[x, y];
                    }
                    catch
                    {
                        render += "/";
                    }
                    render += "";
                }
                render += "\n";
            }
            return render;
        }
    }
}
