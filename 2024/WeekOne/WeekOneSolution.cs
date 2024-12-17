using _2024.Utilities;

namespace _2024.WeekOne;

public class WeekOneSolution : ISolution
{
    public string GetSolution()
    {
        var inputFilepath = "WeekOne/input.txt";

        var lines = File.ReadAllLines(inputFilepath);

        if (lines.Length == 0)
        {
            return string.Empty;
        }

        var (leftArray, rightArray) = StringManipulation.SplitVertically(lines);

        var leftArrayNums = leftArray.Select(int.Parse).ToArray().Order().ToArray();
        var rightArrayNums = rightArray.Select(int.Parse).ToArray().Order().ToArray();

        int sum = 0;

        for (int i = 0; i < leftArrayNums.Count(); i++)
        {
            sum += (Math.Abs(leftArrayNums[i] - rightArrayNums[i]));
        }

        return sum.ToString();
    }


}