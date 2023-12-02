using System.Drawing;
using System.Numerics;
using System.Security.Cryptography;

namespace day02_1
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
                var possible = true;
                foreach (var set in sets)
                {
                    var cubes = set.Split(", ");
                    possible = !possible ? false : IsGameLegal(cubes);
                }

                total = possible ? total += gameNum : total;
            }
            Console.WriteLine(total);
        }
        static bool IsGameLegal(string[] cubes)
        {
            var blueLegal = true;
            var greenLegal = true;
            var redLegal = true;
            foreach (var cube in cubes)
            {
                var number = int.Parse(cube.Split(" ")[0]);
                var color = cube.Split(" ")[1];
                switch (color)
                {
                    case "blue":
                        if (number <= 14)
                        {
                            blueLegal = true;
                        }
                        else
                        {
                            blueLegal = false;
                        }
                        break;

                    case "red":
                        if (number <= 12)
                        {
                            redLegal = true;
                        }
                        else
                        {
                            redLegal = false;
                        }
                        break;

                    case "green":
                        if (number <= 13)
                        {
                            greenLegal = true;
                        }
                        else
                        {
                            greenLegal = false;
                        }
                        break;
                }
            }

            return greenLegal && redLegal && blueLegal;
        }
    }
}