namespace day03_2
{
    public static class AdventTools
    {
        static string InputPath { get; } = Environment.CurrentDirectory + "\\input.txt";

        static string OutputPath { get; } = Environment.CurrentDirectory + "\\output.txt";

        public static string[] GetInput()
        {
            return File.ReadAllLines(InputPath);
        }

        public static void PrintStringOutput(this string input)
        {
            Console.WriteLine($"Result: {input} \nSaved at: {OutputPath}");
            File.WriteAllText(OutputPath, input);
        }

        public static void PrintIntOutput(this int input)
        {
            var output = input.ToString();
            Console.WriteLine($"Result: {output} \nSaved at: {OutputPath}");
            File.WriteAllText(OutputPath, output);
        }

    }
}
