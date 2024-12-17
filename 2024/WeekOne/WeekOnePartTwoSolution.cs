using _2024.Utilities;

namespace _2024.WeekOne;

public class WeekOnePartTwoSolution : ISolution
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

        var leftArrayGrouped = leftArray.Select(int.Parse).GroupBy(x => x).ToList();
        var rightArrayGrouped = rightArray.Select(int.Parse).GroupBy(x => x).ToList();

        int output = 0;

        foreach (var grouping in leftArrayGrouped)
        {
            var num = grouping.Key;
            var count = grouping.Count();

            var matchingGroupFromRightArray = rightArrayGrouped.Find(x => x.Key == num);

            if (matchingGroupFromRightArray != null)
            {
                output += count * (num * matchingGroupFromRightArray.Count());
            }
        }
        
        return output.ToString();   
    }
}