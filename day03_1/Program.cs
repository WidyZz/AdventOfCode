using day03_2;
using System.Runtime.ExceptionServices;

namespace day03_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GetAllPartNumbers();
        }

        static void GetAllPartNumbers()
        {
            var input = AdventTools.GetInput();
            var width = input[0].Length;
            var height = input.Length;
            var map = new char[width, height];

            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    map[x, y] = input[y][x];
                }
            }
            var total = 0;
            var currentValue = 0;
            var hasNeiborSymbol = false;
            void SumTotal()
            {
                if(currentValue != 0 && hasNeiborSymbol)
                {
                    total += currentValue;
                }
                currentValue = 0;
                hasNeiborSymbol = false;
            }
            for (int y = 0; y < width; y++)
            {
                for (int x = 0; x < height; x++)
                {
                    var c = map[x, y];
                    if (char.IsDigit(c))
                    {
                        var value = c - '0';
                        currentValue = currentValue * 10 + value;
                        foreach (var direction in Directions.Diagonal)
                        {
                            var neigborX = x + direction.X;
                            var neigborY = y + direction.Y;
                            if(neigborX < 0 || neigborX >= width || neigborY < 0 || neigborY >= height)
                            {
                                continue;
                            }

                            var neigborChar = map[neigborX, neigborY];
                            if(!char.IsDigit(neigborChar) && neigborChar != '.')
                            {
                                hasNeiborSymbol = true;
                            }
                        }
                    }
                    else
                    {
                        SumTotal();
                    }
                }
                    SumTotal();
            }
            total.PrintIntOutput();
        }
    }
}
