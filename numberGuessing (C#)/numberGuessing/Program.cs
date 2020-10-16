using System;
using System.Collections.Generic;
using System.Linq;

namespace numberGuessing
{
    class MainClass
    {
        public static bool IsNumeric(string str)
        {
            try
            {
                str = str.Trim();
                int foo = int.Parse(str);
                return (true);
            }
            catch (FormatException)
            {
                // Not a numeric value
                return (false);
            }
        }

        public static void Main(string[] args)
        {
            List<int> choices = new List<int>();
            bool end = false;

            while (!end)
            {
                Console.Write("Minimum Number (Default - 1): ");
                dynamic rangeMin = Console.ReadLine();
                // Convert.ToInt32(Console.ReadLine())
                Console.Write("Maximum Number (Default - 100): ");
                dynamic rangeMax = Console.ReadLine();

                if (IsNumeric(rangeMin) && IsNumeric(rangeMax) && !string.IsNullOrWhiteSpace(rangeMin) && !string.IsNullOrWhiteSpace(rangeMax) && !string.IsNullOrEmpty(rangeMin) && !string.IsNullOrEmpty(rangeMax))
                {
                    rangeMin = Convert.ToInt32(rangeMin);
                    rangeMax = Convert.ToInt32(rangeMax);
                    if (rangeMin == rangeMax)
                    {
                        rangeMin = null;
                        rangeMax = null;
                        Console.WriteLine("Maximum Number is equal to Minimum Number");
                        Console.WriteLine("Minimum Number is equal to Maximum Number");
                        Console.WriteLine("Numbers set to default");
                    }
                    else if (rangeMin > rangeMax)
                    {
                        rangeMin = null;
                        rangeMax = null;
                        Console.WriteLine("Maximum Number is smaller than Minimum Number");
                        Console.WriteLine("Minimum Number is greater than Maximum Number");
                        Console.WriteLine("Numbers set to default");
                    }
                }
                else if (!IsNumeric(rangeMin) || !IsNumeric(rangeMax) || string.IsNullOrEmpty(rangeMin) || string.IsNullOrWhiteSpace(rangeMin) || string.IsNullOrEmpty(rangeMax) || string.IsNullOrWhiteSpace(rangeMax))
                {
                    Console.WriteLine("Either one or both characters/inputs are invalid");
                    Console.WriteLine("Invalid Character(s) set to default");
                }

                if (rangeMin == null || string.IsNullOrEmpty(Convert.ToString(rangeMin)) || string.IsNullOrWhiteSpace(Convert.ToString(rangeMin)) || !IsNumeric(Convert.ToString(rangeMin)))
                {
                    rangeMin = 1;
                }
                if (rangeMax == null || string.IsNullOrEmpty(Convert.ToString(rangeMax)) || string.IsNullOrWhiteSpace(Convert.ToString(rangeMax)) || !IsNumeric(Convert.ToString(rangeMax)))
                {
                    rangeMax = 100;
                }

                System.Random Random = new System.Random();

                int tries = 0;
                int numberToGuess = Random.Next(Convert.ToInt32(rangeMin), Convert.ToInt32(rangeMax));
                bool foundCorrectNumber = false;

                while (!foundCorrectNumber)
                {
                    tries++;
                    Console.Write("Guess a number from " + rangeMin + " to " + rangeMax + ": ");
                    dynamic guess = Console.ReadLine();
                    if (IsNumeric(guess) && !string.IsNullOrEmpty(guess) && !string.IsNullOrWhiteSpace(guess))
                    {
                        guess = Convert.ToInt32(guess);
                        if (guess == numberToGuess)
                        {
                            Console.WriteLine("Congrats, you got it!");
                            foundCorrectNumber = true;
                        }
                        else if (choices.Contains(guess))
                        {
                            Console.WriteLine("Number has been guessed before");
                        }
                        else if (guess > rangeMax || guess < rangeMin)
                        {
                            Console.WriteLine("Out of Range");
                        }
                        else if (guess > numberToGuess)
                        {
                            Console.WriteLine("Sorry, guess again!\nNumber is Smaller");
                        }
                        else if (guess < numberToGuess)
                        {
                            Console.WriteLine("Sorry, guess again!\nNumber is Larger");
                        }
                        choices.Add(guess);
                    }
                }

                Console.WriteLine($"The number was {numberToGuess}");

                if (tries > 1)
                {
                    Console.WriteLine($"You tried {tries} times");
                }
                else
                {
                    Console.WriteLine("You tried 1 time");
                }

                Console.Write("Again [Y/N]? ");
                string choice = Console.ReadLine();
                if (choice.ToLower().Contains("n") || choice.ToLower().Contains("x"))
                {
                    end = true;
                }
                else if (choice.ToLower().Contains("y"))
                {
                    end = false;
                    Console.WriteLine();
                    choices.Clear();
                }
                else
                {
                    end = true;
                }
            }
        }
    }
}
