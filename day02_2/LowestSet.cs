class LowestSet
{
    public int Green { get; set; }
    public int Blue { get; set; }
    public int Red { get; set; }

    public LowestSet()
    {
        Green = 0;
        Blue = 0;
        Red = 0;
    }

    public int GetMultiplication()
    {
        return Red * Green * Blue;
    }
}