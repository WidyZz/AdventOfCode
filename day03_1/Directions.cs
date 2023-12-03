using System.Drawing;

public static class Directions
{
    public static Point[] Diagonal { get; } = {
    new Point(0, 1),
    new Point(1, 0),
    new Point(0, -1),
    new Point(-1, 0),
    new Point(1, 1),
    new Point(-1, 1),
    new Point(1, -1),
    new Point(-1, -1)
};
}