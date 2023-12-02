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
                var players = splitGame[1].Split("; ");
                var possible = true;
                foreach (var player in players)
                {
                    var input = player.Split(", ");
                    possible = !possible ? false : IsGameLegal(input);
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
                var numAndColor = cube.Split(" ");
                var number = int.Parse(numAndColor[0]);
                switch (numAndColor[1])
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