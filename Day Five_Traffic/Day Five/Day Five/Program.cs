using System;
using System.Numerics;
using System.Collections.Generic;

namespace Day_Five
{
    class Program
    {
        /// <summary>
        /// The camera used for rendering
        /// </summary>
        static Camera camera = new Camera(new Vector2(0, 0), new Vector2(5, 20));
        /// <summary>
        /// The player
        /// </summary>
        static Car player = new Car('0', new Vector2(0, 0), 2);
        /// <summary>
        /// All of the cars
        /// </summary>
        static List<Car> cars = new List<Car>() { new Car('1', new Vector2(0, 5), 2) };
        static void Main(string[] args)
        {
            Random rnd = new Random(1401);
            while (true)
            {
                bool dead = false;
                while (!dead)
                {
                    //Renders
                    Console.Clear();
                    Console.WriteLine(camera.Render(cars, player));
                    //Tells the player how to play
                    Console.WriteLine("WASD or arrow keys to move. You are the 00 car.");
                    //Moves the cars
                    foreach (Car car in cars)
                    {
                        car.Drive();
                    }
                    bool correctUserInput = false;
                    while( !correctUserInput)
                    {
                        //Gets the direction the player wants to go
                        ConsoleKeyInfo cki = Console.ReadKey();
                        if (cki.Key == ConsoleKey.LeftArrow || cki.Key == ConsoleKey.A)
                        {
                            if (player.position.Y > (camera.position.Y - (int)(camera.size.Y / 2)))
                            {
                                player.Drive(0, -1);
                                correctUserInput = true;
                            }
                        }
                        else if (cki.Key == ConsoleKey.RightArrow || cki.Key == ConsoleKey.D)
                        {
                            if (player.position.Y < (camera.size.Y + camera.position.Y - (int)(camera.size.Y / 2)) - 2)
                            {
                                player.Drive(0, 1);
                                correctUserInput = true;
                            }
                        }
                        else if (cki.Key == ConsoleKey.DownArrow || cki.Key == ConsoleKey.S)
                        {
                            if (player.position.X < (camera.size.X + camera.position.X - (int)(camera.size.X / 2)) - 1)
                            {
                                player.Drive(1, 0);
                                correctUserInput = true;
                            }
                        }
                        else if (cki.Key == ConsoleKey.UpArrow || cki.Key == ConsoleKey.W)
                        {
                            if (player.position.X > (camera.position.X - (int)(camera.size.X / 2)))
                            {
                                player.Drive(-1, 0);
                                correctUserInput = true;
                            }
                        }
                    }

                    //Check the cars and then spawns more cars
                    CheckCars();
                    if (cars.Count < 4)
                    {
                        int left = 4 - cars.Count;
                        for (int i = 0; i < left; i++)
                        {
                            if (rnd.Next(0, 5) < 1)
                                SpawnCar(rnd);
                        }
                    }

                    //If the player is colliding with a car, restarts the game and sets dead to true
                    if (CheckPlayer())
                    {
                        dead = true;
                        camera = new Camera(new Vector2(0, 0), new Vector2(5, 20));
                        player = new Car('0', new Vector2(0, 0), 2);
                        cars = new List<Car>() { new Car('1', new Vector2(0, 5), 2) };
                    }
                }
                //Tells the player what to do now that they are dead
                Console.Clear();
                Console.WriteLine("You are dead. Press r to restart and q to quit");
                bool correctUserInputDead = false;
                while (!correctUserInputDead)
                {
                    //Gets the player input (whether they want to restart or quit)
                    ConsoleKeyInfo cki = Console.ReadKey();
                    if (cki.Key == ConsoleKey.R)
                    {
                        dead = false;
                        correctUserInputDead = true;
                    }
                    else if (cki.Key == ConsoleKey.Q)
                    {
                        correctUserInputDead = true;
                        return;
                    }
                }

            }
        }
        //Checks if the player is colliding with a car
        static bool CheckPlayer()
        {
            for (int i = 0; i < player.length; i++)
            {
                foreach (Car car in cars)
                {
                    if (car.IsAtPosition(player.position + new Vector2(0, i)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Check the cars to see if they are of the screen
        /// </summary>
        static void CheckCars()
        {
            //Checks each car, and if it is not on the screen, deletes it
            for (int i = 0; i < cars.Count; i++)
            {
                if (cars[i].position.Y < (camera.position.Y - (int)(camera.size.Y / 2)) - cars[i].length)
                {
                    cars.RemoveAt(i);
                    i--;
                }
            }
        }
        /// <summary>
        /// Spawns a car
        /// </summary>
        /// <param name="rnd"></param>
        static void SpawnCar(Random rnd)
        {
            //Sets a random space and makes sure it is not occupied
            Vector2 randomSpace;
            do
            {
                randomSpace = GetRandomSpace(rnd);
            }
            while (SpaceIsOccupied(randomSpace));

            //Spawns a car
            cars.Add(new Car(GetUnusedStyle(), randomSpace, rnd.Next(1, 5)));
        }
        /// <summary>
        /// Gets a random space
        /// </summary>
        /// <param name="rnd"></param>
        /// <returns></returns>
        static Vector2 GetRandomSpace(Random rnd)
        {
            return new Vector2(rnd.Next((int)(camera.position.X - (int)(camera.size.X / 2)), (int)(camera.size.X + camera.position.X - (int)(camera.size.X / 2))),
                (int)(camera.size.Y + camera.position.Y - (int)(camera.size.Y / 2)));
        }
        /// <summary>
        /// Gets a style thta isn't being used
        /// </summary>
        /// <returns></returns>
        static char GetUnusedStyle()
        {
            for (int i = 1; i < 10; i++)
            {
                bool canUse = true;
                foreach (Car car in cars)
                {
                    if (car.style == i.ToString().ToCharArray()[0])
                    {
                        canUse = false;
                    }
                }
                if (canUse)
                {
                    return i.ToString().ToCharArray()[0];
                }
            }
            return '9';
        }
        /// <summary>
        /// Checks if a space is occupied
        /// </summary>
        /// <param name="space"></param>
        /// <returns></returns>
        static bool SpaceIsOccupied(Vector2 space)
        {
            foreach (Car car in cars)
            {
                if (car.IsAtPosition(space))
                {
                    return true;
                }
            }
            if (player.IsAtPosition(space))
            {
                return true;
            }
            return false;
        }
    }
}
