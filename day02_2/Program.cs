using System;
using System.Security.Cryptography;

namespace day02_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long total = 0;
            while (Console.ReadLine() is { } line)
            {
                var splitGame = line.Split(": ");
                var gameNum = int.Parse(splitGame[0].Split("Game ")[1]);
                var sets = splitGame[1].Split("; ");
                total += getMinimum(sets);
            }
            Console.WriteLine(total);
        }

        static int getMinimum(string[] sets)
        {
            LowestSet lowestSet = new LowestSet();
            foreach (var set in sets)
            {
                var cubes = set.Split(", ");
                foreach (var cube in cubes)
                {
                    var number = int.Parse(cube.Split(" ")[0]);
                    var color = cube.Split(" ")[1];

                    switch (color)
                    {
                        case "blue":
                            if (number > lowestSet.Blue)
                            {
                                lowestSet.Blue = number;
                            }
                            break;

                        case "red":
                            if (number > lowestSet.Red)
                            {
                                lowestSet.Red = number;
                            }
                            break;

                        case "green":
                            if (number > lowestSet.Green)
                            {
                                lowestSet.Green = number;
                            }
                            break;
                    }
                }
            }
            return lowestSet.GetMultiplication();
        }
    }
}
