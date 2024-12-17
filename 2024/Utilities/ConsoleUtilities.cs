namespace _2024.Utilities;

public class ConsoleUtilities
{
    public static void PrintSolution(Func<string> solutionFn, string week)
    {
        Console.WriteLine("******************************************");
        Console.WriteLine($"Week: {week}");
        Console.WriteLine($"Solution: {solutionFn()}");
        Console.WriteLine("******************************************");
    }
}