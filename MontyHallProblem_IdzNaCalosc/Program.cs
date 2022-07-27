using System;

namespace MontyHallProblem_IdzNaCalosc
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int attempts = 10000;
            int door1 = 0;
            int door2 = 0;
            int door3 = 0;
            int witnsWithoutChange = 0;
            int witnsWithChange = 0;

            for (int i = 0; i < attempts; i++)
            {
                string log = "";
                int car = rnd.Next(1, 4);
                switch (car)
                {
                    case 1:
                        door1++;
                        break;
                    case 2:
                        door2++;
                        break;
                    case 3:
                        door3++;
                        break;
                }

                int myChoiceWithoutChange = rnd.Next(1, 4);
                int myChoiceWithChange;
                int oneOfGoats;

                log = $"Car is in door nr: {car}, I have chosen: {myChoiceWithoutChange},";

                // If I've already picked a car
                if (car == myChoiceWithoutChange)
                {
                    do
                    {
                        oneOfGoats = rnd.Next(1, 4);
                    }
                    while (car == oneOfGoats);

                    log = $"{log}\nBecause the host have known that I've chosen a car, he told me that one of the goats is at door nr: {oneOfGoats},";
                }

                // If picked a goat
                else
                {
                    if (myChoiceWithoutChange == 1 && car == 2)
                    {
                        oneOfGoats = 3;
                    }
                    else if (myChoiceWithoutChange == 1 && car == 3)
                    {
                        oneOfGoats = 2;
                    }
                    else if (myChoiceWithoutChange == 2 && car == 1)
                    {
                        oneOfGoats = 3;
                    }
                    else if (myChoiceWithoutChange == 2 && car == 3)
                    {
                        oneOfGoats = 1;
                    }
                    else if (myChoiceWithoutChange == 3 && car == 1)
                    {
                        oneOfGoats = 2;
                    }
                    else
                    {
                        oneOfGoats = 1;
                    }

                    log = $"{log}\nBecause the host have known that I've chosen one of the goats, he told me that one of the goats is at door nr: {oneOfGoats},";
                }

                if (myChoiceWithoutChange == 1 && oneOfGoats == 2)
                {
                    myChoiceWithChange = 3;
                }
                else if (myChoiceWithoutChange == 1 && oneOfGoats == 3)
                {
                    myChoiceWithChange = 2;
                }
                else if (myChoiceWithoutChange == 2 && oneOfGoats == 1)
                {
                    myChoiceWithChange = 3;
                }
                else if (myChoiceWithoutChange == 2 && oneOfGoats == 3)
                {
                    myChoiceWithChange = 1;
                }
                else if (myChoiceWithoutChange == 3 && oneOfGoats == 1)
                {
                    myChoiceWithChange = 2;
                }
                else
                {
                    myChoiceWithChange = 1;
                }

                log = $"{log}\nWhoever decided to change the door and changed from door nr: {myChoiceWithoutChange}, upon door nr: {myChoiceWithChange}";

                if (car == myChoiceWithChange)
                {
                    log = $"{log}, have WON!";
                    witnsWithChange++;
                }
                else
                {
                    log = $"{log}, have LOST!";
                }

                if (car == myChoiceWithoutChange)
                {
                    log = $"{log}\nWhoever didn't change decision have WON";
                    witnsWithoutChange++;
                }
                else
                {
                    log = $"{log}\nWhoever didn't change decision have LOST";
                }

                Console.WriteLine($"{log}\n");
            }

            Console.WriteLine($"Doors nr 1: {door1}\nDoors nr 2: {door2}\nDoors nr 3: {door3}" +
                $"\nWon car without change: {witnsWithoutChange}" +
                $"\nWon car with change: {witnsWithChange}");

            Console.ReadKey();
        }
    }
}
