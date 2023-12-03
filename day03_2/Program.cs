using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace day03_2
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
            var currentPosition = new Point(0, 0);
            var stars = new Dictionary<Point, List<int>>();
            // HashSet protoze nechceme duplikaty | We dont want duplicates
            var neigborStars = new HashSet<Point>();
            void AddStarNeigborNumbers()
            {
                if (currentValue != 0 && neigborStars.Count > 0)
                {
                    foreach (var neigborStar in neigborStars)
                    {
                        if (!stars.ContainsKey(neigborStar))
                        {
                            stars[neigborStar] = new List<int>();
                        }
                        stars[neigborStar].Add(currentValue);
                    }
                }
                neigborStars.Clear();
                currentValue = 0;
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
                            currentPosition.X = x + direction.X;
                            currentPosition.Y = y + direction.Y;
                            if (currentPosition.X < 0 || currentPosition.X >= width || currentPosition.Y < 0 || currentPosition.Y >= height)
                            {
                                continue;
                            }

                            var neigborChar = map[currentPosition.X, currentPosition.Y];
                            if (neigborChar == '*')
                            {
                                neigborStars.Add(currentPosition);
                            }
                        }
                    }
                    else
                    {
                        AddStarNeigborNumbers();
                    }
                }
                AddStarNeigborNumbers();
            }
            foreach (var (point, numbers) in stars)
            {
                if (numbers.Count == 2)
                {
                    total += numbers[0] * numbers[1];
                }
            }
            total.PrintIntOutput();
        }
    }
}